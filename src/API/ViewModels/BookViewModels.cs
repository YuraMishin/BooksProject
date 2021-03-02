using System;
using System.Linq;
using System.Linq.Expressions;
using Domain;

namespace API.ViewModels
{
  /// <summary>
  /// Class BookViewModels
  /// </summary>
  public static class BookViewModels
  {
    /// <summary>
    /// Method originates the output object
    /// </summary>
    public static Expression<Func<Book, object>> Default =>
      book => new
      {
        book.Id,
        book.Title,
        book.Description,
        book.DifficultyId,
        Categories = book.Categories.Select(x => x.Id)
      };
  }
}
