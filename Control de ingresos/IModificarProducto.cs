using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_de_ingresos
{
    /// <summary>
    /// Interfaz creada para que las clases usuarias implemente el metodo Modificarelemnto 
    /// </summary>
    public interface IModificarProducto<T> 

    {
        public void ModificarElemento(T producto1,T producto2);
    }
}
