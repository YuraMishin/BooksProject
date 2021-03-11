using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using API.ViewModels;
using Domain;
using Domain.Moderation;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace API.Controllers
{
  /// <summary>
  /// Class ModerationItemController
  /// </summary>
  [ApiController]
  [Route("api/moderation-items")]
  public class ModerationItemController : ControllerBase
  {
    /// <summary>
    /// DataContext
    /// </summary>
    private readonly DataContext _ctx;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="ctx">ctx</param>
    public ModerationItemController(DataContext ctx)
    {
      _ctx = ctx;
    }

    /// <summary>
    /// Method retrieves all the moderation items.
    /// GET: /api/moderation-items/
    /// </summary>
    /// <returns>JSON</returns>
    [HttpGet]
    public IEnumerable<ModerationItem> All() => _ctx.ModerationItems.ToList();

    /// <summary>
    /// Method retrieves the specific moderation item.
    /// GET: /api/moderation-items/{id}
    /// </summary>
    /// <param name="id">id</param>
    /// <returns>JSON</returns>
    [HttpGet("{id}")]
    public ModerationItem Get(int id) => _ctx.ModerationItems.FirstOrDefault(x => x.Id.Equals(id));

    /// <summary>
    /// Method retrieves the specific comment.
    /// GET: /api/moderation-items/{id}/comments
    /// </summary>
    /// <param name="id"></param>
    /// <returns>JSON</returns>
    [HttpGet("{id}/comments")]
    public IEnumerable<object> GetComments(Guid id) =>
      _ctx.Comments
        .Where(x => x.ModerationItemId.Equals(id))
        .Select(CommentViewModel.Projection)
        .ToList();

    /// <summary>
    /// Method saves the specific comment.
    /// POST: /api/moderation-items/{id}/comments
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="comment">comment</param>
    /// <returns>JSON</returns>
    [HttpPost("{id}/comments")]
    public async Task<IActionResult> Comment(Guid id, [FromBody] Comment comment)
    {
      var modItem = _ctx.ModerationItems.FirstOrDefault(x => x.Id == id);

      if (modItem == null)
      {
        return NoContent();
      }

      var regex = new Regex(@"\B(?<tag>@[a-zA-Z0-9-_]+)");

      comment.HtmlContent = regex.Matches(comment.Content)
                                 .Aggregate(comment.Content,
                                            (content, match) =>
                                            {
                                              var tag = match.Groups["tag"].Value;
                                              return content
                                                       .Replace(tag, $"<a href=\"{tag}-user-link\">{tag}</a>");
                                            });

      modItem.Comments.Add(comment);
      await _ctx.SaveChangesAsync();

      return Ok(CommentViewModel.Create(comment));
    }
  }
}
