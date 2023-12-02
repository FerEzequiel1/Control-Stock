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


            StringBuilder columnas = new StringBuilder();
            StringBuilder valores = new StringBuilder();

            foreach (PropertyInfo propiedad in typeof(T).GetProperties())
            {
                string nombreColumna = propiedad.Name.ToLower();
                var valor = propiedad.GetValue(objeto, null);

                if (nombreColumna == "marca")
                {
                    valor = valor.ToString();
                }
                columnas.Append($"{nombreColumna}, ");
                valores.Append($"@{nombreColumna}, ");

                conexion.comando.Parameters.AddWithValue($"@{nombreColumna}", valor);
            }

            columnas.Length -= 2; 
            valores.Length -= 2;

            string query = $"INSERT INTO {nombreTabla} ({columnas}) VALUES ({valores})";

            conexion.comando.CommandText = query;
            conexion.comando.ExecuteNonQuery();
            conexion.conexion.Close();

        }

        private static string ObtenerTabla(Type tipo)
        {
            string tabla = null;

            if (tipo.Name == "Arroz")
            {
                tabla = "Arroz";
            }
            else if (tipo.Name == "Gaseosa")
            {
                tabla = "Gaseosa";
            }
            else if (tipo.Name == "Milanesas")
            {
                tabla = "Milanesas";
            }
            else
            {
                tabla = "GaseosaPorMayor";
            }


            return tabla;
        }

        public static List<T> ObtenerTodos<T>()
        {
            List<T> list = new List<T>();

            AccesoDatos conexion = new AccesoDatos();
            conexion.conexion.Open();

            try
            {
                string nombreTabla = ObtenerTabla(typeof(T));
                string query = $"SELECT * FROM {nombreTabla}";
                conexion.comando = new SqlCommand();
                conexion.comando.CommandText= query;
                conexion.comando.Connection = conexion.conexion;
                conexion.lector = conexion.comando.ExecuteReader();

                while(conexion.lector.Read()) 
                {
                    T objeto = Activator.CreateInstance<T>();
                    var properties = typeof(T).GetProperties();

                }

            }
            catch (Exception)
            {

                throw;
            }


            return list;
        }
    }
}
