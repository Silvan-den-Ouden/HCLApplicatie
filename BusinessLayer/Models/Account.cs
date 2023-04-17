using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCLApplicatie2.Models
{
    public class Account
    {
        public int ID { get; set; }
        public string Naam { get; set; }
        public string Email { get; set; }
        public string Wachtwoord { get; set; }
        public string Team { get; set; }
        public string Rol { get; set; }

        public Account(){ }
    }
}
