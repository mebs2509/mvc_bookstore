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
    public class BookStateController : Controller
    {
        private BookstoreDbContext db = new BookstoreDbContext();

        // GET: BookState
        public ActionResult Index()
        {
            return View(db.BookStates.ToList());
        }

        // GET: BookState/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookState bookState = db.BookStates.Find(id);
            if (bookState == null)
            {
                return HttpNotFound();
            }
            return View(bookState);
        }

        // GET: BookState/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookState/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookStateId,Description")] BookState bookState)
        {
            if (ModelState.IsValid)
            {
                db.BookStates.Add(bookState);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookState);
        }

        // GET: BookState/Edit/5
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookState bookState = db.BookStates.Find(id);
            if (bookState == null)
            {
                return HttpNotFound();
            }
            return View(bookState);
        }

        // POST: BookState/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookStateId,Description")] BookState bookState)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookState).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookState);
        }

        // GET: BookState/Delete/5
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookState bookState = db.BookStates.Find(id);
            if (bookState == null)
            {
                return HttpNotFound();
            }
            return View(bookState);
        }

        // POST: BookState/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            BookState bookState = db.BookStates.Find(id);
            db.BookStates.Remove(bookState);
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
