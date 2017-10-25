using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Exceptions
{
    public class BookUpdateException : Exception
    {
        public BookUpdateException(string message) : base(message)
        {
        }
    }
}