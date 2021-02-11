using System;
using System.Net;
using System.Threading.Tasks;
using Application.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace API.Middleware
{
  /// <summary>
  /// Class ErrorHandlingMiddleware.
  /// Implements middleware to handle exceptions
  /// </summary>
  public class ErrorHandlingMiddleware
  {
    /// <summary>
    /// RequestDelegate
    /// </summary>
    private readonly RequestDelegate _next;

    /// <summary>
    /// ILogger
    /// </summary>
    private readonly ILogger<ErrorHandlingMiddleware> _logger;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="next">next</param>
    /// <param name="logger">logger</param>
    public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
    {
      _logger = logger;
      _next = next;
    }

    /// <summary>
    /// Invoke
    /// </summary>
    /// <param name="context">context</param>
    /// <returns>Task</returns>
    public async Task Invoke(HttpContext context)
    {
      try
      {
        await _next(context);
      }
      catch (Exception ex)
      {
        await HandleExceptionAsync(context, ex, _logger);
      }
    }

    /// <summary>
    /// HandleExceptionAsync
    /// </summary>
    /// <param name="context">context</param>
    /// <param name="ex">exception</param>
    /// <param name="logger">logger</param>
    /// <returns>Task</returns>
    private async Task HandleExceptionAsync(
      HttpContext context,
      Exception ex,
      ILogger<ErrorHandlingMiddleware> logger
      )
    {
      object errors = null;

      switch (ex)
      {
        case RestException re:
          logger.LogError(ex, "REST ERROR");
          errors = re.Errors;
          context.Response.StatusCode = (int)re.Code;
          break;
        case Exception e:
          logger.LogError(ex, "SERVER ERROR");
          errors = string.IsNullOrWhiteSpace(e.Message) ? "Error" : e.Message;
          context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
          break;
      }

      context.Response.ContentType = "application/json";
      if (errors != null)
      {
        var result = JsonConvert.SerializeObject(new
        {
          errors
        });

        await context.Response.WriteAsync(result);
      }
    }
  }
}
