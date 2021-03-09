using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Persistence;

namespace API.BackgroundServices
{
  /// <summary>
  /// Class VideoEditingBackgroundService
  /// </summary>
  public class VideoEditingBackgroundService : BackgroundService
  {
    private readonly IWebHostEnvironment _env;
    private readonly ILogger<VideoEditingBackgroundService> _logger;
    private readonly IServiceProvider _serviceProvider;
    private readonly ChannelReader<EditVideoMessage> _channelReader;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="env">env</param>
    /// <param name="channel">channel</param>
    /// <param name="logger">logger</param>
    /// <param name="serviceProvider">serviceProvider</param>
    public VideoEditingBackgroundService(
        IWebHostEnvironment env,
        Channel<EditVideoMessage> channel,
        ILogger<VideoEditingBackgroundService> logger,
        IServiceProvider serviceProvider)
    {
      _env = env;
      _logger = logger;
      _serviceProvider = serviceProvider;
      _channelReader = channel.Reader;
    }

    /// <summary>
    /// Method executes video conversion
    /// </summary>
    /// <param name="stoppingToken">stoppingToken</param>
    /// <returns></returns>
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
      while (await _channelReader.WaitToReadAsync(stoppingToken))
      {
        var message = await _channelReader.ReadAsync(stoppingToken);
        try
        {
          var inputPath = Path.Combine(_env.WebRootPath, message.Input);
          var outputName = $"c{DateTime.Now.Ticks}.mp4";
          var outputPath = Path.Combine(_env.WebRootPath, outputName);
          var startInfo = new ProcessStartInfo
          {
            FileName = Path.Combine(_env.ContentRootPath, "ffmpeg", "ffmpeg.exe"),
            Arguments = $"-y -i {inputPath} -an -vf scale=100x100 {outputPath}",
            WorkingDirectory = _env.WebRootPath,
            CreateNoWindow = true,
            UseShellExecute = false,
          };

          using (var process = new Process { StartInfo = startInfo })
          {
            process.Start();
            process.WaitForExit();
          }

          using (var scope = _serviceProvider.CreateScope())
          {
            var ctx = scope.ServiceProvider.GetRequiredService<DataContext>();

            var submission = ctx.Submissions.FirstOrDefault(x => x.Id.Equals(message.SubmissionId));

            submission.Video = outputName;
            submission.VideoProcessed = true;

            await ctx.SaveChangesAsync(stoppingToken);
          }
        }
        catch (Exception e)
        {
          _logger.LogError(e, "Video Processing Failed for {0}", message.Input);
        }
      }
    }
  }
}
