using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Persistence;
using Persistence.Seeders;

namespace API
{
  /// <summary>
  /// Class Program.
  /// Implements the main app class
  /// </summary>
  public class Program
  {
    /// <summary>
    /// App entry point
    /// </summary>
    /// <param name="args">args</param>
    /// <returns>Task</returns>
    public static async Task Main(string[] args)
    {
      var host = CreateHostBuilder(args).Build();
      using var scope = host.Services.CreateScope();

      var services = scope.ServiceProvider;
      try
      {
        var context = services.GetRequiredService<DataContext>();
        var env = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();

        // Creates DB if it doesn't exist
        await context.Database.MigrateAsync();

        if (env.IsDevelopment())
        {
          // Seeds data
          await DifficultiesSeeder.SeedData(context);
          await CategoriesSeeder.SeedData(context);
          await BooksSeeder.SeedData(context);
          await SubmissionsSeeder.SeedData(context);
          await ModerationsSeeder.SeedData(context);
        }
      }
      catch (Exception ex)
      {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occured during migration");
      }

      await host.RunAsync();
    }

    /// <summary>
    /// Method bootstraps the app
    /// </summary>
    /// <param name="args">args</param>
    /// <returns>IHostBuilder</returns>
    public static IHostBuilder CreateHostBuilder(string[] args) =>
      Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
          webBuilder.UseStartup<Startup>();
        });
  }
}
