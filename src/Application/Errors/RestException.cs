using System;
using System.Net;

namespace Application.Errors
{
  /// <summary>
  /// Class RestException.
  /// Implements custom exception
  /// </summary>
  public class RestException : Exception
  {
    /// <summary>
    /// HttpStatusCode
    /// </summary>
    public HttpStatusCode Code { get; }

    /// <summary>
    /// Errors
    /// </summary>
    public object Errors { get; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="code">code</param>
    /// <param name="errors">errors</param>
    public RestException(HttpStatusCode code, object errors = null)
    {
      Code = code;
      Errors = errors;
    }
  }
}
