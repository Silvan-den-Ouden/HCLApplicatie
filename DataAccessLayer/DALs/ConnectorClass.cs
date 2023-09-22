using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DataAccessLayer
{
    internal class ConnectorClass
    {
        private static readonly string constring = "Server=127.0.0.1,3306;Database=hcldatabase;Uid=root;";

        public static MySqlConnection MakeConnection()
        {
            return new MySqlConnection(constring);
        }

    }
}   
