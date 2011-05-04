using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Blog.Models
{
    public class UstawieniaModel
    {
        [Required(ErrorMessage="To pole jest wymagane")]
        [DisplayName("Identyfikator właściwości")]
        public string key { get; set; }

        [Required(ErrorMessage="To pole jest wymagane")]
        [DisplayName("Wartość właściwości")]
        public string value { get; set; }

        [DisplayName("Opis")]
        public string description { get; set; }
    }
}