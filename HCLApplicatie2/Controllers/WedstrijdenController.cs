using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult Create()
        {
            return View();
        }

        // POST: WedstrijdenController/Create
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
