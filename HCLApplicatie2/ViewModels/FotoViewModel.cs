using BusinessLayer.Models;

namespace HCLApplicatie2.ViewModels
{
    public class FotoViewModel
    {
        public FotoModel Foto { get; set; }

        public Account Account { get; set; }

        public FotoViewModel(FotoModel foto, Account account) {
            Foto = foto;
            Account = account;
        }
    }
}
