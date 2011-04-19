using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class PostModel
    {
        public int Id { get; set; }
        public DateTime DataDodania { get; set; }
        public String Tytul { get; set; }
        public String Tresc { get; set; }
        public int Status { get; set; }
        public DateTime? DataModyfikacji { get; set; }
    }
}