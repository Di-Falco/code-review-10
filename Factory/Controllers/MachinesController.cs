using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;

namespace Factory.Controllers
{
  public class MachinesController : Controller
  {
    private readonly FactoryContext _db;

    public MachinesController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
        return View(_db.Machines.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Machine machine, int EngineerId)
    {
      _db.Machines.Add(machine); // adds new machine to database
      _db.SaveChanges(); // save first so new machine has an id
      if (EngineerId != 0)
      {
        _db.Repairs.Add(new Repairs() { EngineerId = EngineerId, MachineId = machine.MachineId });
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
        var thisMachine = _db.Machines
          // .Include(machine => machine.Engineers) //gathers the EngineerIds associated with the Machine object in Machine.cs(this.Engineers)
          // .ThenInclude(join => join.Engineer) //Grabs the Engineer object using their Id
          //commented out to see if something breaks
          .FirstOrDefault(machine => machine.MachineId == id);//specifies which machine we are working with
        return View(thisMachine);
    }

    public ActionResult Edit(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
      return View(thisMachine);
    }

    [HttpPost]
    public ActionResult Edit(Machine machine, int EngineerId)
    {
      if (EngineerId != 0)
      {
        _db.Repairs.Add(new Repairs() { EngineerId = EngineerId, MachineId = machine.MachineId });
      }
      _db.Entry(machine).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddEngineer(int id)
    {
        var thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
        ViewBag.EngineerId = new SelectList(_db.Engineers, "Engineer", "Name");
        return View(thisMachine);
    }

    [HttpPost]
    public ActionResult AddEngineer(Machine machine, int EngineerId)
    {
        if (EngineerId != 0)
        {
        _db.Repairs.Add(new Repairs() { EngineerId = EngineerId, MachineId = machine.MachineId});
        _db.SaveChanges();
        }
        return RedirectToAction("Index");
    }
    
    public ActionResult Delete(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
      return View(thisMachine);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
      _db.Machines.Remove(thisMachine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteEngineer(int joinId)//so we can delete a engineer from a machine
    {
      var joinEntry = _db.Repairs.FirstOrDefault(entry => entry.RepairsId == joinId);
      _db.Repairs.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}