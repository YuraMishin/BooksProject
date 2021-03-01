using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Seeders
{
  /// <summary>
  /// Class BookSeeder.
  /// Seeds Books table
  /// </summary>
  public class BooksSeeder
  {
    /// <summary>
    /// Method performs the operation
    /// </summary>
    /// <param name="context">context</param>
    public static async Task SeedData(DataContext context)
    {
      if (!context.Books.Any())
      {
        var diffDefaultName = context
          .Difficulties
          .SingleOrDefaultAsync(difficulty =>
           difficulty.Description == "Easy")
          .Result;
        var books = new List<Book>
                {
                    new Book
                    {
                        Title = "Book 1"
                    }
                };

        await context.Books.AddRangeAsync(books);
        await context.SaveChangesAsync();
      }
    }
  }
}
