using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace API.BackgroundServices.VideoEditing
{
  /// <summary>
  /// Class VideoManager
  /// </summary>
  public class VideoManager
  {
    /// <summary>
    /// IWebHostEnvironment
    /// </summary>
    private readonly IWebHostEnvironment _env;

    /// <summary>
    /// TempPrefix
    /// </summary>
    public const string TempPrefix = "temp_";

    /// <summary>
    /// ConvertedPrefix
    /// </summary>
    public const string ConvertedPrefix = "c";

    /// <summary>
    /// ThumbnailPrefix
    /// </summary>
    public const string ThumbnailPrefix = "t";

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="env">env</param>
    public VideoManager(IWebHostEnvironment env)
    {
      _env = env;
    }

    /// <summary>
    /// Method retrieves WorkingDirectory
    /// </summary>
    public string WorkingDirectory => _env.WebRootPath;

    public string FFMPEGPath => Path.Combine(_env.ContentRootPath, "ffmpeg", "ffmpeg.exe");

    /// <summary>
    /// Method checks the filename 
    /// </summary>
    /// <param name="fileName">fileName</param>
    /// <returns>bool</returns>
    public bool Temporary(string fileName)
    {
      return fileName.StartsWith(TempPrefix);
    }

    /// <summary>
    /// Method checks if the temp video exists
    /// </summary>
    /// <param name="fileName">fileName</param>
    /// <returns>bool</returns>
    public bool TemporaryFileExists(string fileName)
    {
      var path = TemporarySavePath(fileName);
      return File.Exists(path);
    }

    /// <summary>
    /// Method deletes temp video
    /// </summary>
    /// <param name="fileName"></param>
    public void DeleteTemporaryFile(string fileName)
    {
      var path = TemporarySavePath(fileName);
      File.Delete(path);
    }

    /// <summary>
    /// Method forms video path
    /// </summary>
    /// <param name="fileName">fileName</param>
    /// <returns>string</returns>
    public string DevVideoPath(string fileName)
    {
      return !_env.IsDevelopment() ? null : Path.Combine(WorkingDirectory, fileName);
    }

    /// <summary>
    /// Method generates converted filename
    /// </summary>
    /// <returns>string</returns>
    public string GenerateConvertedFileName() => $"{ConvertedPrefix}{DateTime.Now.Ticks}.mp4";

    /// <summary>
    /// Method generates converted thumbnail name
    /// </summary>
    /// <returns>string</returns>
    public string GenerateThumbnailFileName() => $"{ThumbnailPrefix}{DateTime.Now.Ticks}.jpg";

    /// <summary>
    /// Method saves video
    /// </summary>
    /// <param name="video">video</param>
    /// <returns>string</returns>
    public async Task<string> SaveTemporaryVideo(IFormFile video)
    {
      var fileName = string.Concat(TempPrefix, DateTime.Now.Ticks, Path.GetExtension(video.FileName));
      var savePath = TemporarySavePath(fileName);

      await using (var fileStream = new FileStream(savePath, FileMode.Create, FileAccess.Write))
      {
        await video.CopyToAsync(fileStream);
      }

      return fileName;
    }

    /// <summary>
    /// Method forms temp save path
    /// </summary>
    /// <param name="fileName">fileName</param>
    /// <returns>string</returns>
    public string TemporarySavePath(string fileName)
    {
      return Path.Combine(WorkingDirectory, fileName);
    }
  }
}
