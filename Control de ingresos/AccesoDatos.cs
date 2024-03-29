﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Reflection;
using System.Collections;

namespace Control_de_ingresos
{
    /// <summary>
    /// Clase para manejar la conexión y acceso a datos en la base de datos.
    /// </summary>
    public class AccesoDatos
    {
        public SqlConnection conexion;// Objeto de conexión a la base de datos
        public static string cadena_conexion; // Cadena de conexión estática
        public SqlCommand comando; // Comando SQL para operaciones en la base de datos
        public SqlDataReader lector; // Lector de datos para consultar resultados

        static AccesoDatos()
        {
            AccesoDatos.cadena_conexion = Properties.Resources.miConexion;
        }
        public AccesoDatos()
        {
            this.conexion = new SqlConnection(AccesoDatos.cadena_conexion);
        }
       

        public bool Prueba()
        {
            bool retorno = false;

            try
            {
                this.conexion.Open();
                retorno= true;

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            finally 
            { 
                if(this.conexion.State == System.Data.ConnectionState.Open)
                {
                    this.conexion.Close();
                } 
            }


            return retorno;
        }

        //public List<Arroz> obtenerLista()
        //{
        //    List <Arroz> lista = new List<Arroz> ();

        //    try
        //    {
        //        this.comando = new SqlCommand();
        //        this.comando.CommandType = System.Data.CommandType.Text;
        //        this.comando.CommandText = "select * from Arroz";
        //        this.comando.Connection = this.conexion;

        //        this.conexion.Open();

        //        this.lector = this.comando.ExecuteReader();

        //        while (this.lector.Read()) 
        //        { 
        //            Arroz aroz = new Arroz();
        //            aroz.Nombre = (string)this.lector["nombre"];
        //            aroz.Tipo = (string)this.lector["tipo"];
        //            aroz.Marca = (EMarca)Enum.Parse(typeof(EMarca), (string)this.lector["marca"]);
        //            aroz.Cantidad = (int)this.lector["cantidad"];
        //            aroz.Precio = (float)this.lector.GetDouble(5);
        //            aroz.Origen = (string)this.lector["origen"];
        //            aroz.Proveedor = (string)this.lector["proveedor"];
        //            lista.Add(aroz);
        //        }
        //        this.lector.Close();
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    finally
        //    {
        //        if (this.conexion.State == System.Data.ConnectionState.Open) this.conexion.Close();
        //    }


        //    return lista;
        //}

    }
}
