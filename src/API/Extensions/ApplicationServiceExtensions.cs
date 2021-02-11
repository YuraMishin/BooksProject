using Application.Books;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Persistence;

namespace API.Extensions
{
  /// <summary>
  /// Class ApplicationServiceExtensions
  /// Implements service support
  /// </summary>
  public static class ApplicationServiceExtensions
  {
    /// <summary>
    /// Method adds applications services
    /// </summary>
    /// <param name="services">services</param>
    /// <param name="configuration">configuration</param>
    /// <returns>IServiceCollection</returns>
    public static IServiceCollection AddApplicationServices(
      this IServiceCollection services,
      IConfiguration configuration
      )
    {
      // Adds Swagger
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
      });

      // DB connection
      services.AddDbContext<DataContext>(
        option =>
        {
          option.EnableSensitiveDataLogging();
          option.EnableDetailedErrors();
          option.UseNpgsql(
            configuration.GetConnectionString("BooksProject"));
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


      // Adds Mediatr
      services.AddMediatR(typeof(List.Handler).Assembly);

      return services;
    }
  }
}
