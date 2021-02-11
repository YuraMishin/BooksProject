using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

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
        var books = new List<Book>
                {
                    new Book
                    {
                        Title = "Book 1"
                    },
                    new Book
                    {
                        Title = "Book 2"
                    },
                    new Book
                    {
                        Title = "Book 3"
                    },
                };

        await context.Books.AddRangeAsync(books);
        await context.SaveChangesAsync();
      }
    }
  }
}
