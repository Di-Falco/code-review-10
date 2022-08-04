using Microsoft.AspNetCore.Mvc;

namespace Mob.Controllers
{
  public class HomeController : Controller
  {

    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }

  }
}