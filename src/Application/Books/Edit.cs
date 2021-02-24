using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Books
{
  /// <summary>
  /// Class Edit
  /// Implements a feature to edit the book via JSON request
  /// </summary>
  public class Edit
  {
    /// <summary>
    /// Class Command
    /// </summary>
    public class Command : IRequest<Book>
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
    /// Class CommandValidator.
    /// Implements validator
    /// </summary>
    public class CommandValidator : AbstractValidator<Command>
    {
      /// <summary>
      /// Method handles validation
      /// </summary>
      public CommandValidator()
      {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Wrong credentials");
      }
    }

    /// <summary>
    ///  Class Handler
    /// </summary>
    public class Handler : IRequestHandler<Command, Book>
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
      public async Task<Book> Handle(Command request, CancellationToken cancellationToken)
      {
        var book = await _context.Books.FindAsync(request.Id);

        if (book == null)
          throw new RestException(
            HttpStatusCode.NotFound,
            new { Activity = "Not found" });

        book.Title = request.Title ?? book.Title;

        _context.Update(book);

        var success = await _context.SaveChangesAsync() > 0;

        if (success) return book;

        throw new Exception("Problem saving changes");
      }
    }
  }
}
