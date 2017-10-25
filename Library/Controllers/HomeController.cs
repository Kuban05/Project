using Library.DAL;
using Library.Models;
using Library.Services;
using Library.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class HomeController : Controller
    {
        private BookService books = new BookService();

        private LibraryDbContext ctx = new LibraryDbContext();
        
        //Method returns main site
        public ActionResult Index()
        {
            return View();
        }

        //Method returns partial view with asynchronous search
        public ActionResult GetTitleByFilter(string search = null)
        {
            List<Category> model = new List<Category>();

            if (!string.IsNullOrEmpty(search))
            {
                model = books.Searching(search);
            }
            else
            {
                model = ctx.Categories.ToList();
            }

            return PartialView(model);
        }

        //Method returns view about contact
        public ActionResult Contact()
        {
            ViewBag.Message = "Adres:";

            return View();
        }

        //Method returns information about site
        public ActionResult About()
        {
            return View();
        }
    }
}
