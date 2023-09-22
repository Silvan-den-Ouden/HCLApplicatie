using BusinessLayer.Models;

namespace HCLApplicatie2.ViewModels
{
    public class UploadViewModel
    {
        public AccountModel Account { get; set; }
        public List<TeamModel> TeamList { get; set; }
        public FotoModel Foto { get; set; }

        public UploadViewModel(AccountModel account, List<TeamModel> teamList, FotoModel foto)
        {
            Account = account;
            TeamList = teamList;
            Foto = foto;
        }
    }
}
