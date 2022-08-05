using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Factory.Models;

namespace Factory.Controllers
{
  public class HomeController : Controller
  {
    private readonly FactoryContext _db;

    public HomeController(FactoryContext db)
    {
      _db = db;
    }

    [HttpGet("/")]
    public ActionResult Index()
    {
      (List<Machine> machines, List<Engineer> engineers) model = (_db.Machines.ToList(), _db.Engineers.ToList());
      return View(model);
    }
  }
}