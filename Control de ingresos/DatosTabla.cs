using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Control_de_ingresos
{
    public class DatosTabla<T>
    {
        public static void AgregarObjeto(T objeto)
        {
            string nombreTabla = ObtenerTabla(typeof(T));

            AccesoDatos conexion = new AccesoDatos();
            conexion.conexion.Open();

            conexion.comando = new SqlCommand();
            conexion.comando.Connection = conexion.conexion;
        }

        private static string ObtenerTabla(Type tipo)
        {
            string tabla = null;

            if (tipo is Arroz)
            {
                tabla = "Arroz";
            }
            else if (tipo is Gaseosa)
            {
                tabla = "Gaseosa";
            }
            else if (tipo is Milanesas)
            {
                tabla = "Milanesas";
            }
            else
            {
                tabla = "GaseosaPorMayor";
            }


            return tabla;
        }
    }
}
