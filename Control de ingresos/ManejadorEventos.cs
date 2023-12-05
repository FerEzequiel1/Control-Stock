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

        private Arroz arroz;
        private Gaseosa gaseosa;
        private GaseosaPorMayor gaseosaPorMayor;
        private Milanesas milanesa;


        public event mensajeDelegado mensajeMarca;
        public event mensajeNombreTipo mensajeNombreTipo;

        public event EliminarDeBaseArroz EliminarProductoArroz;
        public event EliminarDeBaseGaseosa EliminarProductoGaseosa;
        public event EliminarDeBaseGaseosaPorMayor EliminarProductoGaseosaMayor;
        public event EliminarDeBaseArrozMilanesa EliminarProductoMilanesa;





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
