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
        //IPost _posty;
        //ITag _tagi;
        IKomentarz _komentarze;

        IPostTag _postTag;
        IUstawienia _ustawienia;

        public HomeController()
        {
            //_posty = new PostDAL();
            //_tagi = new TagDAL();
            _komentarze = new KomentarzDAL();

            _postTag = new PostTagDAL();
            _ustawienia = new UstawieniaServices();
        }

        public ActionResult Index(int? offset)
        {
            ViewData["PostyTagi"] = _postTag.pobierzPorcje(Int16.Parse(_ustawienia.getSettings("ilosc_pozycji_na_strone")),(offset==null)?0:(int)offset);
            ViewData["Komentarze"] = _komentarze.PobierzWszystkie();
            return View();
        }

        //public ActionResult Indexx()
        //{
        //    ViewData["PostyTagi"] = _postTag.pobierzPorcje(Int16.Parse(_ustawienia.getSettings("ilosc_pozycji_na_strone")), 0);
        //    ViewData["Komentarze"] = _komentarze.PobierzWszystkie();
        //    return View();
        //}

        //GET: /Home/Index/6
        //public ActionResult Indexx(int? offset)
        //{
        //    ViewData["PostyTagi"] = _postTag.pobierzPorcje(Int16.Parse(_ustawienia.getSettings("ilosc_pozycji_na_strone")),(offset==null)?0:(int)offset);
        //    ViewData["Komentarze"] = _komentarze.PobierzWszystkie();
        //    return View();
        //}

        //
        // GET: /Post/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }


        // GET: /Post/Create

        public ActionResult Create()
        {
            return View();
        }


        // POST: /Post/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
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
        

        // GET: /Post/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

 
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


        // GET: /Post/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }


        // POST: /Post/Delete/5

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
