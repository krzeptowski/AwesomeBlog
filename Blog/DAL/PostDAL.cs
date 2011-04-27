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

        

        #endregion
    }
}