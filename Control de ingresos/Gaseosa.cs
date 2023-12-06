using Microsoft.Data.SqlClient;
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
    public class Gaseosa:Producto,IModificarProducto<Gaseosa>
    {

        private float mililitros;
        private string sabor;


        public Gaseosa(string nombre, string tipo, EMarca marca, int cantidad, float precio,float mll, string sabor) : base(nombre, tipo, marca, cantidad, precio)
        {
            this.mililitros = mll;
            this.sabor = sabor;
            this.AjustarPrecio();
        }
        public Gaseosa(string nombre, string tipo, EMarca marca, int cantidad, float precio, float mll) : this(nombre, tipo, marca, cantidad, precio, mll, "Tónica")
        {

        }
        public Gaseosa(string nombre, string tipo, EMarca marca, int cantidad, float precio) : this(nombre, tipo, marca, cantidad, precio, 2.5f)
        {

        }

        public Gaseosa()
        {

        }
        public float Mililitros { get => mililitros; set => mililitros = value; }
        public string Sabor { get => sabor; set => sabor = value; }

        /// <summary>
        /// Sobrecarga del metodo Mostrar(),llama al metodo Mostrar()Padre para luego concatenarle mediante
        /// un StringBuilder datos de la clase propia
        /// </summary>
        /// <returns>
        /// Información detallada del producto
        /// </returns>
        protected override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.Mostrar());
            sb.Append($"--- Mililitros: {Mililitros} --- Sabor: {Sabor} --- TOTAL: {this.PrecioTotal()}");

            return sb.ToString();
        }

        public override string ToString()
        {
            return this.Mostrar();
        }
        /// <summary>
        /// Ajuste de precio segun si es o no de sabor Tónica o su sobrecarga sabor Tomate
        /// </summary>
        internal override void AjustarPrecio()
        {
            if(sabor == "Tónica")
            {
                Precio = Precio * 0.8f;
            }
            else
            {
                AjustarPrecio(2f);
            }
        }

        internal void AjustarPrecio( float aumento)
        {
            if (sabor == "Tomate")
            {
                Precio = Precio * aumento;
            }
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is Gaseosa))
            {
                return false;
            }

            return this == (Gaseosa)obj;

        }

        /// <summary>
        /// Sobrecarga del metodo == para generar un criterio de comparación propio entre dos 
        /// objetos de la misma clase
        /// </summary>
        /// <returns>
        /// false o true dependiendo del resultado de la comparación
        /// </returns>
        public static bool operator ==(Gaseosa a, Gaseosa b)
        {
            return a.Sabor == b.Sabor && a.mililitros == b.mililitros && a.Tipo == b.Tipo;
        }
        public static bool operator !=(Gaseosa a, Gaseosa b)
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
        public static Gaseosa operator +(Gaseosa a, Gaseosa b)
        {
            return new Gaseosa("Pack de gaseosas", "Mezcla", (EMarca)Enum.Parse(typeof(EMarca), "Trapal"), a.Cantidad + b.Cantidad, (a.Precio + b.Precio) * 0.7f, 3f, "Fantasia");
        }

        /// <summary>
        /// Modifica un elemento en la tabla Gaseosa con los datos del segundo producto, basado en los datos del primer producto.
        /// </summary>
        /// <param name="producto1">El primer producto que sirve como referencia para la búsqueda del elemento a modificar.</param>
        /// <param name="producto2">El segundo producto que contiene los datos para la modificación.</param>
       
        public void ModificarElemento(Gaseosa producto1, Gaseosa producto2)
        {
            string nombreTabla = "Gaseosa";
            AccesoDatos conexion = new AccesoDatos();
            conexion.conexion.Open();
            try
            {
                // Consulta SQL para actualizar los datos del elemento en la tabla

                string consulta = $"UPDATE {nombreTabla} SET cantidad = @cantidad, marca = @marca, nombre = @nombre, tipo = @tipo, precio = @precio," +
                                  $" sabor = @sabor, mililitros = @mililitros WHERE cantidad = @cantidad1 AND marca = @marca1 AND nombre = @nombre1 AND tipo = @tipo1 AND precio = @precio1 AND" +
                                  $" sabor = @sabor1 AND mililitros = @mililitros1";

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
                conexion.comando.Parameters.AddWithValue("@mililitros", producto2.Mililitros);
                conexion.comando.Parameters.AddWithValue("@sabor", producto2.Sabor);
                // Se agrega los parámetros de la busqueda del obejto en la tabla
                conexion.comando.Parameters.AddWithValue("@cantidad1", producto1.Cantidad);
                conexion.comando.Parameters.AddWithValue("@marca1", producto1.Marca.ToString());
                conexion.comando.Parameters.AddWithValue("@nombre1", producto1.Nombre);
                conexion.comando.Parameters.AddWithValue("@tipo1", producto1.Tipo);
                conexion.comando.Parameters.AddWithValue("@precio1", producto1.Precio);
                conexion.comando.Parameters.AddWithValue("@mililitros1", producto1.Mililitros);
                conexion.comando.Parameters.AddWithValue("@sabor1", producto1.Sabor);

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
