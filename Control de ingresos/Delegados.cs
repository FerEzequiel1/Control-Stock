using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_de_ingresos
{
    public  class Delegados
    {
        public delegate void mensajeDelegado(string edad);
        public delegate void mensajeNombreTipo();
        public delegate void EliminarDeBase(Producto producto);
    }
}
