using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 
using System.Web.Mvc;

using Blog.DAL;
using Blog.Models;

//TODO: Zrobic zabezpieczenie przed wywolaniem posta ktory nie istnieje!
//TODO: Zrobic walidacje do formularzy (problem -> modele)
//TODO: Poprawic redirecty

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

                int id = _posty.DodajPost(tytul, tresc, status, tagi, opis);

                return RedirectToAction("Details", "Post", new { id = id });
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

            if (post == null)
            {
                ViewData["error"] = "Nie ma takiego postu!";
                return RedirectToAction("Index", "Post");
            }

            if (tagi != null)
                ViewData["tagi"] = tagi;
            else
                ViewData["tagi"] = "";


            ViewData["post"] = post;
            
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
                return RedirectToAction("../Home/Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
