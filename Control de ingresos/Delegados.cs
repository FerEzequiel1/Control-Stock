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

        public delegate void EliminarDeBaseArroz(Arroz producto);
        public delegate void EliminarDeBaseGaseosa(Gaseosa producto);
        public delegate void EliminarDeBaseGaseosaPorMayor(GaseosaPorMayor producto);
        public delegate void EliminarDeBaseArrozMilanesa(Milanesas producto);

    }
}
