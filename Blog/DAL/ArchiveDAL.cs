using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.DAL
{
    public interface IArchive
    {
        List<Models.ArchiveModel> GetArchive();
    }

    public class ArchiveDAL:IArchive
    {
        public List<Models.ArchiveModel> GetArchive()
        {
            using(LinqTodbBlogDataContext db = new LinqTodbBlogDataContext())
            {
                try
                {
                    var archive = from a in db.Archiwums
                                  select new Models.ArchiveModel
                                  {
                                      count=(a.ilosc==null)?0:(int)a.ilosc,
                                      month=(a.miesiac==null)?0:(int)a.miesiac,
                                      year=(a.rok==null)?0:(int)a.rok
                                  };
                    return archive.ToList();    
                }
                catch(Exception)
                { throw new Exception("Wystąpił błąd podczas tworzenia listy archiwum");}
            }
        }
    }
}