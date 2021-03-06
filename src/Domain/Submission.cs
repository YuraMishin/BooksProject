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

    public Guid VideoId { get; set; }
    public Video Video { get; set; }

    /// <summary>
    /// Description
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// VideoProcessed
    /// </summary>
    public bool VideoProcessed { get; set; }
  }
}
