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
    }

    public class TagDAL : ITag
    {
        #region ITag Members

        public TagModel PobierzTagPosta(int id)
        {
            using (LinqTodbBlogDataContext context = new LinqTodbBlogDataContext())
            {
                var tag = context.Tagis.Single(t => t.id_posta == id);
                          return new TagModel
                          {
                              IdPosta = tag.id_posta,
                              Keywords = tag.keywords,
                              Desc = tag.description
                          };
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