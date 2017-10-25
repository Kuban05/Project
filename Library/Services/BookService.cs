using Library.DAL;
using Library.Exceptions;
using Library.Models;
using Library.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Services
{
    public class BookService
    { 
        LibraryDbContext ctx = new LibraryDbContext();

        //Service returns list with information about book
        public List<AddBookWithCategoryViewModel> GetAll()
        {
            List<AddBookWithCategoryViewModel> mainList = new List<AddBookWithCategoryViewModel>();

            var query = (from b in ctx.Books
                         join c in ctx.Categories
                         on b.CategoryId equals c.Id
                         select new { b.Title, b.Year, b.Description, b.Author, c.Name, b.Id }).ToList();

            foreach (var item in query)
            {
                AddBookWithCategoryViewModel obj = new AddBookWithCategoryViewModel()
                {
                    BookId=item.Id,
                    Title = item.Title,
                    Description = item.Description,
                    Author = item.Author,
                    Year = item.Year,
                    Category = item.Name
                };

                mainList.Add(obj);
            }

            return mainList;
        }

        //Service returns details selected book
        public Book GetById(int? id)
        {
            return ctx.Books.Where(b => b.Id == id).FirstOrDefault();
        }

        //Service add book to database
        public void AddNewBook(Book model)
        {
            using (var ctx = new LibraryDbContext())
            {
                try
                {
                    ctx.Books.Add(model);

                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new BookAddException(ex.Message);
                }
            }
        }

        //Service edit current data book and save
        public void UpdateBook(Book book)
        {
                try
                {
                    ctx.Entry(book).State = System.Data.Entity.EntityState.Modified;

                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new BookUpdateException(ex.Message);
                }
        }

        //Service delete book from database
        public void RemoveBook(int id)
        {
            using (var ctx = new LibraryDbContext())
            {
                try
                {
                    var bookId = ctx.Books.Find(id);

                    ctx.Books.Remove(bookId);

                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new BookRemoveException(ex.Message);
                }
            }
        }

        //Service search by name category or title
        public List<Category> Searching(string search)
        {
            var model = ctx.Categories.Where(b => b.Name.Contains(search)).ToList();
            var categoryId = ctx.Books.Where(c => c.Title.Contains(search)).Select(c => c.CategoryId);
            model.AddRange(ctx.Categories.Where(c => categoryId.Contains(c.Id)));
            model.Distinct();

            return model;
        }
    }
}