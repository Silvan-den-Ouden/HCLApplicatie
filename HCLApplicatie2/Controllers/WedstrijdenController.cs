using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Collections;
using BusinessLayer.Models;

namespace HCLApplicatie2.Controllers
{
    public class WedstrijdenController : Controller
    {
        // GET: WedstrijdenController
        public ActionResult Index()
        {
            return View();
        }

        // GET: WedstrijdenController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WedstrijdenController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WedstrijdenController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create(string ThuisTeam)
        {
            try
            {
                ViewData["test"] = ThuisTeam;
                //return RedirectToAction(nameof(Create));
            }
            catch
            {
                return View();
            }
            return View();
        }

        // GET: WedstrijdenController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WedstrijdenController/Edit/5
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

        // GET: WedstrijdenController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WedstrijdenController/Delete/5
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
