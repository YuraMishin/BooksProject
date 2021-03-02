using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Books
{
  /// <summary>
  /// Class List.
  /// Implements retrieving all the books
  /// </summary>
  public class List
  {
    /// <summary>
    /// Class Query
    /// </summary>
    public class Query : IRequest<List<Book>> { }

    /// <summary>
    /// Class Handler
    /// </summary>
    public class Handler : IRequestHandler<Query, List<Book>>
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
      public async Task<List<Book>> Handle(Query request, CancellationToken cancellationToken)
      {
        var books = await _context
          .Books
          .Include(book => book.Categories)
          .ToListAsync();

        return books;
      }
    }
  }
}
