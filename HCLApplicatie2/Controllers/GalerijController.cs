using BusinessLayer.Collections;
using BusinessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace HCLApplicatie2.Controllers
{
    public class GalerijController : Controller
    {
        public IActionResult Index()
        {
            List<Foto> fotos = FotoCollection.GetFotos();
           
            return View(fotos);
        }
    }
}
