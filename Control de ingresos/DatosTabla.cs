using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.PortableExecutable;
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

                    for (int i = 0; i < conexion.lector.FieldCount; i++)
                    {
                        string nombreColumna = conexion.lector.GetName(i);
                        object valor = conexion.lector.GetValue(i);

                        if (nombreColumna == "marca")
                        {
                            string marca = valor.ToString();
                            valor = (EMarca)Enum.Parse(typeof(EMarca), marca);
                        }
                       
                        var property = properties.FirstOrDefault(p => string.Equals(p.Name, nombreColumna, StringComparison.OrdinalIgnoreCase));

                        if (property != null && valor != DBNull.Value)
                        {
                            var convertedValue = Convert.ChangeType(valor, property.PropertyType);
                            property.SetValue(objeto, convertedValue);
                        }
                    }
                    list.Add(objeto);

                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conexion.conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.conexion.Close();
                }

                if (conexion.lector != null && !conexion.lector.IsClosed)
                {
                    conexion.lector.Close();
                }
            }
            return list;
        }

        public static List<Producto> UnirListas()
        {
            List<Producto> list = new List<Producto>();

            List<Arroz> arroz = DatosTabla<Arroz>.ObtenerTodos<Arroz>();
            List<Gaseosa> gaseosa = DatosTabla<Gaseosa>.ObtenerTodos<Gaseosa>();
            List<GaseosaPorMayor> gaseosaMayor = DatosTabla<GaseosaPorMayor>.ObtenerTodos<GaseosaPorMayor>();
            List<Milanesas> milanesas = DatosTabla<Milanesas>.ObtenerTodos<Milanesas>();


            list.AddRange(arroz);
            list.AddRange(gaseosa);
            list.AddRange(gaseosaMayor);
            list.AddRange(milanesas);

            return list;
        }

        public static void EliminarProducto<T>(T producto)
        {
            try
            {
                string nombreTabla = ObtenerTabla(typeof(T));

                AccesoDatos conexion = new AccesoDatos();
                conexion.conexion.Open();

                var properties = typeof(T).GetProperties();

                // Construir la consulta de eliminación
                var queryBuilder = new StringBuilder($"DELETE FROM {nombreTabla} WHERE ");

                // Listas para almacenar los nombres de los atributos y sus valores del objeto
                var atributos = new List<string>();
                var valores = new List<object>();

                foreach (var property in properties)
                {
                    var valor = property.GetValue(producto);
                    if (valor != null && valor != DBNull.Value)
                    {
                        if (valor is Enum)
                        {
                            valor = valor.ToString();
                        }
                        atributos.Add(property.Name);
                        valores.Add(valor);

                        queryBuilder.Append($"{property.Name} = @{property.Name} AND ");

                    }
                }

            }
            catch (Exception)
            {

                throw;
            }

        }







    }
}
