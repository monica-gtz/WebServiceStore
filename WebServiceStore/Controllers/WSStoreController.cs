using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServiceStore.Controllers
{
    public class WSStoreController : Controller
    {
        // GET: WSStoreController
        public ActionResult Index()
        {
            return View();
        }

        // GET: WSStoreController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WSStoreController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WSStoreController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WSStoreController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WSStoreController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WSStoreController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WSStoreController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
