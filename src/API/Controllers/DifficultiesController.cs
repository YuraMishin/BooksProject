using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
  /// <summary>
  /// Class DifficultiesController.
  /// Implements Difficulties API
  /// </summary>
  [Route("api/[controller]")]
  [ApiController]
  public class DifficultiesController : ControllerBase
  {
    /// <summary>
    /// DataContext
    /// </summary>
    private readonly DataContext _context;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="context">context</param>
    public DifficultiesController(DataContext context)
    {
      _context = context;
    }

    /// <summary>
    /// Method retrieves all the difficulties.
    /// GET: /api/difficulties
    /// </summary>
    /// <returns>JSON</returns>
    [HttpGet]
    public async Task<IActionResult> Index() => Ok(await _context.Difficulties.ToListAsync());

    /// <summary>
    /// Method creates the difficulty.
    /// POST: /api/difficulties
    /// </summary>
    /// <param name="difficulty">difficulty</param>
    /// <returns>JSON</returns>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Difficulty difficulty)
    {
      await _context.Difficulties.AddAsync(difficulty);
      await _context.SaveChangesAsync();
      return Ok(difficulty);
    }

  }
}
