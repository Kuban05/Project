using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library.Models;
using Library.Services;
using Library.DAL;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Library.Tests
{
    //Unfortunately none test is positive, any problem is with connection to EF
    [TestClass]
    public class TestsMethods
    {
        private BookService repository = new BookService();

        [TestMethod]
        public void AddBookTest()
        {   
                //Arrange
                Book book = new Book()
                {
                    Id = 1,
                    Title = "Krzyżacy",
                    Description = "Nowa książka.",
                    Year = 1900,
                    Author = "Henryk Sienkiewicz",
                    CategoryId= 1
                };

                //Act
                repository.AddNewBook(book);

            //Assert
            Assert.IsNotNull(repository.GetAll());
            
        }

        [TestMethod]
        public void UpdateBookTest()
        {
            //Arrange
            Book book = new Book()
            {
                Id = 1,
                Title = "Krzyżacy",
                Description = "Nowa książka...",
                Year = 1900,
                Author = "Henryk Sienkiewicz",
                CategoryId = 1
            };

            //Act
            repository.UpdateBook(book);

            //Assert
            Assert.IsNull(repository.GetById(book.Id));
        }

        [TestMethod]
        public void RemoveBookTest()
        {
            //Arrange
            Book book = new Book()
            {
                Id = 1,
                Title = "Krzyżacy",
                Description = "Nowa książka.",
                Year = 1900,
                Author = "Henryk Sienkiewicz",
                CategoryId = 1
            };

            //Act
            repository.RemoveBook(book.Id);

            //Assert
            Assert.IsNull(repository.GetById(book.Id));
        }
    }
}
