using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
//using System.Web.Mvc;

namespace Blog.Models
{
    public class PostModel
    {
        public int Id { get; set; }
        
        public DateTime DataDodania { get; set; }
        
        [StringLength(50,ErrorMessage="tytuł może zaiwerać maksymalnie 50 znaków")]
        [DisplayName("Tytuł wpisu")]
        [Required (ErrorMessage = "tytul jest wymagany")]
        public String Tytul { get; set; }
        
        [DisplayName("Treść wpisu")]
        public String Tresc { get; set; }
        
        [DisplayName("Status wpisu")]
        [Required(ErrorMessage="status jest wymagany")]
        public int Status { get; set; }
        
        public DateTime? DataModyfikacji { get; set; }
    }
}