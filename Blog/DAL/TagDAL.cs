using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Blog.Models;

namespace Blog.DAL
{
    public interface ITag
    {
        TagModel PobierzTagPosta(int id);
        List<TagModel> PobierzWszystkie();
        void DodajTag(int idPosta, string keywords, string desc);
        void EdytujTag(int idPosta, string keywords);
        void UsunTagiPostu(int idPosta);
    }

    public class TagDAL : ITag
    {
        #region ITag Members

        public void UsunTagiPostu(int idPosta)
        {
            using (LinqTodbBlogDataContext db = new LinqTodbBlogDataContext())
            {
                try
                {
                    var lista = from a in db.Tagis where a.id_posta == idPosta select a;
                    db.Tagis.DeleteAllOnSubmit(lista);
                    db.SubmitChanges();
                }
                catch (Exception)
                { throw new Exception("Wystąpił błąd podczas usuwania tagów"); }
            }
        }

        public TagModel PobierzTagPosta(int id)
        {
            using (LinqTodbBlogDataContext context = new LinqTodbBlogDataContext())
            {
                try
                {
                    var tagi = (from a in context.Tagis
                                where a.id_posta == id
                                select new TagModel
                                {
                                    IdPosta = a.id_posta,
                                    Desc = a.description,
                                    Keywords = a.keywords
                                }).Single();
                    //var tag = context.Tagis.Single(t => t.id_posta == id);
                    //return new TagModel
                    //      {
                    //          IdPosta = tag.id_posta,
                    //          Keywords = tag.keywords,
                    //          Desc = tag.description
                    //      };
                    return tagi;
                }
                catch (InvalidOperationException)
                {
                    return null;
                }
                          
            }
        }

        public List<TagModel> PobierzWszystkie()
        {
            using (LinqTodbBlogDataContext context = new LinqTodbBlogDataContext())
            {
                var l = from a in context.Tagis
                        select new TagModel
                        {
                            IdPosta = a.id_posta,
                            Keywords = a.keywords,
                            Desc = a.description
                        };

                return l.ToList();
            }
        }

        public void DodajTag(int idPosta, string keywords, string desc)
        {
            using (LinqTodbBlogDataContext context = new LinqTodbBlogDataContext())
            {
                Tagi t = new Tagi
                {
                    id_posta = idPosta,
                    keywords = keywords,
                    description = desc
                };

                context.Tagis.InsertOnSubmit(t);
                context.SubmitChanges();
            }
        }

        public void EdytujTag(int idPosta, string keywords)
        {
            using (LinqTodbBlogDataContext context = new LinqTodbBlogDataContext())
            {
                var tag = context.Tagis.Single(t => t.id_posta == idPosta);

                tag.keywords = keywords;

                context.SubmitChanges();
            }
        }

        #endregion


    }
}