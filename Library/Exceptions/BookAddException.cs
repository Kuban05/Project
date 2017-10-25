using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Exceptions
{
    public class BookAddException : Exception
    {
        public BookAddException(string message) : base(message)
        {
        }
    }
}