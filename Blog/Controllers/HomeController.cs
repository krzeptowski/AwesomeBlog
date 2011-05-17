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

        #region home/index
        public ActionResult Index(int? offset)
        {
            ViewData["PostyTagi"] = _postTag.pobierzPorcje(Int16.Parse(_ustawienia.getSettings("ilosc_pozycji_na_strone")),(offset==null||offset==0)?0:(int)offset-1);
            ViewData["Komentarze"] = _komentarze.PobierzWszystkie();
            //Lista(aktywna strona, liczba postow, elementów w porcji)
            ViewData["Nawigacja"] = new List<int> { (offset == null || offset == 0) ? 1 : (int)offset, _postTag.ileWszystkichAktywnych(), Int16.Parse(_ustawienia.getSettings("ilosc_pozycji_na_strone")) };
            return View();
        }

            #region testowe
            //public ActionResult Indexx(int? offset)
            //{
            //    ViewData["PostyTagi"] = _postTag.pobierzPorcje(Int16.Parse(_ustawienia.getSettings("ilosc_pozycji_na_strone")), (offset == null || offset == 0) ? 0 : (int)offset - 1);
            //    ViewData["Komentarze"] = _komentarze.PobierzWszystkie();
            //    //Lista(aktywna strona, liczba postow, elementów w porcji)
            //    ViewData["Nawigacja"] = new List<int> { (offset == null || offset == 0) ? 1 : (int)offset, _postTag.ileWszystkichAktywnych(), Int16.Parse(_ustawienia.getSettings("ilosc_pozycji_na_strone")) };
            //    return View();
            //}

            //GET: /Home/Index/6
            //public ActionResult Indexx(int? offset)
            //{
            //    ViewData["PostyTagi"] = _postTag.pobierzPorcje(Int16.Parse(_ustawienia.getSettings("ilosc_pozycji_na_strone")),(offset==null)?0:(int)offset);
            //    ViewData["Komentarze"] = _komentarze.PobierzWszystkie();
            //    return View();
            //}
            #endregion

        #endregion

        #region Tag
        public ActionResult Tag(string tag)
        {
            if (String.IsNullOrEmpty(tag))
                return RedirectToAction("Index");

            ViewData["PostyTagi"] = _postTag.pobierzZTagiem(tag);
            ViewData["Komentarze"] = _komentarze.PobierzWszystkie();
            ViewData["Nawigacja"] = new List<int> { 1, 1, 1 }; //dzięki temu nie będzie nawigacji
            return View("Index");
        }
        #endregion
    }
}
