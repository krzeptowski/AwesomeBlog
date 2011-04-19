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

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Post/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Post/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                string tytul = collection["ctl00$MainContent$tbTytul"];
                string tresc = collection["ctl00$MainContent$tbTresc"];
                int status = Convert.ToInt16(collection["ctl00$MainContent$cbStatus"]);
                string tagi = collection["ctl00$MainContent$tbTagi"];

                int postID = _posty.DodajPost(tytul, tresc, status);
                _tagi.DodajTag(postID, tagi, tresc.Substring(0, (tresc.Length > 20) ? 20 : tresc.Length));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Post/Edit/5
 
        public ActionResult Edit(int id)
        {
            PostModel post = _posty.PobierzPost(id);
            TagModel tagi = _tagi.PobierzTagPosta(post.Id);

            ViewData["Tytul"] = post.Tytul;


            return View();
        }

        //
        // POST: /Post/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Post/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Post/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
