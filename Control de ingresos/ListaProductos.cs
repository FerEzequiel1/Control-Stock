using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Control_de_ingresos
{
    /// <summary>
    /// Esta es la clase que va a contenes la lista de los productos que generemos a lo largo del programa
    /// </summary>
    public class ListaProductos
    {
        private List<Producto> listaDeProductos;

        public ListaProductos(List<Producto> productos)
        {
            this.listaDeProductos = productos;
        }
        public ListaProductos()
        {
            
        }

        public List<Producto> ListaDeProductos { get => listaDeProductos; set => listaDeProductos = value; }

        public  void MostrarDetalles()
        {
            foreach (Producto producto in ListaDeProductos)
            {
                Console.WriteLine(producto.ToString());
            }

        }

        /// <summary>
        /// Unica manera de agregar productos a la lista es por sobrecarga del operador + el cual verifica que no este incluido 
        /// en la misma.
        /// </summary>
        
        public static bool operator +(ListaProductos l, Producto p)
        {
            bool rta = false;

            if (l != p)
            {
                l.ListaDeProductos.Add(p);
                rta= true;
            }
            return rta;
        }

        /// <summary>
        /// Unica manera de eliminar productos a la lista es por sobrecarga del operador - el cual verifica que  este incluido 
        /// en la misma antes de eliminarlo.
        /// </summary>
        public static bool operator -(ListaProductos l, Producto p)
        {
            bool rta = false;

            if (l == p)
            {
                l.ListaDeProductos.Remove(p);
                rta = true;
            }
            return rta;
        }


        /// <summary>
        /// Unica manera de verificar si un productos esta en la lista es por sobrecarga del operador == .
        /// </summary>
        public static bool operator ==(ListaProductos l, Producto p)
        {
            bool rta = false;
            foreach (Producto producto in l.ListaDeProductos)
            {
                if (producto.Equals(p))
                {
                    rta = true;
                }
            }
            return rta;
        }
        public static bool operator !=(ListaProductos e, Producto p)
        {
            return (!(e == p));
        }

        /// <summary>
        /// Ordena la lista segun el criterio y tipo se haya escojido.
        /// Esta elección se pasa por parametro el cual se analiza y se ejecuta a considerar sus valores.
        /// </summary>
        
        public void OrdenPorPrecioCantidad(string orden,string tipo)
        {
            List<Producto> listaOrdenada;


            if (orden == "Ascendente" && tipo == "Precio total")
            {
                listaOrdenada = listaDeProductos.OrderBy(producto => producto.PrecioTotal()).ToList();
            }
            else if (orden != "Ascendente" && tipo == "Precio total")
            {
                listaOrdenada = listaDeProductos.OrderByDescending(producto => producto.PrecioTotal()).ToList();
            }
            else if (orden == "Ascendente" && tipo == "Cantidad")
            {
                listaOrdenada = listaDeProductos.OrderBy(producto => producto.Cantidad).ToList();
            }
            else
            {
                listaOrdenada = listaDeProductos.OrderByDescending(producto => producto.Cantidad).ToList();
            }

            listaDeProductos = listaOrdenada;

        }


    }
}
