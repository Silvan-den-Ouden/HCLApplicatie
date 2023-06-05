using BusinessLayer.Collections;
using BusinessLayer.Models;
using HCLApplicatie2.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HCLApplicatie2.Controllers
{
    public class GalerijController : Controller
    {
        private readonly FotoCollection _fotoCollection = new();
        private readonly AccountCollection _accountCollection = new();
        private readonly TeamCollection _teamCollection = new();

        public IActionResult Index()
        {
            List<FotoModel> fotos = _fotoCollection.GetFotos();
           
            return View(fotos);
        }

        public IActionResult Foto(int ID)
        {
            FotoModel foto = _fotoCollection.GetFotoWithID(ID);
            AccountModel account = _accountCollection.GetAccountWithID(foto.Account_ID);
            TeamModel team = _teamCollection.GetTeamWithID(foto.Team_ID);

            FotoViewModel fotoViewModel = new FotoViewModel(foto, account, team);
            return View(fotoViewModel);
        }

        public string UpdatePublicity(int ID, string publicity)
        {
            _fotoCollection.ChangeFotoPublicity(ID, publicity);
            return publicity;
        }
    }
}
