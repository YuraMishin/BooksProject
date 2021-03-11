using System.Linq;
using System.Threading.Tasks;
using Domain.Moderation;

namespace Persistence.Seeders
{
  /// <summary>
  /// Class ModerationsSeeder.
  /// Seeds Moderations table
  /// </summary>
  public class ModerationsSeeder
  {
    /// <summary>
    /// Method performs the operation
    /// </summary>
    /// <param name="context">context</param>
    public static async Task SeedData(DataContext context)
    {
      if (!context.ModerationItems.Any())
      {
        var bookId = context.Books.Where(book => book.Title.Equals("Book Current")).First().Id;

        var moderation = new ModerationItem
        {
          Target = bookId,
          Type = ModerationTypes.Book
        };

        await context.ModerationItems.AddAsync(moderation);
        await context.SaveChangesAsync();
      }
    }
  }
}
