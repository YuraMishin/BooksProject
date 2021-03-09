using System;

namespace API.BackgroundServices.VideoEditing
{
  public class EditVideoMessage
  {
    public Guid SubmissionId { get; set; }
    public string Input { get; set; }
  }
}
