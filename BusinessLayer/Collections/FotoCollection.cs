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
            List<FotoModel> fotos = new List<FotoModel>();

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
                fotos.Add(f);
            }
            return fotos;
        }

        public FotoModel GetFotoWithID(int ID)
        {
            var fotoDTO = _fotoDAL.GetFotoWithID(ID);
            FotoModel foto = new FotoModel()
            {
                ID = fotoDTO.ID,
                Account_ID = fotoDTO.Account_ID,
                Team_ID = fotoDTO.Team_ID,
                Public = fotoDTO.Public,
                URL = fotoDTO.URL,
            };

            return foto;
        }
    }
}
