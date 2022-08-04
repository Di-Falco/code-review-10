using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Mob.Models;
using System.Collections.Generic;
using System.Linq;

namespace Mob.Controllers
{
  public class CriminalsController : Controller
  {
    private readonly MobContext _db;

    public CriminalsController(MobContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Criminal> model = _db.Criminals.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Criminal criminal)
    {
      _db.Criminals.Add(criminal);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisCriminal = _db.Criminals
          .Include(criminal => criminal.Jobs)
          .ThenInclude(join => join.Job)
          .FirstOrDefault(criminal => criminal.CriminalId == id);
      return View(thisCriminal);
      
    }
    
    public ActionResult Edit(int id)
    {
      var thisCriminal = _db.Criminals.FirstOrDefault(criminal => criminal.CriminalId == id);
      return View(thisCriminal);
    }

    [HttpPost]
    public ActionResult Edit(Criminal criminal)
    {
      _db.Entry(criminal).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisCriminal = _db.Criminals.FirstOrDefault(criminal => criminal.CriminalId == id);
      return View(thisCriminal);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisCriminal = _db.Criminals.FirstOrDefault(criminal => criminal.CriminalId == id);
      _db.Criminals.Remove(thisCriminal);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}