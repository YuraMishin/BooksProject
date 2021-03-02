using System.Threading.Tasks;
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
  }
}
