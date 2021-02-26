using System;

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
  }
}
