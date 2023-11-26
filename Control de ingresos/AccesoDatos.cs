using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace Control_de_ingresos
{
    public class AccesoDatos
    {
        private SqlConnection conexion;
        private static string cadena_conexion;

        static AccesoDatos()
        {

        }
    }
}
