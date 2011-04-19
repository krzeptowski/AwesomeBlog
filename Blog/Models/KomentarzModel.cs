using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class KomentarzModel
    {
        public int Id { get; set; }
        public int IdPosta { get; set; }
        public string Tresc { get; set; }
        public string Autor { get; set; }
        public DateTime DataDodania { get; set; }
        public int Status { get; set; }
    }
}