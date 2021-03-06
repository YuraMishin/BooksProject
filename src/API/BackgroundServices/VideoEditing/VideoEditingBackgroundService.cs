using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Domain;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Persistence;

namespace API.BackgroundServices.VideoEditing
{
  /// <summary>
  /// Class VideoEditingBackgroundService
  /// </summary>
  public class VideoEditingBackgroundService : BackgroundService
  {
    private readonly ILogger<VideoEditingBackgroundService> _logger;
    private readonly IServiceProvider _serviceProvider;
    private readonly VideoManager _videoManager;
    private readonly ChannelReader<EditVideoMessage> _channelReader;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="channel">channel</param>
    /// <param name="logger">logger</param>
    /// <param name="serviceProvider">serviceProvider</param>
    /// <param name="videoManager">videoManager</param>
    public VideoEditingBackgroundService(
        Channel<EditVideoMessage> channel,
        ILogger<VideoEditingBackgroundService> logger,
        IServiceProvider serviceProvider,
        VideoManager videoManager)
    {
      _logger = logger;
      _serviceProvider = serviceProvider;
      _videoManager = videoManager;
      _channelReader = channel.Reader;
    }

    /// <summary>
    /// Method performs the CLI tool
    /// </summary>
    /// <param name="stoppingToken">stoppingToken</param>
    /// <returns>Task</returns>
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
      while (await _channelReader.WaitToReadAsync(stoppingToken))
      {
        var message = await _channelReader.ReadAsync(stoppingToken);
        var inputPath = _videoManager.TemporarySavePath(message.Input);
        var outputConvertedName = _videoManager.GenerateConvertedFileName();
        var outputThumbnailName = _videoManager.GenerateThumbnailFileName();
        var outputConvertedPath = _videoManager.TemporarySavePath(outputConvertedName);
        var outputThumbnailPath = _videoManager.TemporarySavePath(outputThumbnailName);
        try
        {
          var startInfo = new ProcessStartInfo
          {
            FileName = _videoManager.FFMPEGPath,
            Arguments = $"-y -i {inputPath} -an -vf scale=100x100 {outputConvertedPath} -ss 00:00:00 -vframes 1 -vf scale=100x100 {outputThumbnailPath}",
            CreateNoWindow = true,
            UseShellExecute = false,
          };

          using (var process = new Process { StartInfo = startInfo })
          {
            process.Start();
            process.WaitForExit();
          }

          if (!_videoManager.TemporaryFileExists(outputConvertedName))
          {
            throw new Exception("FFMPEG failed to generate converted video");
          }

          if (!_videoManager.TemporaryFileExists(outputThumbnailName))
          {
            throw new Exception("FFMPEG failed to generate thumbnail");
          }

          using (var scope = _serviceProvider.CreateScope())
          {
            var ctx = scope.ServiceProvider.GetRequiredService<DataContext>();

            var submission = ctx.Submissions.FirstOrDefault(x => x.Id.Equals(message.SubmissionId));

            submission.Video = new Video
            {
              VideoLink = outputConvertedName,
              ThumbLink = outputThumbnailName,
            };
            submission.VideoProcessed = true;

            await ctx.SaveChangesAsync(stoppingToken);
          }
        }
        catch (Exception e)
        {
          _logger.LogError(e, "Video Processing Failed for {0}", message.Input);
          _videoManager.DeleteTemporaryFile(outputConvertedName);
          _videoManager.DeleteTemporaryFile(outputThumbnailName);
        }
        finally
        {
          _videoManager.DeleteTemporaryFile(message.Input);
        }
      }
    }
  }
}
