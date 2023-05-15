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

        public List<Foto> GetFotos()
        {
            List<Foto> fotos = new List<Foto>();

            foreach (var foto in _fotoDAL.GetFotoDTOs())
            {
                Foto f = new Foto()
                {
                    ID = foto.ID,
                    URL = foto.URL,
                };
                fotos.Add(f);
            }
            return fotos;
        }
    }
}
