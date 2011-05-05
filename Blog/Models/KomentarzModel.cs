using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class KomentarzModel
    {
        public int Id { get; set; }
        public int IdPosta { get; set; }

        [DisplayName("Treść komentarza:")]
        [Required(ErrorMessage="Tresc jest wymagana")]
        public string Tresc { get; set; }

        [Required]
        [DisplayName("Imię autora:")]
        [StringLength(50, ErrorMessage="Imie autora musi miec mniej niz 50 znakow")]
        public string Autor { get; set; }

        public DateTime DataDodania { get; set; }
        public int Status { get; set; }
    }
}