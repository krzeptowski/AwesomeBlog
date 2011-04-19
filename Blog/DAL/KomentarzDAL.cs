using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Blog.Models;

namespace Blog.DAL
{
    public interface IKomentarz
    {
        List<KomentarzModel> PobierzDlaID(int idPosta);
        List<KomentarzModel> PobierzWszystkie();
        int PobierzIloscDlaID(int idPosta);
    }

    public class KomentarzDAL : IKomentarz
    {
        #region IKomentarz Members

        public int PobierzIloscDlaID(int idPosta)
        {

            using (LinqTodbBlogDataContext context = new LinqTodbBlogDataContext())
            {
                var c = (from a in context.Komentarzes
                         where a.id_posta == idPosta
                         select a).Count();
                return c;
            }
        }

        public List<KomentarzModel> PobierzDlaID(int idPosta)
        {
            using (LinqTodbBlogDataContext context = new LinqTodbBlogDataContext())
            {
                var l = from a in context.Komentarzes
                        where a.id_posta == idPosta
                        select new KomentarzModel
                        {
                            Id = a.id,
                            IdPosta = a.id_posta,
                            Tresc = a.tresc,
                            Autor = a.autor,
                            DataDodania = a.data_dodania,
                            Status = a.status
                        };
                return l.ToList();
            }
        }

        public List<KomentarzModel> PobierzWszystkie()
        {
            using (LinqTodbBlogDataContext context = new LinqTodbBlogDataContext())
            {
                var l = from a in context.Komentarzes
                        select new KomentarzModel
                        {
                            Id = a.id,
                            IdPosta = a.id_posta,
                            Tresc = a.tresc,
                            Autor = a.autor,
                            DataDodania = a.data_dodania,
                            Status = a.status
                        };

                return l.ToList();
            }
        }

        #endregion
    }
}