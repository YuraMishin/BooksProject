using System;

namespace Domain
{
  public class Difficulty : BaseModel<Guid>
  {
    public string Description { get; set; }
  }
}
