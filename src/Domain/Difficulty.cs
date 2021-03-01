using System;
using System.Collections.Generic;

namespace Domain
{
  /// <summary>
  /// Class Difficulty.
  /// Implements Difficulty Entity
  /// </summary>
  public class Difficulty : BaseModel<Guid>
  {
    /// <summary>
    /// Name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Description
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Books.
    /// One-To-Many
    /// </summary>
    public IList<Book> Books { get; set; } = new List<Book>();
  }
}
