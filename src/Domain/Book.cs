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
  }
}
