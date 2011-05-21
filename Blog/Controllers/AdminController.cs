using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Blog.Models;

namespace Blog.Controllers
{
    public class AdminController : Controller
    {
        DAL.IPostTag _PostTag;
        DAL.IPost _posty;
        DAL.ITag _tagi;
        DAL.IKomentarz _komentarze;


        public AdminController()
        {
            _PostTag = new DAL.PostTagDAL();
            _posty = new DAL.PostDAL();
            _tagi = new DAL.TagDAL();
            _komentarze = new DAL.KomentarzDAL();
        }

        #region admin/index
        //TODO: admin/index-get
        // GET: /Admin/
        [Authorize(Roles = "Administracja")]
        public ActionResult Index()
        {
            return View();
        }
        #endregion

        #region admin/create
        // GET: /Admin/Create
        [Authorize(Roles = "Administracja")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Admin/Create
        [HttpPost]
        [Authorize(Roles = "Administracja")]
        public ActionResult Create(Models.PostTagModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.Id = _PostTag.dodajPost(model);
                    if (model.Id == 0)
                    {
                        /*dodanie wpisu nie powiodło się*/
                        ViewData["result"] = "Dodanie nowego wpisu nie powiodło się. Spróbuj ponownie, jeśli problem będzie się powtarzać skontaktuj się z administratorem.";
                        return View(model);
                    }
                }
                else
                {
                    return View(model);
                }

                /*po prawidłowym wykonaniu:*/
                return RedirectToAction("Details", "Post", new { model.Id }); //Można pokombinowac żeby przejść do Post/Details/id< 
            }
            catch (Exception e)
            {
                ViewData["result"] = e.Message.ToString();
                return View(model);
            }
        }
        #endregion

        #region admin/edit
        // GET: /Admin/Edit/5
        [Authorize(Roles = "Administracja")]
        public ActionResult Edit(int id)
        {
            PostModel post = _posty.PobierzPost(id);
            TagModel tagi = _tagi.PobierzTagPosta(post.Id);

            if (post == null)
                return RedirectToAction("Index", "Home");//no such post
            else
            {
                if (tagi == null)
                    tagi = new TagModel { IdPosta = id, Desc = "", Keywords = "" };
                ViewData["post"] = post;
                ViewData["tagi"] = tagi;
            }

            return View();
        }

        // POST: /Admin/Edit/5
        [HttpPost]
        [Authorize(Roles = "Administracja")]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                string tytul = collection["Tytul"];
                string tresc = collection["Tresc"];
                int status = Int32.Parse(collection["Status"]);
                string tagi = collection["Tagi"];
                string opis = collection["Opis"];

                _posty.EdytujPost(id, tytul, tresc, status, tagi, opis);

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region admin/delete
        // GET: /Admin/Delete/5
        [Authorize(Roles = "Administracja")]
        public ActionResult Delete(int id)
        {
            try
            {
                _PostTag.usunPost(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
        #endregion

        #region admin/deletecoment
        // GET: /Komentarz/Delete/5
        [Authorize(Roles = "Administracja")]
        public ActionResult DeleteComment(int id, int idPost)
        {
            try
            {
                _komentarze.UsunKomentarz(id);
                return RedirectToAction("Details", "Post", new { id = idPost });
            }
            catch
            {
                return RedirectToAction("Details","Post",new{id=idPost});
            }
        }
        #endregion
    }
}
