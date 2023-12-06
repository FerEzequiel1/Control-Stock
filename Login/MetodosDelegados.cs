using Control_de_ingresos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion
{

    /// <summary>
    /// Esta clase actua como un biblioteca de metodos que van a ser usados como delegados dentro de la Aplicacion
    /// </summary>
    public static class MetodosDelegados
    {
        public static void mensajeMarca(string mensaje)
        {
            MessageBox.Show($"{mensaje}", "ATENCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
        public static void mensajeNombreTipo()
        {
            MessageBox.Show($"Debe completar el nombre y/o tipo", "ATENCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
        public static void mensajeEliminado(string s)
        {
            MessageBox.Show($"Producto eliminado con éxito", "Producto eliminado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        public static void ElimnarProductoPorDelegadoArroz(Arroz producto)
        {
            DatosTabla<Arroz>.EliminarProducto(producto);
        }
        public static void ElimnarProductoPorDelegadoGaseosa(Gaseosa producto)
        {
            DatosTabla<Gaseosa>.EliminarProducto(producto);
        }
        public static void ElimnarProductoPorDelegadoMilanesa(Milanesas producto)
        {
            DatosTabla<Milanesas>.EliminarProducto(producto);
        }
        public static void ElimnarProductoPorDelegadoGaseosaPorMayor(GaseosaPorMayor producto)
        {
            DatosTabla<GaseosaPorMayor>.EliminarProducto(producto);
        }

    }
}
