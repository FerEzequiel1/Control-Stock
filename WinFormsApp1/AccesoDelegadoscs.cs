using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public static class AccesoDelegadoscs
    {

        public static void mensajeDelegado(int mensaje)
        {
            MessageBox.Show($"1", "ATENCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
        public static void mensajeDelegad2(int mensaje)
        {
            MessageBox.Show($"2.", "ATENCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
    }
}
