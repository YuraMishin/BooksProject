using System;
using System.Collections.Generic;

namespace API.FormModels
{
  /// <summary>
  /// Class BookFormModel
  /// </summary>
  public class BookFormModel
  {
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Title
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Description
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Difficulty
    /// </summary>
    public Guid Difficulty { get; set; }

    /// <summary>
    /// Categories
    /// </summary>
    public IEnumerable<Guid> Categories { get; set; }
  }
}
