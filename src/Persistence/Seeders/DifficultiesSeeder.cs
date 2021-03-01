using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Persistence.Seeders
{
  /// <summary>
  /// Class DifficultiesSeeder.
  /// Seeds Difficulties table
  /// </summary>
  public class DifficultiesSeeder
  {
    /// <summary>
    /// Method performs the operation
    /// </summary>
    /// <param name="context">context</param>
    public static async Task SeedData(DataContext context)
    {
      if (!context.Difficulties.Any())
      {
        var difficulties = new List<Difficulty>
                {
                    new Difficulty
                    {
                        Name = "Easy",
                        Description = "Easy"
                    },
                    new Difficulty
                    {
                      Name = "Medium",
                      Description = "Medium"
                    },
                    new Difficulty
                    {
                      Name = "Hard",
                      Description = "Hard"
                    }
                };

        await context.Difficulties.AddRangeAsync(difficulties);
        await context.SaveChangesAsync();
      }
    }
  }
}
