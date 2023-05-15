﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DALs;
using Interfaces;

namespace Factory
{
    public class WedstrijdFactory : IWedstrijdFactory
    {
        public IWedstrijd CreateWedstrijd()
        {
            return new WedstrijdDAL();
        }
    }
}
