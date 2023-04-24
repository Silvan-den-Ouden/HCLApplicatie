using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Collections;
using BusinessLayer.Models;
using HCLApplicatie2.ViewModels;

namespace HCLApplicatie2.Controllers
{
    public class WedstrijdenController : Controller
    {
        // GET: WedstrijdenController
        public ActionResult Index()
        {
            List<WedstrijdVM> WedstrijdenVM = new();

            foreach (var wedstrijd in WedstrijdCollection.GetWedstrijden())
            {
                WedstrijdVM w = new()
                {
                    ID = wedstrijd.ID,
                    ThuisTeam = wedstrijd.ThuisTeam,
                    ThuisScore = wedstrijd.ThuisScore,
                    UitScore = wedstrijd.UitScore,
                    UitTeam = wedstrijd.UitTeam,
                    Datum = wedstrijd.Datum,
                };
                WedstrijdenVM.Add(w);
            }

            return View(WedstrijdenVM);
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
        public IActionResult Create(WedstrijdVM wedstrijdVM)
        {
            try
            {
                ViewData["test"] = wedstrijdVM.Datum.Date;

                Wedstrijd wedstrijd = new()
                {
                    ID = wedstrijdVM.ID,
                    ThuisTeam = wedstrijdVM.ThuisTeam,
                    ThuisScore = wedstrijdVM.ThuisScore,
                    UitScore = wedstrijdVM.UitScore,
                    UitTeam = wedstrijdVM.UitTeam,
                    Datum = wedstrijdVM.Datum,
                };

                wedstrijd.CreateWedstrijd(wedstrijd);

                return View();
                //return RedirectToAction(nameof(Create));
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
