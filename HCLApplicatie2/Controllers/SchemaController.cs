using BusinessLayer.Collections;
using BusinessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace HCLApplicatie2.Controllers
{
    public class SchemaController : Controller
    {
        private readonly ProgrammaCollection _programmaCollection = new();

        public IActionResult Index()
        {
            List<ProgrammaModel> ProgrammaModels = _programmaCollection.GetProgramma();
            
            return View(ProgrammaModels);
        }

        public IActionResult Update(int ID)
        {
            ProgrammaModel programmaModel = _programmaCollection.GetProgrammaWithID(ID);
            return View(programmaModel);
        }

        [HttpPost]
        public IActionResult Update(ProgrammaModel programma)
        {
            try
            {   
                _programmaCollection.UpdateProgramma(programma.ID, programma.ThuisTeam, programma.UitTeam, programma.DatumTijd);

                return View(programma);
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Delete(int ID)
        {
            ProgrammaModel programmaModel = _programmaCollection.GetProgrammaWithID(ID);
            return View(programmaModel);
        }

        [HttpPost]
        public IActionResult Delete(ProgrammaModel programma)
        {
            try
            {
                _programmaCollection.DeleteProgramma(programma.ID);

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
