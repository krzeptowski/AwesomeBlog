using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Blog.Models;

namespace Blog.DAL
{
    public interface IPost
    {
        PostModel PobierzPost(int id);
        List<PostModel> PobierzWszystkie();
        int DodajPost(string tytul, string tresc, int status);
        int DodajPost(string tytul, string tresc, int status, string tagi, string opis);
        void EdytujPost(int id, string tytul, string tresc, int status);
        void EdytujPost(int id, string tytul, string tresc, int status, string tagi, string opis);
        int WyciagnijIdPosta(string tytul);
    }

    public class PostDAL : IPost
    {
        #region IPost Members

        public void DodajPost(PostModel post)
        {
            throw new NotImplementedException();
        }

        public int DodajPost(string tytul, string tresc, int status)
        {
            using (LinqTodbBlogDataContext context = new LinqTodbBlogDataContext())
            {
                Posty p = new Posty
                {
                    tytul = tytul, 
                    tresc = tresc,
                    status = status,
                    data_dodania = DateTime.Now,
                    data_modyfikacji = DateTime.Now //dodanie postu to jednocześnie ostatnia modyfikacja
                };

                context.Posties.InsertOnSubmit(p);
                context.SubmitChanges();

                return p.id;
            }
        }
        public PostModel PobierzPost(int id)
        {
            using (LinqTodbBlogDataContext context = new LinqTodbBlogDataContext())
            {
                var post = context.Posties.Single(p => p.id == id);
                           return new PostModel
                           {
                               Id = post.id,
                               Tytul = post.tytul,
                               Tresc = post.tresc,
                               DataDodania = post.data_dodania,
                               DataModyfikacji = post.data_modyfikacji,
                               Status = post.status
                           };
            }
        }
        public List<PostModel> PobierzWszystkie()
        {
            using (LinqTodbBlogDataContext context = new LinqTodbBlogDataContext())
            {
                var posty = from a in context.Posties
                            select new PostModel
                            {
                                Id = a.id,
                                DataDodania = a.data_dodania,
                                Tytul = a.tytul,
                                Tresc = a.tresc,
                                Status = a.status,
                                DataModyfikacji = a.data_modyfikacji.Value
                            };
                List<PostModel> l = posty.ToList();
                return l;
            }
        }

        public int DodajPost(string tytul, string tresc, int status, string tagi, string opis)
        {
            using (LinqTodbBlogDataContext context = new LinqTodbBlogDataContext())
            {
                Posty p = new Posty
                {
                    tytul = tytul,
                    tresc = tresc,
                    status = status,
                    data_dodania = DateTime.Now,
                    data_modyfikacji = DateTime.Now,
                };
                context.Posties.InsertOnSubmit(p);
                context.SubmitChanges();

                Tagi t = new Tagi
                {
                    id_posta = p.id,
                    keywords = tagi,
                    description = opis
                };

                context.Tagis.InsertOnSubmit(t);
                context.SubmitChanges();

                return p.id;
            }
        }
        public void EdytujPost(int id, string tytul, string tresc, int status)
        {
            using (LinqTodbBlogDataContext context = new LinqTodbBlogDataContext())
            {
                var post = context.Posties.Single(p => p.id == id);
                post.tytul = tytul;
                post.tresc = tresc;
                post.status = status;
                post.data_modyfikacji = DateTime.Now;

                context.SubmitChanges();
            }
        }
        public void EdytujPost(int id, string tytul, string tresc, int status, string tagi, string opis)
        {
            using (LinqTodbBlogDataContext context = new LinqTodbBlogDataContext())
            {
                var post = context.Posties.Single(p => p.id == id);
                post.tytul = tytul;
                post.tresc = tresc;
                post.status = status;
                post.data_modyfikacji = DateTime.Now;

                var tag = context.Tagis.Single(s => s.id_posta == id);

                tag.keywords = tagi;
                tag.description = opis;

                context.SubmitChanges();
            }
        }

        public int WyciagnijIdPosta(string tytul) // "frenjf_fdejif_fer_73"
        {
            string idS = tytul.Substring(tytul.LastIndexOf("_")+1);
            int id;
            if(!Int32.TryParse(idS,out id))
                throw new Exception("Podany adres zawiera nieprawidłową wartość");
            
            return id;
        }

        #endregion
    }
}