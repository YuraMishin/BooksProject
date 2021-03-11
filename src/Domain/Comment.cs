using System;
using System.Collections.Generic;
using Domain.Moderation;

namespace Domain
{
  /// <summary>
  /// Class Comment
  /// </summary>
  public class Comment : BaseModel<Guid>
  {
    /// <summary>
    /// Content
    /// </summary>
    public string Content { get; set; }

    /// <summary>
    /// HtmlContent
    /// </summary>
    public string HtmlContent { get; set; }

    public Guid? ModerationItemId { get; set; }
    public ModerationItem ModerationItem { get; set; }

    public Guid? ParentId { get; set; }
    public Comment Parent { get; set; }

    public IList<Comment> Replies { get; set; } = new List<Comment>();
  }
}
