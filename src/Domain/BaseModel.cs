namespace Domain
{
  /// <summary>
  /// Class BaseModel.
  /// Declares base model
  /// </summary>
  public abstract class BaseModel<TKey>
  {
    /// <summary>
    /// Id
    /// </summary>
    public TKey Id { get; set; }
  }
}
