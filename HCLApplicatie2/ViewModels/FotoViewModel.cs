using BusinessLayer.Models;

namespace HCLApplicatie2.ViewModels
{
    public class FotoViewModel
    {
        public Foto Foto { get; set; }

        public Account Account { get; set; }

        public FotoViewModel(Foto foto, Account account) {
            Foto = foto;
            Account = account;
        }
    }
}
