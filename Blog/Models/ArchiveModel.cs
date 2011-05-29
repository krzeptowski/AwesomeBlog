using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using System.ComponentModel;
//using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class ArchiveModel
    {
        public int month { get; set; }
        public int year { get; set; }
        public int count { get; set; }
    }
}
