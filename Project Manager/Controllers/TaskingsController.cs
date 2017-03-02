using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_Manager.Models;

namespace Project_Manager.Controllers
{
    public class TaskingsController : Controller
    {
        private TestDbContext db = new TestDbContext();

        // GET: Taskings
        public ActionResult Index()
        {
            return View(db.Taskings.ToList());
        }

        // GET: Taskings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tasking tasking = db.Taskings.Find(id);
            if (tasking == null)
            {
                return HttpNotFound();
            }
            return View(tasking);
        }

        // GET: Taskings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Taskings/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name,StartDate,EndDate,Status,User")] Tasking tasking)
        {
            if (ModelState.IsValid)
            {
                db.Taskings.Add(tasking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tasking);
        }

        // GET: Taskings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tasking tasking = db.Taskings.Find(id);
            if (tasking == null)
            {
                return HttpNotFound();
            }
            return View(tasking);
        }

        // POST: Taskings/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,StartDate,EndDate,Status,User")] Tasking tasking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tasking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tasking);
        }

        // GET: Taskings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tasking tasking = db.Taskings.Find(id);
            if (tasking == null)
            {
                return HttpNotFound();
            }
            return View(tasking);
        }

        // POST: Taskings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tasking tasking = db.Taskings.Find(id);
            db.Taskings.Remove(tasking);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
