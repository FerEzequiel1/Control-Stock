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

        private int edad;
        public event mensajeDelegado mensaje1;
        public event mensajeDelegado mensaje2;

        public ManejadorEventos()
        {
            
        }

        public int Edad
        {

            get { return this.edad; }
            set
            {
                if (value == 2)
                {
                    mensaje2.Invoke(value);
                }
                else
                {
                    if (value == 1)
                    {
                        mensaje1.Invoke(value);
                    }
                }
            }

        }

    }
}
