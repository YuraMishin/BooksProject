using System;
using System.Collections.Generic;

namespace Domain
{
  /// <summary>
  /// Class Category.
  /// Implements Category Entity
  /// </summary>
  public class Category : BaseModel<Guid>
  {
    /// <summary>
    /// Name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Description
    /// </summary>
    public string Description { get; set; }

    #region Books Many-To-Many

    /// <summary>
    /// Books
    /// </summary>
    public IList<Book> Books { get; set; } = new List<Book>();

    #endregion
  }
}
