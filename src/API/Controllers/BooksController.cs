using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Books;
using Domain;
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
    public async Task<ActionResult<List<Book>>> List()
    {
      return await _mediator.Send(new List.Query());
    }
  }
}
