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

        #region komentarz/create
        // GET: /Komentarz/Create

        public ActionResult Create(int id)
        {
            ViewData["idPosta"] = id;
            return View();
        }

        // POST: /Komentarz/Create

        [HttpPost]
        public ActionResult Create(int id, KomentarzModel model)
        {
            model.IdPosta = id;
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                _komenatrze.DodajKomentarz(model.IdPosta, model.Autor, model.Tresc, model.Status);
                return RedirectToAction("Details", "Post", new { id = id });
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region komentarz/edit
        // TODO: komentarz/edit -get,
        // GET: /Komentarz/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // TODO: komentarz/edit -post
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
        #endregion

        #region komentarz/delete
        //TODO: komentarz/delete -get - jest w adminie
        // GET: /Komentarz/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //TODO: komentarz/delete post - jest w adminie
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
        #endregion 
    }
}
