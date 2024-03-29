﻿using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_de_ingresos
{

    /// <summary>
    /// Clase hija de Producto. Comparte sus mismas caracteristicas y métodos agregando los propios 
    /// para completar la clase
    /// </summary>
    public class Milanesas :Producto, IModificarProducto<Milanesas>
    {
        internal string origenAnimal;
        internal string nacionalidad;

        public Milanesas(string nombre, string tipo, EMarca marca, int cantidad, float precio,string origenAnimal,string nacionalidad) : base(nombre, tipo, marca, cantidad, precio)
        {
            this.origenAnimal = origenAnimal;
            this.nacionalidad = nacionalidad;
            AjustarPrecio();
        }
        public Milanesas(string nombre, string tipo, EMarca marca, int cantidad, float precio, string origenAnimal) : this(nombre, tipo, marca, cantidad, precio,origenAnimal,"argentina")
        {
            
        }
        public Milanesas(string nombre, string tipo, EMarca marca, int cantidad, float precio) : this(nombre, tipo, marca, cantidad, precio, "vacuno")
        {

        }
        public Milanesas()
        {
            
        }

        public string OrigenAnimal { get => origenAnimal; set => origenAnimal = value; }
        public string Nacionalidad { get => nacionalidad; set => nacionalidad = value; }

        /// <summary>
        /// Ajuste de precio segun si es o no de origen vacuno o si 
        /// </summary>
        internal override void AjustarPrecio()
        {
            
            if (origenAnimal.ToLower() == "vacuno" )
            {
                this.Precio = Precio * 1.5f;
            }
            else
            {
                AjustarPrecio(Nacionalidad.ToLower());    
            }
        }
        internal void AjustarPrecio(string nacionalidad)
        {
            if (nacionalidad == "bovino")
            {
                this.Precio = Precio * 1.2f;
            }
        }

        protected override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.Mostrar());
            sb.Append($"--- Origen animal: {origenAnimal} --- Nacionalidad: {nacionalidad} --- TOTAL: {this.PrecioTotal()}");

            return sb.ToString();
        }

        public override string ToString()
        {
            return this.Mostrar();
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is Milanesas))
            {
                return false;
            }

            return this == (Milanesas)obj;
        }
        /// <summary>
        /// Sobrecarga del metodo == para generar un criterio de comparación propio entre dos 
        /// objetos de la misma clase
        /// </summary>
        /// <returns>
        /// false o true dependiendo del resultado de la comparación
        /// </returns>
        public static bool operator ==(Milanesas a, Milanesas b)
        {
            return a.Tipo == b.Tipo && a.Nombre == b.Nombre && a.OrigenAnimal == b.OrigenAnimal && a.Nacionalidad == b.Nacionalidad;
        }
        public static bool operator !=(Milanesas a, Milanesas b)
        {
            return !(a == b);
        }


        /// <summary>
        /// Mediante la sobrecarga + crea un nuevo producto a partir de los dos
        /// productos brindados usando y combinando sus atributos
        /// </summary>
        /// <returns>
        /// Un producto combinado
        /// </returns>
        public static Milanesas operator +(Milanesas a, Milanesas b)
        {
            return new Milanesas("Bandeja de milanesas", "Variedad", (EMarca)Enum.Parse(typeof(EMarca), "Trapal"), a.Cantidad + b.Cantidad, (a.Precio + b.Precio) * 0.7f, $"{a.origenAnimal}/{b.OrigenAnimal}", $"{a.Nacionalidad}/{b.Nacionalidad}");
        }


        /// <summary>
        /// Modifica un elemento en la tabla Milanesas con los datos del segundo producto, basado en los datos del primer producto.
        /// </summary>
        /// <param name="producto1">El primer producto que sirve como referencia para la búsqueda del elemento a modificar.</param>
        /// <param name="producto2">El segundo producto que contiene los datos para la modificación.</param>

        public void ModificarElemento(Milanesas producto1, Milanesas producto2)
        {
            string nombreTabla = "Milanesas"; 
            AccesoDatos conexion = new AccesoDatos();
            conexion.conexion.Open();
            try
            {

                // Consulta SQL para actualizar los datos del elemento en la tabla
                string consulta = $"UPDATE {nombreTabla} SET cantidad = @cantidad, marca = @marca, nombre = @nombre, tipo = @tipo, precio = @precio," +
                                  $" origenAnimal = @origenAnimal, nacionalidad = @nacionalidad WHERE cantidad = @cantidad1 AND marca = @marca1 AND nombre = @nombre1 AND tipo = @tipo1 AND precio = @precio1 AND" +
                                  $" origenAnimal = @origenAnimal1 AND nacionalidad = @nacionalidad1";

                // Configuración del comando SQL
                conexion.comando = new SqlCommand();
                conexion.comando.Connection = conexion.conexion;
                conexion.comando.CommandText = consulta;    
                // se agrega parámetros con los valores del objeto modificado
                conexion.comando.Parameters.AddWithValue("@cantidad", producto2.Cantidad);
                conexion.comando.Parameters.AddWithValue("@marca", producto2.Marca.ToString());
                conexion.comando.Parameters.AddWithValue("@nombre", producto2.Nombre);
                conexion.comando.Parameters.AddWithValue("@tipo", producto2.Tipo);
                conexion.comando.Parameters.AddWithValue("@precio", producto2.Precio);
                conexion.comando.Parameters.AddWithValue("@origenAnimal", producto2.OrigenAnimal);
                conexion.comando.Parameters.AddWithValue("@nacionalidad", producto2.Nacionalidad);
                // Se agrega los parámetros de la busqueda del obejto en la tabla
                conexion.comando.Parameters.AddWithValue("@cantidad1", producto1.Cantidad);
                conexion.comando.Parameters.AddWithValue("@marca1", producto1.Marca.ToString());
                conexion.comando.Parameters.AddWithValue("@nombre1", producto1.Nombre);
                conexion.comando.Parameters.AddWithValue("@tipo1", producto1.Tipo);
                conexion.comando.Parameters.AddWithValue("@precio1", producto1.Precio);
                conexion.comando.Parameters.AddWithValue("@origenAnimal1", producto1.OrigenAnimal);
                conexion.comando.Parameters.AddWithValue("@nacionalidad1", producto1.Nacionalidad);

                int filasAfectadas = conexion.comando.ExecuteNonQuery();

                Console.WriteLine($"Se actualizaron elementos en la tabla {nombreTabla}. Filas afectadas: {filasAfectadas}");
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            finally
            {
                if (conexion.conexion.State == System.Data.ConnectionState.Open) conexion.conexion.Close(); 
            }


        }
    }
}
