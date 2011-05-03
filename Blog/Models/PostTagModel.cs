using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Blog.Models
{
    public class PostTagModel:PostModel
    {
        //public int Id { get; set; }
        //public DateTime DataDodania { get; set; }
        //[Required(ErrorMessage = "Tytul jest wymagany.")]
        //public String Tytul { get; set; }
        //public String Tresc { get; set; }
        //public int Status { get; set; }
        //public DateTime? DataModyfikacji { get; set; }
        
        //public int IdPosta { get; set; } - już jest w PostModel

        [DisplayName("Słowa kluczowe")]
        public string Keywords { get; set; }

        [DisplayName("Skrócony opis")]
        public string Desc { get; set; }
    }
}