using System;

namespace Domain
{
  public class Category : BaseModel<Guid>
  {
    public string Description { get; set; }
  }
}
