using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Control_de_ingresos
{
    /// <summary>
    /// Clase hija de Producto. Comparte sus mismas caracteristicas y métodos agregando los propios 
    /// para completar la clase
    /// </summary>
    public class Arroz:Producto , IModificarProducto<Arroz>
    {
        private string origen;
        private string proveedor;


        public Arroz(string nombre, string tipo, EMarca marca, int cantidad, float precio,string origen,string proveedor) : base(nombre,tipo, marca, cantidad,precio)
        {
            this.origen = origen;
            this.proveedor = proveedor;
            this.AjustarPrecio();
        }
        public Arroz(string nombre, string tipo, EMarca marca, int cantidad, float precio, string origen) : this(nombre, tipo, marca, cantidad, precio, origen,"Desconocido")
        {
          
        }
        public Arroz(string nombre, string tipo, EMarca marca, int cantidad, float precio) : this(nombre, tipo, marca, cantidad, precio, "Desconocido")
        {

        }

        public Arroz()
        {
            
        }
        public string Origen { get => origen; set => origen = value; }
        public string Proveedor { get => proveedor; set => proveedor = value; }


       

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
            sb.Append($"--- Origen: {Origen} --- Proveedor: {Proveedor} --- TOTAL: {this.PrecioTotal()}");

            return sb.ToString();
        }

        public override string ToString()
        {
            return this.Mostrar();
        }

        /// <summary>
        /// Ajuste de precio segun si es o no de marca Gallo o su sobrecarga swift con un valor mayor
        /// </summary>
        internal override void AjustarPrecio() {
            if (Marca == (EMarca)Enum.Parse(typeof(EMarca), "SevenUp"))
            {
                Precio = Precio * 1.3f;
            }
            else
            {
                AjustarPrecio(3f);
            }
        }
        internal void AjustarPrecio(float aumento)
        {
            if (Marca == (EMarca)Enum.Parse(typeof(EMarca), "Swift"))
            {
                Precio = Precio * aumento;
            }
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is Arroz))
            {
                return false;
            }

            return this == (Arroz)obj;

        }

        /// <summary>
        /// Sobrecarga del metodo == para generar un criterio de comparación propio entre dos 
        /// objetos de la misma clase
        /// </summary>
        /// <returns>
        /// false o true dependiendo del resultado de la comparación
        /// </returns>
        public static bool operator ==(Arroz a, Arroz b)
        {
            return a.Marca == b.Marca && a.Origen == b.Origen && a.Tipo == b.Tipo;
        }
        public static bool operator !=(Arroz a, Arroz b)
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
        public static Arroz operator +(Arroz a, Arroz b)
        {
            return new Arroz("Combo Bolsa de Arroz", "Mezcla", (EMarca)Enum.Parse(typeof(EMarca), "Trapal"), a.Cantidad + b.Cantidad, (a.Precio + b.Precio) * 0.7f, "Argentina", "Trapal");
        }


        public void ModificarElemento(Arroz producto1, Arroz producto2)
        {
            string nombreTabla = "Arroz";
            AccesoDatos conexion = new AccesoDatos();
            conexion.conexion.Open();
            try
            {
                string consulta = $"UPDATE {nombreTabla} SET cantidad = @cantidad, marca = @marca, nombre = @nombre, tipo = @tipo, precio = @precio," +
                                  $"origen = @origen, proveedor = @proveedor WHERE cantidad = @cantidad1 AND marca = @marca1 AND nombre = @nombre1 AND tipo = @tipo1 AND precio = @precio1 AND " +
                                  $"origen = @origen1 AND proveedor = @proveedor1";

                conexion.comando = new SqlCommand();
                conexion.comando.Connection = conexion.conexion;
                conexion.comando.CommandText = consulta;
                // se agrega parámetros con los valores del objeto modificado
                conexion.comando.Parameters.AddWithValue("@cantidad", producto2.Cantidad);
                conexion.comando.Parameters.AddWithValue("@marca", producto2.Marca.ToString());
                conexion.comando.Parameters.AddWithValue("@nombre", producto2.Nombre);
                conexion.comando.Parameters.AddWithValue("@tipo", producto2.Tipo);
                conexion.comando.Parameters.AddWithValue("@precio", producto2.Precio);
                conexion.comando.Parameters.AddWithValue("@origen", producto2.Origen);
                conexion.comando.Parameters.AddWithValue("@proveedor", producto2.Proveedor);
                // Se agrega los parámetros de la busqueda del obejto en la tabla
                conexion.comando.Parameters.AddWithValue("@cantidad1", producto1.Cantidad);
                conexion.comando.Parameters.AddWithValue("@marca1", producto1.Marca.ToString());
                conexion.comando.Parameters.AddWithValue("@nombre1", producto1.Nombre);
                conexion.comando.Parameters.AddWithValue("@tipo1", producto1.Tipo);
                conexion.comando.Parameters.AddWithValue("@precio1", producto1.Precio);
                conexion.comando.Parameters.AddWithValue("@origen1", producto1.Origen);
                conexion.comando.Parameters.AddWithValue("@proveedor1", producto1.Proveedor);

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
