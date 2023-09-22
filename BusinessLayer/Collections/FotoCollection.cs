using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Models;
using DataAccessLayer.DALs;

namespace BusinessLayer.Collections
{
    public class FotoCollection
    {
        private readonly FotoDAL _fotoDAL = new FotoDAL();

        public List<FotoModel> GetFotos()
        {
            List<FotoModel> fotoModels = new List<FotoModel>();

            foreach (var fotoDTO in _fotoDAL.GetFotoDTOs())
            {
                FotoModel f = new FotoModel()
                {
                    ID = fotoDTO.ID,
                    Account_ID = fotoDTO.Account_ID,
                    Team_ID = fotoDTO.Team_ID,
                    Public = fotoDTO.Public,
                    URL = fotoDTO.URL,
                };
                fotoModels.Add(f);
            }
            return fotoModels;
        }

        public List<FotoModel> GetPublicFotos()
        {
            List<FotoModel> fotoModels = new List<FotoModel>();

            foreach (var fotoDTO in _fotoDAL.GetPublicFotos())
            {
                FotoModel f = new FotoModel()
                {
                    ID = fotoDTO.ID,
                    Account_ID = fotoDTO.Account_ID,
                    Team_ID = fotoDTO.Team_ID,
                    Public = fotoDTO.Public,
                    URL = fotoDTO.URL,
                };
                fotoModels.Add(f);
            }
            return fotoModels;
        }

        public List<FotoModel> GetFotosFromTeam(int team_ID)
        {
            List<FotoModel> fotoModels = new List<FotoModel>();

            foreach (var fotoDTO in _fotoDAL.GetFotosFromTeam(team_ID))
            {
                FotoModel f = new FotoModel()
                {
                    ID = fotoDTO.ID,
                    Account_ID = fotoDTO.Account_ID,
                    Team_ID = fotoDTO.Team_ID,
                    Public = fotoDTO.Public,
                    URL = fotoDTO.URL,
                };
                fotoModels.Add(f);
            }
            return fotoModels;
        }

        public FotoModel GetFotoWithID(int ID)
        {
            var fotoDTO = _fotoDAL.GetFotoWithID(ID);
            FotoModel fotoModel = new FotoModel()
            {
                ID = fotoDTO.ID,
                Account_ID = fotoDTO.Account_ID,
                Team_ID = fotoDTO.Team_ID,
                Public = fotoDTO.Public,
                URL = fotoDTO.URL,
            };

            return fotoModel;
        }

        public void ChangeFotoPublicity(int ID, string publicity)
        {
            if(publicity == "Public")
            {
                _fotoDAL.ChangeFotoToPublic(ID);
            } 
            if(publicity == "Private")
            {
                _fotoDAL.ChangeFotoToPrivate(ID);
            }
        }

        public void DeleteFoto(int ID)
        {
            _fotoDAL.DeleteFoto(ID);
        }

        public void UploadFoto(int account_ID, int team_ID, string publicity, string url)
        {
            _fotoDAL.UploadFoto(account_ID, team_ID, publicity, url);
        }
    }
}
