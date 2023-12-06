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
    /// Formulario donde se va a completar los datos pedidos para poder crear un producto tipo GaseosaPorMayor
    /// </summary>
    /// 

    public partial class FrmGaseosaPorMayor : FrmAgregarProducto
    {
        bool modifica = false;
        public GaseosaPorMayor producto;
        public FrmGaseosaPorMayor(ListaProductos lista, GaseosaPorMayor producto, bool modifica) : this(lista)
        {
            int indiceMarca = Array.IndexOf(Enum.GetValues(typeof(EMarca)), producto.Marca);

            this.txtNombre.Text = producto.Nombre;
            this.txtTipo.Text = producto.Tipo;
            this.cmbMarca.SelectedIndex = indiceMarca;
            this.nUDCantidad.Value = producto.Cantidad;
            this.nUDPrecio.Value = (decimal)producto.Precio;
            this.nUDUnidades.Value = producto.Unidades;
            this.txtArtesanal.Text = producto.Artesanal;
            this.nUDMLL.Value = (decimal)producto.Mililitros;
            this.txtSabor.Text = producto.Sabor;
            this.modifica = modifica;
            this.producto = producto;

        }
        public FrmGaseosaPorMayor(ListaProductos lista) : base(lista)
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Se verifica a travez de los métodos si cumplen con los tipos de datos correctos para la creación del producto

            string marca = base.VerificarMarca();
            bool artesanal = VerificarArtesanal();
            bool nombre = base.VerificarNombreTipo();

            if (marca != "no" && artesanal && nombre)
            {

                GaseosaPorMayor gaseosaPorMayor = new GaseosaPorMayor(base.txtNombre.Text, base.txtTipo.Text, (EMarca)Enum.Parse(typeof(EMarca), marca), (int)base.nUDCantidad.Value, (float)base.nUDPrecio.Value, (float)this.nUDMLL.Value, this.txtSabor.Text, (int)this.nUDUnidades.Value, this.txtArtesanal.Text);
                producto = gaseosaPorMayor;
                //Se verifica que el producto ingresado no exita en la listaDeProductos del formulario principal
                //Si esta no se agrega y se informa.Caso contrario lo agrega y se recetean los campos del formulario

                if (base.Comparar(gaseosaPorMayor))
                {
                    MessageBox.Show($"El producto que intenta ingresar ya existe", "ATENCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    base.agregar(gaseosaPorMayor);
                    base.LimpiarCampos();

                    if (modifica)
                    {
                        MessageBox.Show($"El producto ha sido modificado con éxito", "Producto Ingresado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        DatosTabla<GaseosaPorMayor>.AgregarObjeto(gaseosaPorMayor);
                        MessageBox.Show($"El producto ha sido ingresado con éxito", "Producto Ingresado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        /// <summary>
        /// Se verifica si los campos txtArtesanal y txtSabor fueron completados y no estan vacios y/o no reciben lo que piden.
        /// Si no reciben lo que piden lo informa por MessageBox
        /// </summary>

        private bool VerificarArtesanal()
        {
            bool valor = false;

            if ((this.txtArtesanal.Text == "Si" || this.txtArtesanal.Text == "No") && this.txtSabor.Text != null)
            {
                valor = true;
            }
            else
            {
                MessageBox.Show($"Debe responder con Si/No si es artesanal.", "ATENCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            return valor;
        }

        // Si se abrio en una instacia de modifiacion se cierra el formulairo,de lo contrario si se esta ingresando un producto borra los campos
        private void btnCancelar_Click_1(object sender, EventArgs e)
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
