using System;
using System.Collections.Generic;
using System.Linq;
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
    public ModerationItem Get(Guid id) =>
        _ctx.ModerationItems.FirstOrDefault(x => x.Id.Equals(id));
  }
}
