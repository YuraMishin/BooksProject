using System;
using System.Threading.Tasks;
using Application.Books;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="mediator">mediator</param>
    public BooksController(IMediator mediator)
    {
      _mediator = mediator;
    }

    /// <summary>
    /// Method retrieves all the books.
    /// GET: /api/books
    /// </summary>
    /// <returns>JSON</returns>
    [HttpGet]
    public async Task<IActionResult> List()
    {
      return Ok(await _mediator.Send(new List.Query()));
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

    /// <summary>
    /// Method creates a book.
    /// POST: /api/books/
    /// </summary>
    /// <param name="command">command</param>
    /// <returns>JSON</returns>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Create.Command command)
    {
      return Ok(await _mediator.Send(command));
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
  }
}
