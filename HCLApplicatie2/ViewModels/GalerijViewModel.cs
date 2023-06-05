using BusinessLayer.Models;

namespace HCLApplicatie2.ViewModels
{
    public class GalerijViewModel
    {
        public List<FotoModel> FotoList { get; set; }
        public List<TeamModel> TeamList{ get; set; }

        public GalerijViewModel( List<FotoModel> fotoList, List<TeamModel> teamList) {
            FotoList = fotoList;
            TeamList = teamList;
        }

    }
}
