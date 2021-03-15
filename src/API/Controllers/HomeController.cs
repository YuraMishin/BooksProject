using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  /// <summary>
  /// Class HomeController
  /// </summary>
  public class HomeController : Controller
  {
    /// <summary>
    /// Method displays index UI
    /// </summary>
    /// <returns>HTML-page</returns>
    public IActionResult Index()
    {
      return View();
    }
  }
}
