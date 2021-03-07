using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  /// <summary>
  /// Class VideosController.
  /// Implements video file uploading
  /// </summary>
  [Route("api/[controller]")]
  public class VideosController : ControllerBase
  {
    private readonly IWebHostEnvironment _env;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="env">env</param>
    public VideosController(IWebHostEnvironment env)
    {
      _env = env;
    }

    /// <summary>
    /// Method handles file uploading
    /// POST: /api/videos/{file}
    /// </summary>
    /// <param name="video"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> UploadVideo(IFormFile video)
    {
      var mime = video.FileName.Split('.').Last();
      var fileName = string.Concat(Path.GetRandomFileName(), '.', mime);
      var savePath = Path.Combine(_env.WebRootPath, fileName);
      await using var fileStream =
        new FileStream(savePath, FileMode.Create, FileAccess.Write);
      await video.CopyToAsync(fileStream);

      //use ffmpeg CLI
      await Task.Run(() =>
      {
        var startInfo = new ProcessStartInfo
        {
          FileName = Path.Combine(_env.ContentRootPath, "ffmpeg", "ffmpeg.exe"),
          Arguments = $"-y -i {savePath} -an -vf scale=100x100 test2.mp4",
          WorkingDirectory = _env.WebRootPath,
          CreateNoWindow = true,
          UseShellExecute = false,
        };

        using (var process = new Process { StartInfo = startInfo })
        {
          process.Start();
          process.WaitForExit();
        }
      });



      return Ok(fileName);
    }

    /// <summary>
    /// Method streams the video file
    /// GET: /api/videos/{video}
    /// </summary>
    /// <param name="video">video</param>
    /// <returns>File</returns>
    [HttpGet("{video}")]
    public IActionResult GetVideo(string video)
    {
      var mime = video.Split('.').Last();
      var savePath = Path.Combine(_env.WebRootPath, video);
      return new FileStreamResult(new FileStream(savePath, FileMode.Open, FileAccess.Read), "video/*");
    }
  }
}
