using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_de_ingresos
{
    public interface IModificarProducto<T> 

    {
        public void ModificarElemento(T producto1,T producto2);
    }
}
