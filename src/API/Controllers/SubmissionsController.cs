using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;
using API.BackgroundServices.VideoEditing;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace API.Controllers
{
  /// <summary>
  /// Class BooksController.
  /// Implements Submissions API
  /// </summary>
  [ApiController]
  [Route("api/submissions")]
  public class SubmissionsController : ControllerBase
  {
    /// <summary>
    /// Context
    /// </summary>
    private readonly DataContext _ctx;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="ctx">context</param>
    public SubmissionsController(DataContext ctx)
    {
      _ctx = ctx;
    }

    /// <summary>
    /// Method retrieves all the submissions.
    /// GET: /api/submissions
    /// </summary>
    /// <returns>JSON</returns>
    [HttpGet]
    public IEnumerable<Submission> All() => _ctx
      .Submissions
      .Where(x => x.VideoProcessed)
      .ToList();

    /// <summary>
    /// Method retrieves the specific submission.
    /// GET: /api/submissions/{id}
    /// </summary>
    /// <param name="id">id</param>
    /// <returns>JSON</returns>
    [HttpGet("{id}")]
    public Submission Get(Guid id) => _ctx.Submissions.Find(id);

    /// <summary>
    /// Method creates a submission.
    /// POST: /api/submissions
    /// </summary>
    /// <param name="submission">submission</param>
    /// <param name="channel">channel</param>
    /// <returns>JSON</returns>
    [HttpPost]
    public async Task<IActionResult> Create(
      [FromBody] Submission submission,
      [FromServices] Channel<EditVideoMessage> channel,
      [FromServices] VideoManager videoManager)
    {
      if (!videoManager.TemporaryVideoExists(submission.Video))
      {
        return BadRequest();
      }

      submission.VideoProcessed = false;
      _ctx.Add(submission);
      await _ctx.SaveChangesAsync();
      await channel.Writer.WriteAsync(new EditVideoMessage
      {
        SubmissionId = submission.Id,
        Input = submission.Video,
      });
      return Ok(submission);
    }

    /// <summary>
    /// Method updates the submission.
    /// PUT: /api/submissions
    /// </summary>
    /// <param name="submission">submission</param>
    /// <returns>JSON</returns>
    [HttpPut]
    public async Task<Submission> Update([FromBody] Submission submission)
    {
      _ctx.Add(submission);
      await _ctx.SaveChangesAsync();
      return submission;
    }

    /// <summary>
    /// Method deletes the submission.
    /// DELETE: /api/submissions/id
    /// </summary>
    /// <param name="id">id</param>
    /// <returns>JSON</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      var submission = _ctx.Submissions.Find(id);
      if (submission == null)
      {
        return NotFound();
      }

      _ctx.Remove(submission);
      await _ctx.SaveChangesAsync();
      return Ok();
    }
  }
}
