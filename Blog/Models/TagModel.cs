using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class TagModel
    {
        public int IdPosta { get; set; }
        [Display(Name="Słowa kluczowe")]
        public string Keywords { get; set; }
        [Display(Name="Skrócony opis")]
        public string Desc { get; set; }
    }
}