using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.ViewModels
{
    //ViewModel bind models Category and Book for a display data from 2 tables
    public class AddBookWithCategoryViewModel
    {
        public int BookId { get; set; }

        [Required(ErrorMessage = "Proszę podać tytuł.")]
        [DisplayName("Tytuł")]
        public string Title { get; set; }

        [DisplayName("Opis")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Proszę podać rok.")]
        [Range(1880, int.MaxValue, ErrorMessage = "Proszę wprowadzić rok nie starszy niż 1880.")]
        [DisplayName("Rok")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Proszę wprowadzić nazwe autora.")]
        [RegularExpression(@"^([A-ZĄĆĘŁŃÓŚŹŻa-ząćęłńóśźż]+)(\s*)([A-ZĄĆĘŁŃÓŚŹŻa-ząćęłńóśźż]*)(\s*)([A-ZĄĆĘŁŃÓŚŹŻa-ząćęłńóśźż]*)$", ErrorMessage = "Nazwa autora nie może zawierać cyfr ani znaków specjalnych.")]
        [DisplayName("Autor")]
        public string Author { get; set; }

        [DisplayName("Kategorie")]
        public int CategoryId { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }

        [DisplayName("Kategoria")]
        public string Category { get; set; }
    }
}