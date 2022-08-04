using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Mob.Models;
using System.Collections.Generic;
using System.Linq;

namespace Mob.Controllers
{
  public class JobsController : Controller
  {
    private readonly MobContext _db;

    public JobsController(MobContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
        return View(_db.Jobs.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.CriminalId = new SelectList(_db.Criminals, "CriminalId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Job job, int CriminalId)
    {
      _db.Jobs.Add(job); // adds new job to database
      _db.SaveChanges(); // save first so new job has an id
      if (CriminalId != 0)
      {
        _db.CriminalJob.Add(new CriminalJob() { CriminalId = CriminalId, JobId = job.JobId });
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
        var thisJob = _db.Jobs
          // .Include(job => job.Criminals) //gathers the CriminalIds associated with the Job object in Job.cs(this.Criminals)
          // .ThenInclude(join => join.Criminal) //Grabs the Criminal object using their Id
          //commented out to see if something breaks
          .FirstOrDefault(job => job.JobId == id);//specifies which job we are working with
        return View(thisJob);
    }

    public ActionResult Edit(int id)
    {
      var thisJob = _db.Jobs.FirstOrDefault(job => job.JobId == id);
      ViewBag.CriminalId = new SelectList(_db.Criminals, "CriminalId", "Name");
      return View(thisJob);
    }

    [HttpPost]
    public ActionResult Edit(Job job, int CriminalId)
    {
      if (CriminalId != 0)
      {
        _db.CriminalJob.Add(new CriminalJob() { CriminalId = CriminalId, JobId = job.JobId });
      }
      _db.Entry(job).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddCriminal(int id)
    {
        var thisJob = _db.Jobs.FirstOrDefault(job => job.JobId == id);
        ViewBag.CriminalId = new SelectList(_db.Criminals, "Criminal", "Name");
        return View(thisJob);
    }

    [HttpPost]
    public ActionResult AddCriminal(Job job, int CriminalId)
    {
        if (CriminalId != 0)
        {
        _db.CriminalJob.Add(new CriminalJob() { CriminalId = CriminalId, JobId = job.JobId});
        _db.SaveChanges();
        }
        return RedirectToAction("Index");
    }
//     public ActionResult Delete(int id)
//     {
//       var thisJob = _db.Jobs.FirstOrDefault(job => job.JobId == id);
//       return View(thisJob);
//     }

//     [HttpPost, ActionName("Delete")]
//     public ActionResult DeleteConfirmed(int id)
//     {
//       var thisJob = _db.Jobs.FirstOrDefault(job => job.JobId == id);
//       _db.Jobs.Remove(thisJob);
//       _db.SaveChanges();
//       return RedirectToAction("Index");
//     }
  }
}