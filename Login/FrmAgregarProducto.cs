using Control_de_ingresos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Aplicacion
{   /// <summary>
    /// Formlario base para todos los formularios que agreguen productos a la listaDeProductos del formulario principal
    /// Contiene sus propios metodos que los demas van a heredar
    /// </summary>
    public partial class FrmAgregarProducto : Form
    {
        internal ListaProductos lista;

        public FrmAgregarProducto(ListaProductos lista)
        {
            InitializeComponent();
            this.lista = lista;

        }
        public FrmAgregarProducto()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {


        }
        public bool agregar(Producto p)
        {
            return lista + p;
        }
        public bool Comparar(Producto p)
        {
            return lista == p;
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Verifica que la casilla de Marcas sea seleccionada por alguna opcion brindada.
        /// </summary>
        /// <returns>
        /// La eleccion elegida,caso contrario devuelve un "no" y se visualiza eun MessageBox de los errores que tuvo
        /// </returns>

        protected string VerificarMarca()
        {
            string rta = "no";

            ManejadorEventos evento = new ManejadorEventos();
            evento.mensajeMarca += MetodosDelegados.mensajeMarca;


            if (cmbMarca.SelectedItem != null)
            {
                rta = cmbMarca.SelectedItem.ToString();

            }
            else
            {
                evento.Marca = "Debe seleccionar una marca.";
            }


            return rta;
        }
        /// <summary>
        /// Verifica si se completaron los Text Box de txtNombre y txtTipo
        /// </summary>
        /// <returns>
        /// Un Bool con su respuesta y en caso que sea false muestra un MessageBox explicando su error.
        /// </returns>
        protected bool VerificarNombreTipo()
        {
            bool rta = false;
            ManejadorEventos evento = new ManejadorEventos();
            evento.mensajeNombreTipo += MetodosDelegados.mensajeNombreTipo;

            if (this.txtNombre.Text.Length > 0 && this.txtTipo.Text.Length > 0)
            {
                rta = true;
            }
            else
            {
                evento.NombreTipo = 0;
            }

            return rta;
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        /// <summary>
        /// Limpia todos los controles del formulario.
        /// </summary>
        protected void LimpiarCampos()
        {

            foreach (Control control in this.Controls)
            {
                if (control is System.Windows.Forms.GroupBox grupo)
                {
                    foreach (Control control1 in grupo.Controls)
                    {
                        if (control1 is System.Windows.Forms.TextBox textBox)
                        {
                            textBox.Text = "";
                        }
                        else if (control1 is System.Windows.Forms.NumericUpDown numerico)
                        {
                            numerico.Value = 1;
                        }
                        else
                        {
                            cmbMarca.Text = "Ingrese una opción";
                        }

                    }
                }
            }
        }
    }
}
