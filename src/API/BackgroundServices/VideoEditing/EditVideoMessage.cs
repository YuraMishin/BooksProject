using System;

namespace API.BackgroundServices.VideoEditing
{
  /// <summary>
  /// Class EditVideoMessage
  /// </summary>
  public class EditVideoMessage
  {
    /// <summary>
    /// SubmissionId
    /// </summary>
    public Guid SubmissionId { get; set; }

    /// <summary>
    /// Input
    /// </summary>
    public string Input { get; set; }
  }
}
