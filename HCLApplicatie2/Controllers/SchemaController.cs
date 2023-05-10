using BusinessLayer.Collections;
using BusinessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace HCLApplicatie2.Controllers
{
    public class SchemaController : Controller
    {
        public IActionResult Index()
        {
            List<ProgrammaModel> ProgrammaModels = ProgrammaCollection.GetProgramma();
            
            return View(ProgrammaModels);
        }

        public IActionResult Update(int ID)
        {
            ProgrammaModel programmaModel = ProgrammaCollection.GetProgrammaWithID(ID);
            return View(programmaModel);
        }

        [HttpPost]
        public IActionResult Update(ProgrammaModel programma)
        {
            try
            {   
                ProgrammaCollection.UpdateProgramma(programma.ID, programma.ThuisTeam, programma.UitTeam, programma.DatumTijd);

                return View(programma);
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Delete(int ID)
        {
            ProgrammaModel programmaModel = ProgrammaCollection.GetProgrammaWithID(ID);
            return View(programmaModel);
        }

        [HttpPost]
        public IActionResult Delete(ProgrammaModel programma)
        {
            try
            {
                ProgrammaCollection.DeleteProgramma(programma.ID);

                return View(programma);
            }
            catch
            {
                return View();
            }
        }

        public int FetchData(int ID)
        {
            return ID; 
        }
    }
}
