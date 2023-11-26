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
            catch (Exception)
            {

                throw;
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
    }
}
