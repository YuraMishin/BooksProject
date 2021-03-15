using System;
using System.Linq;
using System.Linq.Expressions;
using Domain;

namespace API.ViewModels
{
  /// <summary>
  /// Class BookViewModels
  /// </summary>
  public static class BookViewModel
  {
    /// <summary>
    /// Func
    /// </summary>
    public static readonly Func<Book, object> Create = Projection.Compile();

    /// <summary>
    /// Expression
    /// </summary>
    public static Expression<Func<Book, object>> Projection =>
      book => new
      {
        book.Id,
        book.Title,
        book.Description,
        book.DifficultyId,
        Categories = book.Categories.Select(x => x.Id),
        Prerequisites = book.Prerequisites.Select(x => x.PrerequisiteId),
        Progressions = book.Progressions.Select(x => x.ProgressionId)
      };
  }
}
