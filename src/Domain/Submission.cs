using System;

namespace Domain
{
  /// <summary>
  /// Class Submission.
  /// Implements Submission entity
  /// </summary>
  public class Submission : BaseModel<Guid>
  {
    /// <summary>
    /// BookId
    /// </summary>
    public Guid BookId { get; set; }
    /// <summary>
    /// Video
    /// </summary>
    public string Video { get; set; }
    /// <summary>
    /// Description
    /// </summary>
    public string Description { get; set; }
  }
}
