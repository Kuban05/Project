using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Exceptions
{
    public class ReviewAddException : Exception
    {
        public ReviewAddException(string message) : base(message)
        {
        }
    }
}