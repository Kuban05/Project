using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class Book : IEntity
    {
        public Book()
        {
        }

        [Required(ErrorMessage ="Proszę podać tytuł.")]
        [DisplayName("Tytuł")]
        public string Title { get; set; }

        [DisplayName("Opis")]
        public string Description { get; set; }

        [Required(ErrorMessage ="Proszę podać rok.")]
        [Range(1880, int.MaxValue, ErrorMessage = "Proszę wprowadzić rok nie starszy niż 1880.")]
        [DisplayName("Rok")]
        public int Year { get; set; }
        
        [Required(ErrorMessage ="Proszę wprowadzić nazwe autora.")]
        [RegularExpression(@"^([A-ZĄĆĘŁŃÓŚŹŻa-ząćęłńóśźż]+)(\s*)([A-ZĄĆĘŁŃÓŚŹŻa-ząćęłńóśźż]*)(\s*)([A-ZĄĆĘŁŃÓŚŹŻa-ząćęłńóśźż]*)$", ErrorMessage ="Nazwa autora nie może zawierać cyfr ani znaków specjalnych.")]
        [DisplayName("Autor")]
        public string Author { get; set; }

        [DisplayName("Kategoria")]
        public int CategoryId { get; set; }
    }
}