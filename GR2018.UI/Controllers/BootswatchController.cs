using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GR2018.UI.Controllers
{
    public class BootswatchController : Controller
    {
        // GET: Bootswatch
        public ActionResult Index()
        {
            return View();
        }

        // GET: Bootswatch/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Bootswatch/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bootswatch/Create
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

        // GET: Bootswatch/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Bootswatch/Edit/5
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

        // GET: Bootswatch/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Bootswatch/Delete/5
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
