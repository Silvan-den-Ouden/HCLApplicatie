using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Collections;
using BusinessLayer.Models;
using HCLApplicatie2.ViewModels;

namespace HCLApplicatie2.Controllers
{
    public class WedstrijdenController : Controller
    {
        private readonly WedstrijdCollection _wedstrijdCollection = new WedstrijdCollection();

        // GET: WedstrijdenController
        public ActionResult Index()
        {
            List<Wedstrijd> WedstrijdList = _wedstrijdCollection.GetWedstrijden();

            return View(WedstrijdList);
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
        public IActionResult Create(Wedstrijd wedstrijd)
        {
            try
            {
                _wedstrijdCollection.CreateWedstrijd(wedstrijd);

                return View();
            }
            catch
            {
                return View();
            }
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
