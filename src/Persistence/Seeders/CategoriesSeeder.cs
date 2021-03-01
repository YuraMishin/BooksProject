using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Persistence.Seeders
{
  /// <summary>
  /// Class CategoriesSeeder.
  /// Seeds Categories table
  /// </summary>
  public class CategoriesSeeder
  {
    /// <summary>
    /// Method performs the operation
    /// </summary>
    /// <param name="context">context</param>
    public static async Task SeedData(DataContext context)
    {
      if (!context.Categories.Any())
      {
        var categories = new List<Category>
                {
                    new Category
                    {
                        Name = "Adventure",
                        Description = "Adventure"
                    },
                    new Category
                    {
                      Name = "Space",
                      Description = "Space"
                    }
                };

        await context.Categories.AddRangeAsync(categories);
        await context.SaveChangesAsync();
      }
    }
  }
}
