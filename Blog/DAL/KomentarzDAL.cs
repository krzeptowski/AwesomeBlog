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
        void DodajKomentarz(int idPosta, string autor, string tresc, int status);
        bool UsunKomentarz(int id);
        void UsunKomentarzeDlaPosta(int idPosta);
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

        public void DodajKomentarz(int idPosta, string autor, string tresc, int status)
        {
            using (LinqTodbBlogDataContext context = new LinqTodbBlogDataContext())
            {
                Komentarze k = new Komentarze
                {
                   id_posta = idPosta,
                   autor = autor,
                   tresc = tresc,
                   status = status,
                   data_dodania = DateTime.Now
                };

                context.Komentarzes.InsertOnSubmit(k);
                context.SubmitChanges();
            }
        }

        public bool UsunKomentarz(int id)
        {
            using (LinqTodbBlogDataContext context = new LinqTodbBlogDataContext())
            {
                try
                {
                    Komentarze kom = context.Komentarzes.Single(k => k.id == id);

                    context.Komentarzes.DeleteOnSubmit(kom);
                    context.SubmitChanges();
                }
                catch (InvalidOperationException ex)
                {
                    return false;
                }
                return true;
            }
        }

        public void UsunKomentarzeDlaPosta(int idPosta)
        {
            using (LinqTodbBlogDataContext context = new LinqTodbBlogDataContext())
            {
                var komentarze = from a in context.Komentarzes
                                 where a.id_posta == idPosta
                                 select a;

                context.Komentarzes.DeleteAllOnSubmit(komentarze);
                context.SubmitChanges();
            }
        }

        #endregion
    }
}