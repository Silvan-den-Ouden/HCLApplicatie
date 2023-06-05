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
            List<FotoModel> fotos = _fotoCollection.GetPublicFotos();
            List<TeamModel> teams = _teamCollection.GetTeams();

            GalerijViewModel galerijViewModel = new GalerijViewModel(fotos, teams);

            return View(galerijViewModel);
        }

        public IActionResult Foto(int ID)
        {
            FotoModel foto = _fotoCollection.GetFotoWithID(ID);
            AccountModel account = _accountCollection.GetAccountWithID(foto.Account_ID);
            TeamModel team = _teamCollection.GetTeamWithID(foto.Team_ID);

            FotoViewModel fotoViewModel = new FotoViewModel(foto, account, team);
            return View(fotoViewModel);
        }

        public IActionResult GetFotos(int team_ID)
        {
            List<FotoModel> fotos = _fotoCollection.GetFotosFromTeam(team_ID);
            List<TeamModel> teams = _teamCollection.GetTeams();

            GalerijViewModel galerijViewModel = new GalerijViewModel(fotos, teams);

            return View("Index", galerijViewModel);
        }

        public string UpdatePublicity(int ID, string publicity)
        {
            _fotoCollection.ChangeFotoPublicity(ID, publicity);
            return publicity;
        }

        public void DeleteFoto(int ID)
        {
            _fotoCollection.DeleteFoto(ID);
        }
    }
}
