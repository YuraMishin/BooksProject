using System;

namespace Domain
{
  /// <summary>
  /// Class Book.
  /// Implements Book Entity
  /// </summary>
  public class Book
  {
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Title
    /// </summary>
    public string Title { get; set; }
  }
}
