using Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class CategoryController : Controller
    {
        private CategoryService categories = new CategoryService();

        // GET: All Category
        //[OutputCache(Duration =1200)]
        public ActionResult Index()
        {
            var model = categories.Get();

            return View(model);
        }
    }
}