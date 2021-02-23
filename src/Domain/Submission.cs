using System;

namespace Domain
{
  public class Submission : BaseModel
  {
    public Guid BookId { get; set; }
    public string Video { get; set; }
    public string Description { get; set; }
  }
}
