using System;

namespace Domain
{
  /// <summary>
  /// Class BaseModel.
  /// Declares base model
  /// </summary>
  public abstract class BaseModel
  {
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }
  }
}
