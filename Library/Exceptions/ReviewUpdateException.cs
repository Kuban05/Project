using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Exceptions
{
    public class ReviewUpdateException : Exception
    {
        public ReviewUpdateException(string message) : base(message)
        {
        }
    }
}