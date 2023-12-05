using Control_de_ingresos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicacion
{
    public partial class FrmMilanesas : FrmAgregarProducto
    {
        bool modifica = false;
        public Milanesas producto;
        public FrmMilanesas(ListaProductos lista, Milanesas producto, bool modifica) : this(lista)
        {
            int indiceMarca = Array.IndexOf(Enum.GetValues(typeof(EMarca)), producto.Marca);
            this.txtNombre.Text = producto.Nombre;
            this.txtTipo.Text = producto.Tipo;
            this.cmbMarca.SelectedIndex = indiceMarca;
            this.nUDCantidad.Value = producto.Cantidad;
            this.nUDPrecio.Value = (decimal)producto.Precio;
            this.txtOrigenAnimal.Text = producto.OrigenAnimal;
            this.txtNacionalidad.Text = producto.Nacionalidad;
            this.modifica = modifica;
            this.producto = producto;   

        }
        public FrmMilanesas(ListaProductos lista) : base(lista)
        {
            InitializeComponent();
        }
        public FrmMilanesas()
        {

        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Se verifica a travez de los métodos si cumplen con los tipos de datos correctos para la creación del producto
            string marca = base.VerificarMarca();
            bool nombre = base.VerificarNombreTipo();

            if (marca != "no" && nombre)
            {
                Milanesas milanesa = new Milanesas(base.txtNombre.Text, base.txtTipo.Text, (EMarca)Enum.Parse(typeof(EMarca), marca), (int)base.nUDCantidad.Value, (float)base.nUDPrecio.Value, this.txtOrigenAnimal.Text, this.txtNacionalidad.Text);
                producto=milanesa;
                //Se verifica que el producto ingresado no exita en la listaDeProductos del formulario principal
                //Si esta no se agrega y se informa.Caso contrario lo agrega y se recetean los campos del formulario
                if (base.Comparar(milanesa))
                {
                    MessageBox.Show($"El producto que intenta ingresar ya existe", "ATENCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    base.agregar(milanesa);
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
