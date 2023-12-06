using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Control_de_ingresos.Delegados;

namespace Control_de_ingresos
{
    /// <summary>
    /// Esta clase actua como un manejador de eventos para diferentes tipos situaciones a lo largo del programa.
    /// </summary>
    public class ManejadorEventos
    {
        private string marca;
        private int nombreTipo;

        private Arroz arroz;
        private Gaseosa gaseosa;
        private GaseosaPorMayor gaseosaPorMayor;
        private Milanesas milanesa;

        // Eventos públicos asociados con cambios en propiedades específicas y eliminación de productos

        public event mensajeDelegado mensajeMarca;
        public event mensajeNombreTipo mensajeNombreTipo;

        public event EliminarDeBaseArroz EliminarProductoArroz;
        public event EliminarDeBaseGaseosa EliminarProductoGaseosa;
        public event EliminarDeBaseGaseosaPorMayor EliminarProductoGaseosaMayor;
        public event EliminarDeBaseArrozMilanesa EliminarProductoMilanesa;





        public ManejadorEventos()
        {
        }


        // Obtiene y establece la marca; invoca mensajeMarca cuando se le pase un texto predeterminado
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

        // Propiedades para diferentes tipos de productos(Arroz,Gaseosa,GaseosaPorMayor,Milanesas); invocan eventos de eliminación de productos correspondientes
        public Arroz Arroz
        {

            get { return this.arroz; }
            set
            {
                if (value is Arroz)
                {
                    EliminarProductoArroz.Invoke(value);
                }
            }

        }

        public Gaseosa Gaseosa
        {

            get { return this.gaseosa; }
            set
            {
                if (value is Gaseosa)
                {
                    EliminarProductoGaseosa.Invoke(value);
                }
            }

        }

        public GaseosaPorMayor GaseosaPorMayor
        {

            get { return this.gaseosaPorMayor; }
            set
            {
                if (value is GaseosaPorMayor)
                {
                    EliminarProductoGaseosaMayor.Invoke(value);
                }
            }

        }

        public Milanesas Milanesas
        {

            get { return this.milanesa; }
            set
            {
                if (value is Milanesas)
                {
                    EliminarProductoMilanesa.Invoke(value);
                }
            }

        }
        // Propiedad para el nombre del tipo; invoca mensajeNombreTipo si el valor es 0 para informar que no se ingeso nada

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
