using System;
using System.Linq;
using System.Threading.Tasks;
using API.FormModels;
using API.ViewModels;
using Application.Books;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
  /// <summary>
  /// Class BooksController.
  /// Implements Books API
  /// </summary>
  [Route("api/[controller]")]
  [ApiController]
  public class BooksController : ControllerBase
  {
    /// <summary>
    /// IMediator
    /// </summary>
    private readonly IMediator _mediator;

    private readonly DataContext _context;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="mediator">mediator</param>
    /// <param name="context">context</param>
    public BooksController(IMediator mediator, DataContext context)
    {
      _mediator = mediator;
      _context = context;
    }

    ///// <summary>
    ///// Method retrieves all the books.
    ///// GET: /api/books
    ///// </summary>
    ///// <returns>JSON</returns>
    //[HttpGet]
    //public async Task<IActionResult> List()
    //{
    //  var result = await _mediator.Send(new List.Query());

    //  return Ok(result.Select(book => BookViewModels.Default.Compile().Invoke(book)).ToList());
    //}

    /// <summary>
    /// Method retrieves all the books.
    /// GET: /api/books
    /// </summary>
    /// <returns>JSON</returns>
    [HttpGet]
    public async Task<IActionResult> Index()
    {
      var result = await _context.Books.Select(BookViewModels.Default).ToListAsync();

      return Ok(result);
    }

    /// <summary>
    /// Method retrieves the specific book.
    /// GET: /api/books/id
    /// </summary>
    /// <param name="id">id</param>
    /// <returns>JSON</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> Details(Guid id)
    {
      return Ok(await _mediator.Send(new Details.Query { Id = id }));
    }

    ///// <summary>
    ///// Method creates a book.
    ///// POST: /api/books/
    ///// </summary>
    ///// <param name="command">command</param>
    ///// <returns>JSON</returns>
    //[HttpPost]
    //public async Task<IActionResult> Create([FromBody] Create.Command command)
    //{
    //  return Ok(await _mediator.Send(command));
    //}


    /// <summary> Method creates a book.
    /// POST: /api/books/
    /// </summary>
    /// <param name="bookForm">bookForm</param>
    /// <returns>JSON</returns>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] BookFormModel bookForm)
    {
      var book = new Book
      {
        Id = bookForm.Id,
        Title = bookForm.Title,
        Description = bookForm.Description,
        DifficultyId = bookForm.Difficulty,
        Categories = bookForm.Categories
          .Select(guid => _context.Categories.Find(guid))
          .ToList()
      };

      await _context.AddAsync(book);
      await _context.SaveChangesAsync();

      return Ok(BookViewModels.Default.Compile().Invoke(book));
    }

    /// <summary>
    /// Method updates the book.
    /// PUT: /api/books/id
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="command">command</param>
    /// <returns>JSON</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Edit(Guid id, Edit.Command command)
    {
      command.Id = id;
      return Ok(await _mediator.Send(command));
    }

    /// <summary>
    /// Method updates the book.
    /// DELETE: /api/books/id
    /// </summary>
    /// <param name="id">id</param>
    /// <returns>JSON</returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
      return Ok(await _mediator.Send(new Delete.Command { Id = id }));
    }

    /// <summary>
    /// Method fetches all the submissions for the specific id.
    /// GET: api/books/{bookId}/submissions
    /// </summary>
    /// <param name="bookId"></param>
    /// <returns></returns>
    [HttpGet("{bookId}/submissions")]
    public async Task<IActionResult> ListSubmissionsForBook(Guid bookId)
    {
      var result = await _context
        .Submissions
        .Where(submission => submission.BookId.Equals(bookId))
        .ToListAsync();

      return Ok(result);
    }
  }
}
