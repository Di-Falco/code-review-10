using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Factory.Models;

namespace Factory.Controllers
{
  public class EngineersController : Controller
  {
    private readonly FactoryContext _db;

    public EngineersController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Engineer> model = _db.Engineers.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.Engineers = _db.Engineers.ToList();
      return View();
    }

    [HttpPost]
    public ActionResult Create(Engineer engineer)
    {
      _db.Engineers.Add(engineer);
      _db.SaveChanges();
      return Redirect(Request.Headers["Referer"].ToString());
    }

    public ActionResult Details(int id)
    {
      var thisEngineer = _db.Engineers
          // .Include(engineer => engineer.Machines)
          // .ThenInclude(join => join.Machine)
          .FirstOrDefault(engineer => engineer.EngineerId == id);
      return View(thisEngineer);
      
    }
    
    public ActionResult Edit(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
      return View(thisEngineer);
    }

    [HttpPost]
    public ActionResult Edit(Engineer engineer)
    {
      _db.Entry(engineer).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddMachine(int id)
    {
        var thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
        ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
        return View(thisEngineer);
    }

    [HttpPost]
    public ActionResult AddMachine(Engineer engineer, int MachineId)
    {
      if (MachineId != 0 && _db.Repairs.FirstOrDefault(table => table.MachineId == MachineId && table.EngineerId == engineer.EngineerId) == null)
      {
        _db.Repairs.Add(new Repairs() { MachineId = MachineId, EngineerId = engineer.EngineerId});
        _db.SaveChanges();
      }
      return Redirect(Request.Headers["Referer"].ToString());
    }    

    public ActionResult Delete(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
      return View(thisEngineer);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
      _db.Engineers.Remove(thisEngineer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteMachine(int joinId)
    {
      var joinEntry = _db.Repairs.FirstOrDefault(entry => entry.RepairsId == joinId);
      _db.Repairs.Remove(joinEntry);
      _db.SaveChanges();
      return Redirect(Request.Headers["Referer"].ToString());
    }    
  }
}