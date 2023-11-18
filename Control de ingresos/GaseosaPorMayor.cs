using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace Control_de_ingresos
{
    /// <summary>
    /// Clase hija de Producto. Comparte sus mismas caracteristicas y métodos agregando los propios 
    /// para completar la clase
    /// </summary>
    public class GaseosaPorMayor:Gaseosa
    {
        private int unidades;
        private string artesanal;

        /// <summary>
        /// Se tiene diversos constructores a respetar por consigna de examen los cuales llaman a sus sobrecargas y al final a su
        /// constructor padre
        /// </summary>
       
        public GaseosaPorMayor(string nombre, string tipo, EMarca marca, int cantidad, float precio,float mililitros,string sabor, int unidades, string artesanal) : base(nombre, tipo, marca, cantidad, precio,mililitros,sabor)
        {
            this.unidades = unidades;
            this.artesanal = artesanal;
            this.AjustarPrecio();
        }
        public GaseosaPorMayor(string nombre, string tipo, EMarca marca, int cantidad, float precio, float mililitros, string sabor, int unidades) : this(nombre, tipo, marca, cantidad, precio, mililitros, sabor, unidades,"No")
        {

        }
        public GaseosaPorMayor(string nombre, string tipo, EMarca marca, int cantidad, float precio,float mililitros, string sabor) : this(nombre, tipo, marca, cantidad, precio, mililitros, sabor, 6)
        {

        }

        public GaseosaPorMayor()
        {

        }
        
        public int Unidades { get => unidades; set => unidades = value; }
        public string Artesanal { get => artesanal; set => artesanal = value; }

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
            sb.Append($"--- Unidades: {Unidades} --- Es artesanal: {Artesanal} --- TOTAL: {this.PrecioTotal()}");

            return sb.ToString();
        }

        public override string ToString()
        {
            return this.Mostrar();
        }
        /// <summary>
        /// Ajuste de precio segun si es o no artesanal
        /// </summary>
        internal override void AjustarPrecio()
        {
            if(Artesanal == "No")
            {
                Precio = Precio * 0.9f;
            }
            else
            {
                AjustarPrecio(3f);
            }
        }
        internal void AjustarPrecio(float aumento)
        {
            if (Artesanal == "Si")
            {
                Precio = Precio * aumento;
            }
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is GaseosaPorMayor))
            {
                return false;
            }

            return this == (GaseosaPorMayor)obj;

        }

        /// <summary>
        /// Sobrecarga del metodo == para generar un criterio de comparación propio entre dos 
        /// objetos de la misma clase
        /// </summary>
        /// <returns>
        /// false o true dependiendo del resultado de la comparación
        /// </returns>
        public static bool operator ==(GaseosaPorMayor a, GaseosaPorMayor b)
        {
            return a.Artesanal == b.Artesanal && a.Unidades == b.Unidades && a.Tipo == b.Tipo;
        }
        public static bool operator !=(GaseosaPorMayor a, GaseosaPorMayor b)
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
        public static GaseosaPorMayor operator +(GaseosaPorMayor a, GaseosaPorMayor b)
        {

            return new GaseosaPorMayor("GaseosaX", "Mezcla", (EMarca)Enum.Parse(typeof(EMarca), "Trapal"), a.Cantidad + b.Cantidad, (a.Precio + b.Precio) * 0.7f,0.500f,"Uva",a.Unidades+b.Unidades,"No");

        }

    }
}
