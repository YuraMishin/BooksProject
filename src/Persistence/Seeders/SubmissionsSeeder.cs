using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Persistence.Seeders
{
  /// <summary>
  /// Class SubmissionsSeeder.
  /// Seeds Submissions table
  /// </summary>
  public class SubmissionsSeeder
  {
    /// <summary>
    /// Method performs the operation
    /// </summary>
    /// <param name="context">context</param>
    public static async Task SeedData(DataContext context)
    {
      if (!context.Submissions.Any())
      {
        var bookId = context.Books.Where(book => book.Title.Equals("Book Current")).First().Id;

        var submission = new Submission
        {
          BookId = bookId,
          Description = "Description",
          VideoProcessed = true,
          Video = new Video
          {
            ThumbLink = "default.jpg",
            VideoLink = "default.mp4"
          }
        };

        await context.Submissions.AddAsync(submission);
        await context.SaveChangesAsync();
      }
    }
  }
}
