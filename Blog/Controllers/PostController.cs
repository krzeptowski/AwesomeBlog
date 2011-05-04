using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 
using System.Web.Mvc;
//using System.Web.

using Blog.DAL;
using Blog.Models;

namespace Blog.Controllers
{
    public class PostController : Controller
    {
        //
        // GET: /Post/

        IPost _posty;
        ITag _tagi;
        IKomentarz _komentarze;

        public PostController()
        {
            _posty = new PostDAL();
            _tagi = new TagDAL();
            _komentarze = new KomentarzDAL();
        }

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Post/Details/5

        public ActionResult Details(int id, KomentarzModel model)
        {
            ViewData["Post"] = _posty.PobierzPost(id);
            ViewData["Tagi"] = _tagi.PobierzTagPosta(id);
            ViewData["Komentarze"] = _komentarze.PobierzDlaID(id);

            return View();
        }

        //
        // GET: /Post/Create
        
        [Authorize(Roles="Administracja")]
        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Post/Create

        [HttpPost]
        [Authorize(Roles = "Administracja")]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                string tytul = collection["Tytul"];
                string tresc = collection["Tresc"];
                int status = Convert.ToInt16(Convert.ToBoolean(collection["Status"]));
                string tagi = collection["Tagi"];
                string opis = collection["Opis"];

                _posty.DodajPost(tytul, tresc, status, tagi, opis);

                return RedirectToAction("../Home/Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Post/Edit/5
        
        [Authorize(Roles = "Administracja")]
        public ActionResult Edit(int id)
        {
            PostModel post = _posty.PobierzPost(id);
            TagModel tagi = _tagi.PobierzTagPosta(post.Id);

            if(post == null)
                return RedirectToAction("../Home/Index");//no such post

            if(tagi == null)
                return RedirectToAction("../Home/Index");//no such tag


            ViewData["post"] = post;
            ViewData["tagi"] = tagi;

            return View();
        }

        //
        // POST: /Post/Edit/5
        
        [HttpPost]
        [Authorize(Roles = "Administracja")]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                string tytul = collection["Tytul"];
                string tresc = collection["Tresc"];
                int status = Convert.ToInt16(Convert.ToBoolean(collection["Status"]));
                string tagi = collection["Tagi"];
                string opis = collection["Opis"];

                _posty.EdytujPost(id, tytul, tresc, status, tagi, opis);

                return RedirectToAction("../Home/Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Post/Delete/5

        [Authorize(Roles = "Administracja")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Post/Delete/5

        [HttpPost]
        [Authorize(Roles = "Administracja")]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("../Home/Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
