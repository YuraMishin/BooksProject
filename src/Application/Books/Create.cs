using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using FluentValidation;
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

      /// <summary>
      /// Description
      /// </summary>
      public string Description { get; set; }

      /// <summary>
      /// Difficulty
      /// </summary>
      public Guid Difficulty { get; set; }
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
    /// Class Handler
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
        var book = new Book
        {
          Id = request.Id,
          Title = request.Title,
          Description = request.Description,
          DifficultyId = request.Difficulty
        };

        _context.Books.Add(book);
        var success = await _context.SaveChangesAsync() > 0;

        if (success) return book;

        throw new Exception("Problem saving changes");
      }
    }
  }
}
