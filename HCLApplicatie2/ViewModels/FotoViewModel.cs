using BusinessLayer.Models;

namespace HCLApplicatie2.ViewModels
{
    public class FotoViewModel
    {
        public FotoModel Foto { get; set; }

        public AccountModel Account { get; set; }

        public FotoViewModel(FotoModel foto, AccountModel account) {
            Foto = foto;
            Account = account;
        }
    }
}
