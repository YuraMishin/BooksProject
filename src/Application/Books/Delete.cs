using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using MediatR;
using Persistence;

namespace Application.Books
{
  /// <summary>
  /// Class Details.
  /// Implements deleting the specific book
  /// </summary>
  public class Delete
  {
    /// <summary>
    /// Class Command
    /// </summary>
    public class Command : IRequest
    {
      /// <summary>
      /// Id
      /// </summary>
      public Guid Id { get; set; }
    }

    /// <summary>
    ///  Class Handler
    /// </summary>
    public class Handler : IRequestHandler<Command>
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
      public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
      {
        var book = await _context.Books.FindAsync(request.Id);

        if (book == null)
          throw new RestException(HttpStatusCode.NotFound, new { Book = "Not found" });

        _context.Remove(book);

        var success = await _context.SaveChangesAsync() > 0;

        if (success) return Unit.Value;

        throw new Exception("Problem saving changes");
      }
    }
  }
}
