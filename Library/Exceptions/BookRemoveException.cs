using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Exceptions
{
    public class BookRemoveException : Exception
    {
        public BookRemoveException(string message) : base(message)
        {
        }
    }
}