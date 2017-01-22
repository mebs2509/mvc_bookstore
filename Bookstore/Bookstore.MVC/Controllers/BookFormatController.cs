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
    public class BookFormatController : Controller
    {
        private BookstoreDbContext db = new BookstoreDbContext();

        // GET: BookFormat
        public ActionResult Index()
        {
            return View(db.BookFormats.ToList());
        }

        // GET: BookFormat/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookFormat bookFormat = db.BookFormats.Find(id);
            if (bookFormat == null)
            {
                return HttpNotFound();
            }
            return View(bookFormat);
        }

        // GET: BookFormat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookFormat/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookFormatId,Description")] BookFormat bookFormat)
        {
            if (ModelState.IsValid)
            {
                db.BookFormats.Add(bookFormat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookFormat);
        }

        // GET: BookFormat/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookFormat bookFormat = db.BookFormats.Find(id);
            if (bookFormat == null)
            {
                return HttpNotFound();
            }
            return View(bookFormat);
        }

        // POST: BookFormat/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookFormatId,Description")] BookFormat bookFormat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookFormat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookFormat);
        }

        // GET: BookFormat/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookFormat bookFormat = db.BookFormats.Find(id);
            if (bookFormat == null)
            {
                return HttpNotFound();
            }
            return View(bookFormat);
        }

        // POST: BookFormat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookFormat bookFormat = db.BookFormats.Find(id);
            db.BookFormats.Remove(bookFormat);
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
