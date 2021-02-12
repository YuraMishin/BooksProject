using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Books
{
  /// <summary>
  /// Сlass Create.
  /// Implements a feature to create a book via JSON request
  /// </summary>
  public class Create
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

      /// <summary>
      /// Title
      /// </summary>
      public string Title { get; set; }
    }

    /// <summary>
    /// Class Handler
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
        var book = new Book
        {
          Id = request.Id,
          Title = request.Title

        };

        _context.Books.Add(book);
        var success = await _context.SaveChangesAsync() > 0;

        if (success) return Unit.Value;

        throw new Exception("Problem saving changes");
      }
    }
  }
}
