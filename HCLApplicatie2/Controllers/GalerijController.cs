using BusinessLayer.Collections;
using BusinessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace HCLApplicatie2.Controllers
{
    public class GalerijController : Controller
    {
        private readonly FotoCollection _fotoCollection = new();

        public IActionResult Index()
        {
            List<Foto> fotos = _fotoCollection.GetFotos();
           
            return View(fotos);
        }
    }
}
