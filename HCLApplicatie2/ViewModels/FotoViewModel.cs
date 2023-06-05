using BusinessLayer.Models;

namespace HCLApplicatie2.ViewModels
{
    public class FotoViewModel
    {
        public FotoModel Foto { get; set; }

        public AccountModel Account { get; set; }
        public TeamModel Team { get; set; }

        public FotoViewModel(FotoModel foto, AccountModel account, TeamModel team)
        {
            Foto = foto;
            Account = account;
            Team = team;
        }
    }
}
