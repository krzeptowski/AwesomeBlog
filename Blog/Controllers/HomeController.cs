using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Blog.DAL;

namespace Blog.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        IPost _posty;
        ITag _tagi;
        IKomentarz _komentarze;

        public HomeController()
        {
            _posty = new PostDAL();
            _tagi = new TagDAL();
            _komentarze = new KomentarzDAL();
        }

        public ActionResult Index()
        {
            ViewData["Posty"] = _posty.PobierzWszystkie();
            ViewData["Tagi"] = _tagi.PobierzWszystkie();
            ViewData["Komentarze"] = _komentarze.PobierzWszystkie();
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
                // TODO: Add insert logic here

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
            return View();
        }

        //
        // POST: /Post/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
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
