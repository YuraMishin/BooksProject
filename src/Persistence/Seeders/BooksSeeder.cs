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
        var easyId = context
          .Difficulties
          .SingleOrDefaultAsync(difficulty =>
           difficulty.Description == "Easy")
          .Result.Id;
        var books = new List<Book>
                {
                   new Book
                    {
                      Title = "Book Previous",
                      Description = "Description",
                      DifficultyId = easyId,
                      Categories = context.Categories.ToList()
                    }
                };

        await context.Books.AddRangeAsync(books);
        await context.SaveChangesAsync();

        await context.Books.AddAsync(new Book
        {
          Title = "Book Current",
          Description = "Description",
          DifficultyId = easyId,
          Categories = context.Categories.ToList(),
          Prerequisites = new List<BookRelationship>
          {
            new BookRelationship
            {
              PrerequisiteId = context
                .Books
                .Where(book => book.Title == "Book Previous")
                .FirstOrDefault()
                .Id
            }
          }
        });
        await context.SaveChangesAsync();

      }
    }
  }
}
