using Library.DAL;
using Library.Formatters;
using Library.Models;
using Library.Services;
using Library.ViewModels;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class BookController : Controller
    {
        private BookService books = new BookService();

        private LibraryDbContext ctx = new LibraryDbContext();

        private AddBookWithCategoryViewModel vm = new AddBookWithCategoryViewModel(); 

        //This method returns all books and can be sorted by year or title 
        [HttpGet]
        public ActionResult GetAllBooks(string sort)
        {
            ViewBag.YearSortParm = string.IsNullOrEmpty(sort) ? "year" : "";
            ViewBag.TitleSortParm = sort == "title" ? "title_desc" : "title";
            
            var model = books.GetAll();
            
            switch (sort)
            {
                case "year":
                    model = model.OrderBy(y => y.Year).ToList();
                    break;
                case "title":
                    model = model.OrderBy(y => y.Title).ToList();
                    break;
                case "title_desc":
                    model = model.OrderByDescending(y => y.Title).ToList();
                    break;
                default:
                    model = model.OrderByDescending(y => y.Year).ToList();
                    break;
            }

            return View(model.ToList());
        }

        //This action returns details selected book
        [HttpGet]
        public ActionResult Get(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = books.GetById(id);

            return View(model);
        }

        //Here returns form with fields to fill
        public ActionResult Post()
        {
            AddBookWithCategoryViewModel category = new AddBookWithCategoryViewModel()
            {
                Categories = ctx.Categories.Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() })
            };

            return View(category);
        }

        //Here save data to database
        [HttpPost]
        public ActionResult Post([Bind(Include = "Id,Title,Description,Year,Author,CategoryId")]Book book)
        {
            if (ModelState.IsValid)
            {
                books.AddNewBook(book);

                return RedirectToAction("GetAllBooks");
            }

            return View(book);
        }

        //Method returns view with form to edit
        public ActionResult Put(int id)
        {
            var model = books.GetById(id);

            return View(model);
        }

        //Here save changes
        [HttpPost]
        public ActionResult Put([Bind(Include ="Id,Title,Description,Year,Author,CategoryId")]Book book)
        {
            if (ModelState.IsValid)
            {
                books.UpdateBook(book);

                return RedirectToAction("GetAllBooks");
            }
                return View(book);
        }

        //Action get id and returns view 
        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = books.GetById(id);

            if(model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        //Here is a confirmed delete from database
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            books.RemoveBook(id);

            //Here i tried write to file but i didint have access to path(if you want check file with name ListBooksFormatter in folder Formatters)
            //var model = ctx.Books.Where(b => b.Id == id).ToList();
            //ListBooksFormatters stream = new ListBooksFormatters();
            //stream.WriteToFile(model);

            return RedirectToAction("GetAllBooks");
        }
    }
}