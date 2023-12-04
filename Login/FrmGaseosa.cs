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
    public partial class FrmGaseosa : FrmAgregarProducto
    {
        /// <summary>
        /// Formulario donde se va a completar los datos pedidos para poder crear un producto tipo Gaseosa
        /// </summary>
        /// 
        bool modifica = false;
        public FrmGaseosa(ListaProductos lista, Gaseosa producto, bool modifica) : this(lista)
        {
            int indiceMarca = Array.IndexOf(Enum.GetValues(typeof(EMarca)), producto.Marca);

            this.txtNombre.Text = producto.Nombre;
            this.txtTipo.Text = producto.Tipo;
            this.cmbMarca.SelectedIndex = indiceMarca;
            this.nUDCantidad.Value = producto.Cantidad;
            this.nUDPrecio.Value = (decimal)producto.Precio;
            this.nUDMililitros.Value = (decimal)producto.Mililitros;
            this.txtSabor.Text = producto.Sabor;
            this.modifica = modifica;
        }
        public FrmGaseosa(ListaProductos lista) : base(lista)
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Se verifica a travez de los métodos si cumplen con los tipos de datos correctos para la creación del producto
            string marca = base.VerificarMarca();
            bool nombre = base.VerificarNombreTipo();

            if (marca != "no" && nombre)
            {
                Gaseosa gaseosa = new Gaseosa(base.txtNombre.Text, base.txtTipo.Text, (EMarca)Enum.Parse(typeof(EMarca), marca), (int)base.nUDCantidad.Value, (float)base.nUDPrecio.Value, (float)this.nUDMililitros.Value, this.txtSabor.Text);

                //Se verifica que el producto ingresado no exita en la listaDeProductos del formulario principal
                //Si esta no se agrega y se informa.Caso contrario lo agrega y se recetean los campos del formulario
                if (base.Comparar(gaseosa))
                {
                    MessageBox.Show($"El producto que intenta ingresar ya existe", "ATENCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    base.agregar(gaseosa);
                    base.LimpiarCampos();
                    MessageBox.Show($"El producto ha sido ingresado con éxito", "Producto Ingresado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (modifica)
                    {
                        this.Close();
                    }
                }
            }
        }
    }
}
