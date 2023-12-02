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
    public class Gaseosa:Producto
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

       
    }
}
