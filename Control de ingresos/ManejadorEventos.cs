using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Control_de_ingresos.Delegados;

namespace Control_de_ingresos
{
    public class ManejadorEventos
    {
        private string marca;
        private int nombreTipo;
        private Producto producto;


        public event mensajeDelegado mensajeMarca;
        public event mensajeNombreTipo mensajeNombreTipo;
        public event EliminarDeBase EliminarProducto;




        public ManejadorEventos()
        {
        }



        public string Marca
        {

            get { return this.marca; }
            set
            {
                if (value != null)
                {
                   mensajeMarca.Invoke(value);
                }
            }

        }
        public Producto Producto
        {

            get { return this.producto; }
            set
            {
                if (value is Producto)
                {
                    EliminarProducto.Invoke(value);
                }
            }

        }

        public int NombreTipo
        {

            get { return this.nombreTipo; }
            set
            {
                if (value == 0)
                {
                    mensajeNombreTipo.Invoke();
                }
            }

        }
    }
}
