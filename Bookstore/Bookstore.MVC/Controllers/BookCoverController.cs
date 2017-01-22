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
    public class BookCoverController : Controller
    {
        private BookstoreDbContext db = new BookstoreDbContext();

        // GET: BookCover
        public ActionResult Index()
        {
            return View(db.BookCovers.ToList());
        }

        // GET: BookCover/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookCover bookCover = db.BookCovers.Find(id);
            if (bookCover == null)
            {
                return HttpNotFound();
            }
            return View(bookCover);
        }

        // GET: BookCover/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookCover/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookCoverId,Description")] BookCover bookCover)
        {
            if (ModelState.IsValid)
            {
                db.BookCovers.Add(bookCover);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookCover);
        }

        // GET: BookCover/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookCover bookCover = db.BookCovers.Find(id);
            if (bookCover == null)
            {
                return HttpNotFound();
            }
            return View(bookCover);
        }

        // POST: BookCover/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookCoverId,Description")] BookCover bookCover)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookCover).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookCover);
        }

        // GET: BookCover/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookCover bookCover = db.BookCovers.Find(id);
            if (bookCover == null)
            {
                return HttpNotFound();
            }
            return View(bookCover);
        }

        // POST: BookCover/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookCover bookCover = db.BookCovers.Find(id);
            db.BookCovers.Remove(bookCover);
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
