﻿using System;
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

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Komentarz/Create

        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        int idPosta = Convert.ToInt32(collection["idPosta"]);
        //        string autor = collection["Autor"];
        //        string tresc = collection["Tresc"];

        //        _komenatrze.DodajKomentarz(idPosta, autor, tresc, 0);

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(KomentarzModel model)
        {
            //return RedirectToAction("Details/13", "Post");

            try
            {
                _komenatrze.DodajKomentarz(model.IdPosta, model.Autor, model.Tresc, model.Status);
                return RedirectToAction("Index");
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
                // TODO: Add update logic here
 
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