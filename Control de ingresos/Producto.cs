using System.Drawing;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System;

namespace Control_de_ingresos
{
    [Serializable]
    [XmlInclude(typeof(Gaseosa))]
    [XmlInclude(typeof(Arroz))]
    [XmlInclude(typeof(GaseosaPorMayor))]
    [XmlInclude(typeof(Milanesas))]


    public abstract class Producto
    {
        /// <summary>
        /// 
        /// Clase abstracta producto va a inicializar todos los productos que se instancien de manera de que funcione como plantilla para las demas clases.
        /// Tiene sus propios metodos que va  acompartir con sus clases hijas para la reutilización de codigo.
        /// 
        /// </summary>
        private string tipo;
        private float precio;
        private string nombre;
        private EMarca marca;
        private int cantidad;

        public Producto(string nombre,string tipo, EMarca marca, int cantidad,float precio) : this(tipo, marca, nombre,cantidad)
        {
            this.precio = precio;
            
        }

        public Producto(string tipo, EMarca marca, string nombre,int cantidad):this(marca)
        {
            this.nombre = nombre;
            this.Cantidad = cantidad;
            this.tipo = tipo;
        }
        protected Producto(EMarca marca)
        {
            this.marca = marca;
            this.nombre = "Sin indentificar";    
            this.cantidad=1;
            this.precio=100f;
            this.tipo = "Desconocido";


        }

        public Producto()
        {
            
        }
        

        public float Precio { get => precio; set => precio = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public EMarca Marca { get => marca; set => marca = value; }

        /// <summary>
        /// 
        /// Metodo virtual el cual se va a sobreescribir.
        /// </summary>
        /// 
        /// <returns>
        /// Cadena de string concatenando caracteristicas del producto para poder mostrar en pantalla. Cada herencia va a añadir
        /// sus propios atributos
        /// </returns>
        protected virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"Nombre: {Nombre} --- Tipo:{Tipo} --- Marca: {Marca} --- Cantidad: {Cantidad} --- Precio: {Precio}");

            return sb.ToString();
        }

        public override string ToString()
        {
            return this.Mostrar();
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is Producto))
            {
                return false;
            }

            return this == (Producto)obj;

        }

        /// <summary>
        /// Metodo abstracto a aplicar en sus clases hijas para aumentar o disminuir el precio
        /// segun la funcionalidad que se le de.
        /// </summary>
        internal abstract void AjustarPrecio();

        /// <summary>
        /// Sobrecarga del metodo == para generar un criterio de comparación propio entre dos 
        /// objetos de la misma clase
        /// </summary>
        /// <returns>
        /// false o true dependiendo del resultado de la comparación
        /// </returns>
        public static bool operator == (Producto a, Producto b)
        {
            return a.Tipo == b.Tipo && a.Nombre == b.Nombre && a.Marca == b.Marca;
        }
        public static bool operator !=(Producto a, Producto b)
        {
            return !(a == b);
        }
       
        public  double PrecioTotal()
        {
            return (int)Precio * Cantidad;
        }


        /// <summary>
        /// Metodo para serializar la lista de productos en el ámbito local puestas por el programa a cumplir con la consiga del parcial
        /// Recibe como parametro la lista a serializar y el path de donde va a ser ubicada
        /// </summary>

        public static void Serializar(ListaProductos lista, string path)
        {
            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(path + @"DatosListas.xml", System.Text.Encoding.UTF8))
                {
                    XmlSerializer serializacion = new XmlSerializer(typeof(ListaProductos));

                    serializacion.Serialize(writer, lista);
                  
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Ocurrió un error de tipo {ex} al serializar los datos. Por favor, contacta al soporte.");
            }
        }

        /// <summary>
        /// Recibe un path del archivo a deserializar
        /// </summary>
        /// <returns>
        /// Devuelve una listaProductos para su tratamiento. Esto es con fin de deserializar una lista
        /// previamente guardada en el programa para cumplir con la consigna del parcial
        /// </returns>
        public static ListaProductos Deserializar(string path)
        {
            ListaProductos lista;
            try
            {
                using (XmlTextReader reader = new XmlTextReader(path + @"DatosListas.xml"))
                {
                    XmlSerializer deserializacion = new XmlSerializer(typeof(ListaProductos));

                    lista = (ListaProductos)deserializacion.Deserialize(reader);
                    
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Ocurrió un error de tipo {ex} al deserializar los datos. Por favor, contacta al soporte.");
                lista = null;
            }


            return lista;
        }

    }
}
