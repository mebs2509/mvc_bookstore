using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Bookstore.Context;
using Bookstore.Entities;

namespace Bookstore.MVC.Controllers
{
    public class BookController : Controller
    {
        private BookstoreDbContext db = new BookstoreDbContext();

        // GET: Book
        public ActionResult Index()
        {
            var books = db.Books.Include(b => b.Author).Include(b => b.BookCover).Include(b => b.BookFormat).Include(b => b.BookLevel).Include(b => b.BookState).Include(b => b.Language).Include(b => b.Publisher);
            return View(books.ToList());
        }

        // GET: Book/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);

            book.BookLevel = db.BookLevels.Find(book.BookLevelId);
            book.BookState = db.BookStates.Find(book.BookStateId);
            book.BookFormat = db.BookFormats.Find(book.BookFormatId);
            book.BookCover = db.BookCovers.Find(book.BookCoverId);
            book.Language = db.Languages.Find(book.LanguageId);
            book.Author = db.Authors.Find(book.AuthorId);
            book.Publisher = db.Publishers.Find(book.PublisherId);


            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "Name");
            ViewBag.BookCoverId = new SelectList(db.BookCovers, "BookCoverId", "Description");
            ViewBag.BookFormatId = new SelectList(db.BookFormats, "BookFormatId", "Description");
            ViewBag.BookLevelId = new SelectList(db.BookLevels, "BookLevelId", "Description");
            ViewBag.BookStateId = new SelectList(db.BookStates, "BookStateId", "Description");
            ViewBag.LanguageId = new SelectList(db.Languages, "LanguageId", "Description");
            ViewBag.PublisherId = new SelectList(db.Publishers, "PublisherId", "Name");
            return View();
        }

        // POST: Book/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookId,AuthorId,Title,Description,Price,BookLevelId,BookStateId,PageNumbers,BookCoverId,BookFormatId,PublisherId,LanguageId,ISBN10,ISBB13,Dimensions,Weight,ReviewRate,RankTop100,StockMin,Stock")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "Name", book.AuthorId);
            ViewBag.BookCoverId = new SelectList(db.BookCovers, "BookCoverId", "Description", book.BookCoverId);
            ViewBag.BookFormatId = new SelectList(db.BookFormats, "BookFormatId", "Description", book.BookFormatId);
            ViewBag.BookLevelId = new SelectList(db.BookLevels, "BookLevelId", "Description", book.BookLevelId);
            ViewBag.BookStateId = new SelectList(db.BookStates, "BookStateId", "Description", book.BookStateId);
            ViewBag.LanguageId = new SelectList(db.Languages, "LanguageId", "Description", book.LanguageId);
            ViewBag.PublisherId = new SelectList(db.Publishers, "PublisherId", "Name", book.PublisherId);
            return View(book);
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "Name", book.AuthorId);
            ViewBag.BookCoverId = new SelectList(db.BookCovers, "BookCoverId", "Description", book.BookCoverId);
            ViewBag.BookFormatId = new SelectList(db.BookFormats, "BookFormatId", "Description", book.BookFormatId);
            ViewBag.BookLevelId = new SelectList(db.BookLevels, "BookLevelId", "Description", book.BookLevelId);
            ViewBag.BookStateId = new SelectList(db.BookStates, "BookStateId", "Description", book.BookStateId);
            ViewBag.LanguageId = new SelectList(db.Languages, "LanguageId", "Description", book.LanguageId);
            ViewBag.PublisherId = new SelectList(db.Publishers, "PublisherId", "Name", book.PublisherId);
            return View(book);
        }

        // POST: Book/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookId,AuthorId,Title,Description,Price,BookLevelId,BookStateId,PageNumbers,BookCoverId,BookFormatId,PublisherId,LanguageId,ISBN10,ISBB13,Dimensions,Weight,ReviewRate,RankTop100,StockMin,Stock")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "Name", book.AuthorId);
            ViewBag.BookCoverId = new SelectList(db.BookCovers, "BookCoverId", "Description", book.BookCoverId);
            ViewBag.BookFormatId = new SelectList(db.BookFormats, "BookFormatId", "Description", book.BookFormatId);
            ViewBag.BookLevelId = new SelectList(db.BookLevels, "BookLevelId", "Description", book.BookLevelId);
            ViewBag.BookStateId = new SelectList(db.BookStates, "BookStateId", "Description", book.BookStateId);
            ViewBag.LanguageId = new SelectList(db.Languages, "LanguageId", "Description", book.LanguageId);
            ViewBag.PublisherId = new SelectList(db.Publishers, "PublisherId", "Name", book.PublisherId);
            return View(book);
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
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
