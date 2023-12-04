using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion
{
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

    }
}
