using System;

namespace Domain
{
  public class BookRelationship
  {
    public Guid PrerequisiteId { get; set; }
    public Book Prerequisite { get; set; }
    public Guid ProgressionId { get; set; }
    public Book Progression { get; set; }
  }
}
