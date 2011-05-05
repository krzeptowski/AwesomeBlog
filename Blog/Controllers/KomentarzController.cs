using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Blog.DAL;
using Blog.Models;

namespace Blog.Controllers
{
    public class KomentarzController : Controller
    {
        IKomentarz _komenatrze;

        public KomentarzController()
        {
            _komenatrze = new KomentarzDAL();
        }
        //
        // GET: /Komentarz/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Komentarz/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Komentarz/Create

        public ActionResult Create(int id)
        {
            ViewData["idPosta"] = id;
            return View();
        }

        //
        // POST: /Komentarz/Create

        //[HttpPost]
        //public ActionResult Create(int id, KomentarzModel model)
        //{
        //    model.IdPosta = id;
        //    if (!ModelState.IsValid)
        //    {
        //        TempData["new_comm_model"] = model;
        //        return RedirectToAction("Details", "Post", new { id = id });
        //        //return View(model);
        //    }

        //    try
        //    {
        //        _komenatrze.DodajKomentarz(model.IdPosta, model.Autor, model.Tresc, model.Status);
        //        return RedirectToAction("Details", "Post", new { id = id });
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        [HttpPost]
        public ActionResult Create(KomentarzModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["new_comm_model"] = model;
                return RedirectToAction("Details", "Post", new { id = model.IdPosta });
                //return View(model);
            }

            try
            {
                _komenatrze.DodajKomentarz(model.IdPosta, model.Autor, model.Tresc, model.Status);
                return RedirectToAction("Details", "Post", new { id = model.IdPosta });
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Komentarz/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Komentarz/Edit/5

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
        // GET: /Komentarz/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Komentarz/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
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
    }
}
