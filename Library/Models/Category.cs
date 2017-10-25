using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class Category : IEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}