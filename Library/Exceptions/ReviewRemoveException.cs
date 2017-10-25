using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Exceptions
{
    public class ReviewRemoveException : Exception
    {
        public ReviewRemoveException(string message) : base(message)
        {
        }
    }
}