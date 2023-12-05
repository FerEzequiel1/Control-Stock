﻿using Microsoft.Data.SqlClient;
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
        /// <summary>
        /// Método para agregar un objeto genérico a la base de datos.
        /// </summary>
        public static void AgregarObjeto(T objeto)
        {

            // Obtener el nombre de la tabla correspondiente al tipo por
            // medio del metodo OBtenerTabla

            string nombreTabla = ObtenerTabla(typeof(T));

            AccesoDatos conexion = new AccesoDatos();
            conexion.conexion.Open();

            conexion.comando = new SqlCommand();
            conexion.comando.Connection = conexion.conexion;

            // Construir los strings para las columnas y valores de inserción con StringBuilder
            // concatenando todos los valores necesarios

            StringBuilder columnas = new StringBuilder();
            StringBuilder valores = new StringBuilder();

            foreach (PropertyInfo propiedad in typeof(T).GetProperties())
            {
                string nombreColumna = propiedad.Name.ToLower();
                var valor = propiedad.GetValue(objeto, null);

                if (nombreColumna == "marca")
                {
                    valor = valor.ToString();   // Se castea a ToString ya que es un Enumerado y la base acepta string
                }

                columnas.Append($"{nombreColumna}, ");
                valores.Append($"@{nombreColumna}, ");

                // Se grega los parámetros al comando SQL
                conexion.comando.Parameters.AddWithValue($"@{nombreColumna}", valor);
            }

            // Se elimina las últimas comas y espacios en los strings de columnas y valores

            columnas.Length -= 2; 
            valores.Length -= 2;

            //se completa la query concatengnado las tablas,columnas y valores 

            string query = $"INSERT INTO {nombreTabla} ({columnas}) VALUES ({valores})";

            // Se establece  la consulta SQL al comando y se ejecuta
            conexion.comando.CommandText = query;
            conexion.comando.ExecuteNonQuery();

            Console.WriteLine($"Se ingreso {nombreTabla}");
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

               
                queryBuilder.Length -= 5; // Eliminar el último "AND " agregado
                SqlCommand comando = new SqlCommand(queryBuilder.ToString(), conexion.conexion);

                // Agregar parámetros con los valores de los atributos del objeto
                for (int i = 0; i < atributos.Count; i++)
                {
                    comando.Parameters.AddWithValue($"@{atributos[i]}", valores[i]);
                }

                int filasEliminadas = comando.ExecuteNonQuery();

                if (filasEliminadas > 0)
                {
                    Console.WriteLine($"Se eliminó la fila en la tabla {nombreTabla}");
                }
                else
                {
                    Console.WriteLine("No se encontró la fila para eliminar");
                }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

        }







    }
}
