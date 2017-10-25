using Library.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace Library.DAL
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext() : base("LibraryDb")
        {
            //Database.SetInitializer<LibraryDbContext>(new DropCreateDatabaseAlways<LibraryDbContext>());
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}