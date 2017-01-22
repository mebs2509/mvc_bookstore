using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bookstore.Context;
using Bookstore.Entities;

namespace Bookstore.MVC.Controllers
{
    public class BookLevelController : Controller
    {
        private BookstoreDbContext db = new BookstoreDbContext();

        // GET: BookLevel
        public ActionResult Index()
        {
            return View(db.BookLevels.ToList());
        }

        // GET: BookLevel/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookLevel bookLevel = db.BookLevels.Find(id);
            if (bookLevel == null)
            {
                return HttpNotFound();
            }
            return View(bookLevel);
        }

        // GET: BookLevel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookLevel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookLevelId,Description")] BookLevel bookLevel)
        {
            if (ModelState.IsValid)
            {
                db.BookLevels.Add(bookLevel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookLevel);
        }

        // GET: BookLevel/Edit/5
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookLevel bookLevel = db.BookLevels.Find(id);
            if (bookLevel == null)
            {
                return HttpNotFound();
            }
            return View(bookLevel);
        }

        // POST: BookLevel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookLevelId,Description")] BookLevel bookLevel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookLevel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookLevel);
        }

        // GET: BookLevel/Delete/5
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookLevel bookLevel = db.BookLevels.Find(id);
            if (bookLevel == null)
            {
                return HttpNotFound();
            }
            return View(bookLevel);
        }

        // POST: BookLevel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            BookLevel bookLevel = db.BookLevels.Find(id);
            db.BookLevels.Remove(bookLevel);
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
