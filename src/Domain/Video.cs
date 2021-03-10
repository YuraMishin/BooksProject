using System;

namespace Domain
{
  public class Video : BaseModel<Guid>
  {
    public string VideoLink { get; set; }
    public string ThumbLink { get; set; }
  }
}
