using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class AdminController : Controller
    {
        DAL.IPostTag _PostTag;

        public AdminController()
        {
            _PostTag = new DAL.PostTagDAL();
        }

        //TODO
        // GET: /Admin/
        [Authorize(Roles = "Administracja")]
        public ActionResult Index()
        {
            return View();
        }

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
                    if (!_PostTag.dodajPost(model))
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
                return RedirectToAction("Index", "Home"); //Można pokombinowac żeby przejść do Post/Details/id< 
            }
            catch(Exception e)
            {
                ViewData["result"] = e.Message.ToString();
                return View(model);
            }
        }
        
        //TODO
        // GET: /Admin/Edit/5
        [Authorize(Roles = "Administracja")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        //TODO
        // POST: /Admin/Edit/5

        [HttpPost]
        [Authorize(Roles = "Administracja")]
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

        //TODO
        // GET: /Admin/Delete/5
        [Authorize(Roles = "Administracja")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        //TODO
        // POST: /Admin/Delete/5

        [HttpPost]
        [Authorize(Roles = "Administracja")]
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
