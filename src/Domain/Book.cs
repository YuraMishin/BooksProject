using System;
using System.Collections.Generic;

namespace Domain
{
  /// <summary>
  /// Class Book.
  /// Implements Book Entity
  /// </summary>
  public class Book : BaseModel<Guid>
  {
    /// <summary>
    /// Title
    /// </summary>
    public string Title { get; set; }

    #region Difficulty Many-To-One

    /// <summary>
    /// DifficultyId
    /// </summary>
    public Guid DifficultyId { get; set; }
    /// <summary>
    /// Difficulty
    /// </summary>
    public Difficulty Difficulty { get; set; }

    #endregion

    /// <summary>
    /// Prerequisites
    /// </summary>
    public IList<BookRelationship> Prerequisites { get; set; } = new List<BookRelationship>();

    /// <summary>
    /// Progressions
    /// </summary>
    public IList<BookRelationship> Progressions { get; set; } = new List<BookRelationship>();
  }
}
