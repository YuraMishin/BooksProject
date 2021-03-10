using System;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
  /// <summary>
  /// Class CategoriesController.
  /// Implements Categories API
  /// </summary>
  [Route("api/[controller]")]
  [ApiController]
  public class CategoriesController : ControllerBase
  {
    /// <summary>
    /// DataContext
    /// </summary>
    private readonly DataContext _context;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="context">context</param>
    public CategoriesController(DataContext context)
    {
      _context = context;
    }

    /// <summary>
    /// Method retrieves all the categories.
    /// GET: /api/categories
    /// </summary>
    /// <returns>JSON</returns>
    [HttpGet]
    public async Task<IActionResult> Index() => Ok(await _context.Categories.ToListAsync());

    /// <summary>
    /// Method creates the category.
    /// POST: /api/categories
    /// </summary>
    /// <param name="category">category</param>
    /// <returns>JSON</returns>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Category category)
    {
      await _context.AddAsync(category);
      await _context.SaveChangesAsync();
      return Ok(category);
    }

    /// <summary>
    /// Method retrieves all the books for the specific category.
    /// GET: /api/categories/{id}/books
    /// </summary>
    /// <param name="id">id</param>
    /// <returns>JSON</returns>
    [HttpGet("{id}/books")]
    public IActionResult ListCategoryBooks(Guid id)
    {
      var books = _context
        .Categories
        .Where(category => category.Id.Equals(id))
        .Include(category => category.Books)
        .Select(category => category.Books).First()
        .ToList();

      return Ok(books);
    }
  }
}
