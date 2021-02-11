using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Persistence;

namespace API
{
  /// <summary>
  /// Class Startup.
  /// Implements initial settings
  /// </summary>
  public class Startup
  {
    /// <summary>
    /// Configuration
    /// </summary>
    private readonly IConfiguration _configuration;

    /// <summary>
    /// 
    /// </summary>
    private readonly IWebHostEnvironment _env;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="configuration">configuration</param>
    /// <param name="env">env</param>
    public Startup(IConfiguration configuration, IWebHostEnvironment env)
    {
      _configuration = configuration;
      _env = env;
    }

    /// <summary>
    /// Method gets called by the runtime to add services to the container
    /// </summary>
    /// <param name="services">services</param>
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers();

      // DB connection
      services.AddDbContext<DataContext>(
        option =>
        {
          option.EnableSensitiveDataLogging();
          option.EnableDetailedErrors();
          option.UseNpgsql(
            _configuration.GetConnectionString("BooksProject"));
        });

      //CORS for Frontend frameworks
      services.AddCors(opt =>
      {
        opt.AddPolicy("CorsPolicy", policy =>
        {
          policy.AllowAnyHeader().AllowAnyMethod()
            .WithOrigins("http://localhost:3000");
        });
      });
    }

    /// <summary>
    /// Method gets called by the runtime to configure the HTTP request pipeline
    /// </summary>
    /// <param name="app">app</param>
    /// <param name="logger">logger</param>
    public void Configure(IApplicationBuilder app, ILogger<Startup> logger)
    {
      logger.LogInformation("App is running. Enjoy!");

      if (_env.IsDevelopment())
      {
        logger.LogInformation("Development mode");
        app.UseDeveloperExceptionPage();
      }
      if (_env.IsProduction())
      {
        logger.LogInformation("Production mode");
      }

      //CORS for Frontend frameworks
      app.UseCors("CorsPolicy");

      app.UseRouting();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapDefaultControllerRoute();
      });

    }
  }
}
