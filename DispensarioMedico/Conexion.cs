using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace DispensarioMedico
{
    public static class Conexion
    {
        public readonly static string ConectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DispensarioMedicoLocal"].ConnectionString;        
    }

}
