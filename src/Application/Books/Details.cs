using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Domain;
using MediatR;
using Persistence;

namespace Application.Books
{
  /// <summary>
  /// Class Details.
  /// Implements retrieving the specific book
  /// </summary>
  public class Details
  {
    /// <summary>
    /// Class Query
    /// </summary>
    public class Query : IRequest<Book>
    {
      /// <summary>
      /// Id
      /// </summary>
      public Guid Id { get; set; }
    }

    /// <summary>
    ///  Class Handler
    /// </summary>
    public class Handler : IRequestHandler<Query, Book>
    {
      /// <summary>
      /// DataContext
      /// </summary>
      private readonly DataContext _context;

      /// <summary>
      /// Constructor
      /// </summary>
      /// <param name="context">context</param>
      public Handler(DataContext context)
      {
        _context = context;
      }

      /// <summary>
      /// Method performs the feature
      /// </summary>
      /// <param name="request">request</param>
      /// <param name="cancellationToken">cancellationToken</param>
      /// <returns>JSON</returns>
      public async Task<Book> Handle(Query request, CancellationToken cancellationToken)
      {
        var book = await _context.Books.FindAsync(request.Id);

        if (book == null) throw new RestException(
          HttpStatusCode.NotFound,
          new { Book = "Not found" });

        return book;
      }
    }
  }
}
