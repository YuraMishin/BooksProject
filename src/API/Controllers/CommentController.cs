using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using API.ViewModels;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace API.Controllers
{
  [ApiController]
  [Route("api/comments")]
  public class CommentController : ControllerBase
  {
    private readonly DataContext _ctx;

    public CommentController(DataContext ctx)
    {
      _ctx = ctx;
    }

    [HttpGet("{id}/replies")]
    public IEnumerable<object> GetReplies(Guid id) =>
        _ctx.Comments
            .Where(x => x.ParentId == id)
            .Select(CommentViewModel.Projection)
            .ToList();

    [HttpPost("{id}/replies")]
    public async Task<IActionResult> Reply(Guid id, [FromBody] Comment reply)
    {
      var comment = _ctx.Comments.FirstOrDefault(x => x.Id == id);

      if (comment == null)
      {
        return NoContent();
      }

      var regex = new Regex(@"\B(?<tag>@[a-zA-Z0-9-_]+)");

      reply.HtmlContent = regex.Matches(reply.Content)
                               .Aggregate(reply.Content,
                                          (content, match) =>
                                          {
                                            var tag = match.Groups["tag"].Value;
                                            return content
                                                     .Replace(tag, $"<a href=\"{tag}-user-link\">{tag}</a>");
                                          });

      comment.Replies.Add(reply);

      await _ctx.SaveChangesAsync();

      return Ok(CommentViewModel.Create(reply));
    }
  }
}
