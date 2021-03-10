using System.IO;
using System.Threading.Tasks;
using API.BackgroundServices.VideoEditing;
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
    private readonly VideoManager _videoManager;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="videoManager">videoManager</param>
    public VideosController(VideoManager videoManager)
    {
      _videoManager = videoManager;
    }

    /// <summary>
    /// Method handles file uploading
    /// POST: /api/videos/{file}
    /// </summary>
    /// <param name="video"></param>
    /// <returns></returns>
    [HttpPost]
    public Task<string> UploadVideo(IFormFile video)
    {
      return _videoManager.SaveTemporaryVideo(video);
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
      var savePath = _videoManager.DevVideoPath(video);
      if (string.IsNullOrEmpty(savePath))
      {
        return BadRequest();
      }

      return new FileStreamResult(new FileStream(savePath, FileMode.Open, FileAccess.Read), "video/*");
    }

    /// <summary>
    /// Method deletes temp video.
    /// DELETE: /api/videos/{fileName}
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    [HttpDelete("{fileName}")]
    public IActionResult DeleteTemporaryVideo(string fileName)
    {
      if (!_videoManager.Temporary(fileName))
      {
        return BadRequest();
      }

      if (!_videoManager.TemporaryFileExists(fileName))
      {
        return NoContent();
      }

      _videoManager.DeleteTemporaryFile(fileName);

      return Ok();
    }
  }
}
