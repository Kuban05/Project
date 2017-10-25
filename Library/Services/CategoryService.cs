using Library.DAL;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Services
{
    public class CategoryService
    {
       private LibraryDbContext ctx = new LibraryDbContext();

        //Service returns list category
        public IEnumerable<Category> Get()
        {
                var model = ctx.Categories.ToList();

                return model;
        }
    }
}