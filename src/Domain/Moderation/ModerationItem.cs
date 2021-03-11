using System;
using System.Collections.Generic;

namespace Domain.Moderation
{
  /// <summary>
  /// Class ModerationItem
  /// </summary>
  public class ModerationItem : BaseModel<Guid>
  {
    /// <summary>
    /// Target
    /// </summary>
    public Guid Target { get; set; }

    /// <summary>
    /// Type
    /// </summary>
    public string Type { get; set; }

    /// <summary>
    /// Comments
    /// </summary>
    public IList<Comment> Comments { get; set; } = new List<Comment>();
  }
}
