﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;

namespace Interfaces
{
    public interface IWedstrijd
    {
        List<WedstrijdDTO> GetWedstrijdDTOs();
        void CreateWedstrijd(WedstrijdDTO wedstrijdDTO);
    }
}
