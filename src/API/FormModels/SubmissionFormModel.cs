using System;

namespace API.FormModels
{
  /// <summary>
  /// Class SubmissionFormModel
  /// </summary>
  public class SubmissionFormModel
  {
    /// <summary>
    /// BookId
    /// </summary>
    public Guid BookId { get; set; }

    /// <summary>
    /// Description
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Video
    /// </summary>
    public string Video { get; set; }
  }
}
