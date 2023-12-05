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
    public partial class FrmAarroz : FrmAgregarProducto
    {
        /// <summary>
        /// Formulario donde se va a completar los datos pedidos para poder crear un producto tipo Aarroz
        /// </summary>
        /// 

        public bool modifica = false;
        public Arroz producto;

        public FrmAarroz(ListaProductos lista, Arroz producto, bool modifica) : this(lista)
        {
            int indiceMarca = Array.IndexOf(Enum.GetValues(typeof(EMarca)), producto.Marca);
            this.txtNombre.Text = producto.Nombre;
            this.txtTipo.Text = producto.Tipo;
            this.cmbMarca.SelectedIndex = indiceMarca;
            this.nUDCantidad.Value = producto.Cantidad;
            this.nUDPrecio.Value = (decimal)producto.Precio;
            this.txtOrigen.Text = producto.Origen;
            this.txtProveedor.Text = producto.Proveedor;
            this.modifica = modifica;
            this.producto = producto;

        }
        public FrmAarroz(ListaProductos lista) : base(lista)
        {
            InitializeComponent();
        }
        public FrmAarroz()
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Se verifica a travez de los métodos si cumplen con los tipos de datos correctos para la creación del producto
            string marca = base.VerificarMarca();
            bool nombre = base.VerificarNombreTipo();

            if (marca != "no" && nombre)
            {
                Arroz arroz = new Arroz(base.txtNombre.Text, base.txtTipo.Text, (EMarca)Enum.Parse(typeof(EMarca), marca), (int)base.nUDCantidad.Value, (float)base.nUDPrecio.Value, this.txtOrigen.Text, this.txtProveedor.Text);
                producto = arroz;
                //Se verifica que el producto ingresado no exita en la listaDeProductos del formulario principal
                //Si esta no se agrega y se informa.Caso contrario lo agrega y se recetean los campos del formulario
                if (base.Comparar(arroz))
                {
                    MessageBox.Show($"El producto que intenta ingresar ya existe", "ATENCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    base.agregar(arroz);
                    base.LimpiarCampos();

                    if (modifica)
                    {
                        MessageBox.Show($"El producto ha sido modificado con éxito", "Producto Ingresado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show($"El producto ha sido ingresado con éxito", "Producto Ingresado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnCancelar2_Click(object sender, EventArgs e)
        {
            if (modifica)
            {
                this.Close();

            }
            else
            {

                base.LimpiarCampos();
                this.modifica = false;
            }
        }
    }
}
