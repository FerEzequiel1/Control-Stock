using Control_de_ingresos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicacion
{
    /// <summary>
    /// Formulario donde se visuliza la listaDeProductos del Forumlario principal para seleccionar uno y eliminar
    /// </summary>
    public partial class FrmEliminar : Form
    {
        public ListaProductos lista;
        public FrmEliminar(ListaProductos lista)
        {
            InitializeComponent();
            this.lista = lista;
        }
        //Se cargan los productos a un List Box mediante el método PublicarProductos()
        private void FrmEliminarcs_Load(object sender, EventArgs e)
        {
            PublicarProductos();

        }

        /// <summary>
        /// Se cierra el formulario
        /// </summary>
        
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
            int indice = this.lsBProductos.SelectedIndex;

            DialogResult resultado = MessageBox.Show("¿Realmente desea eliminar el producto?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                if (indice >= 0)
                {
                    Producto producto = this.lista.ListaDeProductos[indice];

                    Eliminar(producto);
                    PublicarProductos();
                }
            }


        }

        /// <summary>
        /// Se cargan los productos de la listaDeProductos del Formulario principal a un List Box
        /// </summary>
        public void PublicarProductos()
        {
            this.lsBProductos.Items.Clear();
            foreach (Producto p in this.lista.ListaDeProductos)
            {
                lsBProductos.Items.Add(p);
            }
        }

        /// <summary>
        /// Se elmina el producto de la listaDeProductos mediante la sobrecarga del metodo - de la Clase ListaProductos
        /// </summary>
       
        public bool Eliminar(Producto p)
        {
            return lista - p;
        }
    }

}
