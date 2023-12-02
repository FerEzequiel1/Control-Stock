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
    public class Milanesas :Producto, IPrecioTotal
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


        public void ModificarElemento(Milanesas producto1, Milanesas producto2)
        {


        }
    }
}
