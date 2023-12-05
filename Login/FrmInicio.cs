using Control_de_ingresos;
using Login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Aplicacion
{
    /// <summary>
    /// Este formulario va a contener toda la interfaz que el usuario va a ver luego de estar logeado
    /// </summary>
    public partial class FrmInicio : Form
    {
        internal Usuario usuario;
        internal bool guardado;
        public ListaProductos listaDeProductos;
        public FrmInicio()
        {
            InitializeComponent();
        }
        //Se recibe por parametro el usuario que se logea y se guarda en su atributo
        public FrmInicio(Usuario usuario) : this()
        {
            this.usuario = usuario;
        }

        /// <summary>
        /// Se genera una lista generica que se guarda de forma local en una serializacion.
        /// Se genera la fecha que se logea el usario.
        /// Se llama a la funcion UsuariosLogeados para guardar ese usuario en el historial
        /// y se inicializa el txto del label que contiene la informacion del usuario que se va a mostrar por pantalla
        /// Adicionalmente se obtiene el path donde guardamos la lista generica pedida para la evaluación mediante el método Path(), y se deserializa
        /// la lista generica asignandola al atributo listaDeProductos del form con el que se va a trabajar durante todo el CRUD.
        /// Se llama al método PublicarProductos() para mostrar los productos en un Text Box.
        /// 
        /// </summary>

        private void FrmInicio_Load(object sender, EventArgs e)
        {
            GenerarListas();

            DateTime fechaActual = DateTime.Now;
            this.lblUsuario.Text = $"{this.usuario.ToString()} {fechaActual.Day}/{fechaActual.Month}/{fechaActual.Year}";

            UsuariosLogeados(this.usuario);

            string path = Path();
            this.listaDeProductos = Producto.Deserializar(path);
            PublicarProductos();

        }

        /// <summary>
        /// Opciones para agregar un producto dependiendo del tipo donde le haya clickeado el usuario
        /// podra añadir un producto a la lista.
        /// Se abrira un formulario distinto dependiendo de su elección
        /// </summary>

        private void gaseosaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrearFormulario("Gaseosa");
        }
        private void arrozToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrearFormulario("Aarroz");
        }
        private void salchichaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrearFormulario("Gaseosa por mayor");
        }
        private void milanesasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrearFormulario("Milanesas");
        }


        /// <summary>
        /// Ordena la lista en el List Box segun el criterio de chekeo 
        /// </summary>
        /// 
        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            if (rbCantidad.Checked && rbMayor.Checked)
            {
                listaDeProductos.OrdenPorPrecioCantidad("Descendente", "Cantidad");
            }
            else if (rbCantidad.Checked && !rbMayor.Checked)
            {
                listaDeProductos.OrdenPorPrecioCantidad("Ascendente", "Cantidad");

            }
            else if (!rbCantidad.Checked && rbMayor.Checked)
            {
                listaDeProductos.OrdenPorPrecioCantidad("Descendente", "Precio total");
            }
            else
            {
                listaDeProductos.OrdenPorPrecioCantidad("Ascendente", "Precio total");
            }

            PublicarProductos();
        }

        /// <summary>
        /// Muestra todos los elemnetos de la lista en el List Box
        /// </summary>
        public void PublicarProductos()
        {
            lstProductos.Items.Clear();
            foreach (Producto p in this.listaDeProductos.ListaDeProductos)
            {
                lstProductos.Items.Add(p);
            }
        }

        /// <summary>
        /// Crea los formularios de las opciones del menú segun la necesidad del usuario.
        /// Una vez cerrados se usa el metodo ActualizarLista() para asignarle los cambios que se hicieron
        /// en la lista al atributo listaDeProductos del formulario de inicio
        /// 
        /// </summary>

        public void CrearFormulario(string tipo)
        {
            switch (tipo)
            {
                case "Aarroz":

                    FrmAarroz frmAarroz = new FrmAarroz(this.listaDeProductos);
                    frmAarroz.StartPosition = FormStartPosition.CenterScreen;
                    frmAarroz.ShowDialog();
                    ActualizarLista(frmAarroz);
                    break;

                case "Gaseosa":

                    FrmGaseosa frmGaseosa = new FrmGaseosa(this.listaDeProductos);
                    frmGaseosa.StartPosition = FormStartPosition.CenterScreen;
                    frmGaseosa.ShowDialog();
                    ActualizarLista(frmGaseosa);
                    break;

                case "Gaseosa por mayor":

                    FrmGaseosaPorMayor gaseosaPorMayor = new FrmGaseosaPorMayor(this.listaDeProductos);
                    gaseosaPorMayor.StartPosition = FormStartPosition.CenterScreen;
                    gaseosaPorMayor.ShowDialog();
                    ActualizarLista(gaseosaPorMayor);
                    break;

                case "Milanesas":

                    FrmMilanesas milanesa = new FrmMilanesas(this.listaDeProductos);
                    milanesa.StartPosition = FormStartPosition.CenterScreen;
                    milanesa.ShowDialog();
                    ActualizarLista(milanesa);
                    break;
            }
        }
        /// <summary>
        /// se asigna los cambios que se hicieron en la lista de los formularios 
        /// utilizados, al atributo listaDeProductos del formulario de inicio
        /// </summary>

        public void ActualizarLista(FrmAgregarProducto form)
        {
            if (form.DialogResult == DialogResult.OK)
            {
                this.listaDeProductos = form.lista;
            }
            PublicarProductos();

        }

        private string Path()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            path += @"\Mayorista Trapal";

            return path;
        }

        /// <summary>
        /// Se crea y/o añade perfiles que se logeen en un archivo para luego ser visualizados en el historial de logeos
        /// </summary>
        /// <param name="perfil"></param>
        private void UsuariosLogeados(Usuario perfil)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            path += @"\registro.log";

            try
            {
                // Abre un archivo de registro para escribir (crea uno nuevo o agrega al existente)
                using (StreamWriter logWriter = new StreamWriter(path, true))
                {
                    // Obtiene la fecha y hora actual
                    DateTime fechaHoraActual = DateTime.Now;

                    // Mensaje de registro a escribir en el archivo
                    string mensajeRegistro = $"Nombre:{perfil.nombre} Apellido:{perfil.apellido} Legajo:{perfil.legajo}  Dia de ingreso:{fechaHoraActual:yyyy-MM-dd HH:mm:ss}";

                    // Escribe el mensaje de registro en el archivo
                    logWriter.WriteLine(mensajeRegistro);
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error al escribir en el archivo de registro: " + ex.Message);
            }

        }

        /// <summary>
        /// Crea el formulario donde se va a leer el archivo de historial de gente logeada para mostrarlo en un list box
        /// Se crea el path donde esta la ruta del archivo a leer y se lo pasa por parametro al FrmHistorial para su uso
        /// </summary>

        private void historialDePersonasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            path += @"\registro.log";

            FrmHistorial frmHistorial = new FrmHistorial(path);
            frmHistorial.StartPosition = FormStartPosition.CenterScreen;
            frmHistorial.Show();

        }
        /// <summary>
        /// Se asegura de que el usario quiera verdaderamente irse de la apliacion y si no guardo los cambios los pueda guardar
        /// </summary>
        private void FrmInicio_FormClosing(object sender, FormClosingEventArgs e)
        {

            DialogResult resultado = MessageBox.Show("¿Realmente desea cerrar el formulario?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.No)
            {
                e.Cancel = true; // Cancelar el cierre del formulario
            }

            if (this.guardado == false)
            {
                DialogResult guardado = MessageBox.Show("¿Desea cerrar el formulario sin guardar los cambios?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (guardado == DialogResult.No)
                {
                    e.Cancel = true; // Cancelar el cierre del formulario si escoje guardar
                }
            }

        }

        /// <summary>
        /// Guarda la listaDeProductos en una ruta a elección del usuario
        /// </summary>

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Title = "Guardar archivo XML";
            saveFileDialog.Filter = "Archivos XML (*.xml)|*.xml";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string rutaArchivo = saveFileDialog.FileName;

                // Realizar la serialización en el archivo XML seleccionado
                using (FileStream stream = new FileStream(rutaArchivo, FileMode.Create))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(ListaProductos));
                    serializer.Serialize(stream, this.listaDeProductos);
                    this.guardado = true;
                }

            }
        }

        /// <summary>
        /// Carga una listaDeProductos de una ruta a elección del usuario
        /// asignandola al atributo listaDeProductos del formulario principal
        /// </summary>
        private void btnCargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "Seleccionar archivo XML para deserialización";
            openFileDialog.Filter = "Archivos XML (*.xml)|*.xml";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string rutaArchivo = openFileDialog.FileName;

                // Realizar la deserialización desde el archivo XML seleccionado
                using (FileStream stream = new FileStream(rutaArchivo, FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(ListaProductos));
                    ListaProductos tuObjetoDeserializado = (ListaProductos)serializer.Deserialize(stream);
                    this.listaDeProductos = tuObjetoDeserializado;
                    PublicarProductos();
                }

            }
        }

        /// <summary>
        /// Se guarda en un un archivo HML una listaDeProductos para que quede en forma local y poderla levantar desdel este Formulario de inicio en el momento del Load,
        /// Se usa todas las clases tipo producto para tener un variado de productos y se serializa con la instancia de clase Producto.Serializar.
        /// </summary>
        private void GenerarListas()
        {
            Arroz arroz1 = new Arroz("Arroz blanco", "Arroz", (EMarca)Enum.Parse(typeof(EMarca), "Gallo"), 3, 500f, "Brasil", "Pablo");
            Arroz arroz2 = new Arroz("Arroz Integral", "Arroz", (EMarca)Enum.Parse(typeof(EMarca), "Gallo"), 5, 600f, "Argentina", "Chacra Gonzalez");
            Arroz comboArroz = arroz1 + arroz2;


            Gaseosa gaseosa1 = new Gaseosa("Seven up", "Gaseosa", (EMarca)Enum.Parse(typeof(EMarca), "SevenUp"), 3, 500f, 3f, "Lima");
            Gaseosa gaseosa2 = new Gaseosa("Pepsi", "Gaseosa", (EMarca)Enum.Parse(typeof(EMarca), "Pepsi"), 3, 500f, 3f, "Cola");

            GaseosaPorMayor gaseosaPorMayor1 = new GaseosaPorMayor("Trini", "Gaseosa Mayorista", (EMarca)Enum.Parse(typeof(EMarca), "Vienissima"), 4, 300f, 0.500f, "Uva", 1000, "Si");
            GaseosaPorMayor gaseosaPorMayor2 = new GaseosaPorMayor("Don Antonio", "Gaseosa Mayorista", (EMarca)Enum.Parse(typeof(EMarca), "Swift"), 4, 150f, 0.500f, "Naranja", 500, "No");
            GaseosaPorMayor gaseosaPorMayor3 = gaseosaPorMayor1 + gaseosaPorMayor2;

            Milanesas milanesa1 = new Milanesas("Fernando", "Milanesas", (EMarca)Enum.Parse(typeof(EMarca), "Gallo"), 20, 300f, "Vacuno", "Brasil");
            Milanesas milanesa2 = new Milanesas("Franco", "Milanesas", (EMarca)Enum.Parse(typeof(EMarca), "Gallo"), 20, 300f, "Bovino", "Argentino");
            Milanesas bandeja = milanesa1 + milanesa2;

            List<Producto> productos = new List<Producto>();

            productos.Add(arroz1);
            productos.Add(arroz2);
            productos.Add(comboArroz);
            productos.Add(gaseosa1);
            productos.Add(gaseosa2);
            productos.Add(gaseosaPorMayor1);
            productos.Add(gaseosaPorMayor2);
            productos.Add(gaseosaPorMayor3);
            productos.Add(milanesa1);
            productos.Add(milanesa2);
            productos.Add(bandeja);

            ListaProductos listaDeProductos = new(productos);

            string path = Path();

            Producto.Serializar(listaDeProductos, path);
        }
        /// <summary>
        /// Se realiza una modificación en el producto seleccioando y se lo reingresa a la lista.
        /// </summary>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (usuario.perfil == "supervisor" || usuario.perfil == "administrador")
            {

                int indice = this.lstProductos.SelectedIndex;

                if (indice == -1)
                {
                    return;
                }
                //Se obtiene el producto seleccioando mediante el indice obtenido del lstProductos 

                Producto producto = this.listaDeProductos.ListaDeProductos[indice];

                //this.listaDeProductos.ListaDeProductos.Remove(producto);

                // Se verifica que de que tipo (Aarroz,gaseosa o gaseosa por mayor) es el producto para desplegar sus formularios de modificación correspondientes
                // y agregar el producto modificado a la lista

                if (producto is Arroz)
                {
                    Arroz productoArroz = producto as Arroz;
                    FrmAarroz frmAarroz = new FrmAarroz(this.listaDeProductos, productoArroz, true);
                    frmAarroz.StartPosition = FormStartPosition.CenterScreen;
                    frmAarroz.ShowDialog();

                    ActualizarLista(frmAarroz);
                    Producto productoModificado = ultimoProductoIngresado();
                    
                    if (frmAarroz.producto != producto)
                    {
                        productoArroz.ModificarElemento(productoArroz,(Arroz)productoModificado);
                        this.listaDeProductos.ListaDeProductos.Remove(producto);
                        PublicarProductos();
                    }
                   
                }
                else
                {
                    if (producto is Gaseosa)
                    {
                        Gaseosa productoGaseosa = producto as Gaseosa;
                        FrmGaseosa frmGaseosa = new FrmGaseosa(this.listaDeProductos, productoGaseosa, true);
                        frmGaseosa.StartPosition = FormStartPosition.CenterScreen;
                        frmGaseosa.ShowDialog();

                        ActualizarLista(frmGaseosa);
                        Producto productoModificado = ultimoProductoIngresado();

                        if (frmGaseosa.producto != producto)
                        {
                            this.listaDeProductos.ListaDeProductos.Remove(producto);
                            productoGaseosa.ModificarElemento(productoGaseosa, (Gaseosa)productoModificado);
                            PublicarProductos();
                        }

                    }
                    else
                    {
                        if (producto is GaseosaPorMayor)
                        {
                            GaseosaPorMayor productoGaseosaPorMayor = producto as GaseosaPorMayor;
                            FrmGaseosaPorMayor frmGaseosaMayor = new FrmGaseosaPorMayor(this.listaDeProductos, productoGaseosaPorMayor, true);
                            frmGaseosaMayor.StartPosition = FormStartPosition.CenterScreen;
                            frmGaseosaMayor.ShowDialog();
                            ActualizarLista(frmGaseosaMayor);
                        }
                        else
                        {
                            Milanesas milanesa = producto as Milanesas;
                            FrmMilanesas frmMilanesa = new FrmMilanesas(this.listaDeProductos, milanesa, true);
                            frmMilanesa.StartPosition = FormStartPosition.CenterScreen;
                            frmMilanesa.ShowDialog();
                            ActualizarLista(frmMilanesa);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show($"Su perfil es de vendedor,no puede modificar ningún producto.", "Perfil denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (usuario.perfil == "administrador")
            {
                int indice = this.lstProductos.SelectedIndex;
                if (indice >= 0)
                {
                    //Producto productoSeleccionado = (Producto)lstProductos.SelectedItem;

                    DialogResult resultado = MessageBox.Show("¿Realmente desea eliminar el producto?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resultado == DialogResult.Yes)
                    {
                        ManejadorEventos evento = new ManejadorEventos();
                        
                        Producto producto = (Producto)lstProductos.SelectedItem;

                        if (producto is Arroz)
                        {
                            evento.EliminarProductoArroz += MetodosDelegados.ElimnarProductoPorDelegadoArroz;
                            evento.Arroz = (Arroz)producto;
                        }
                        else if (producto is GaseosaPorMayor)
                        {
                            evento.EliminarProductoGaseosaMayor += MetodosDelegados.ElimnarProductoPorDelegadoGaseosaPorMayor;
                            evento.GaseosaPorMayor = (GaseosaPorMayor)producto;
                        }
                        else if (producto is Gaseosa)
                        {
                            evento.EliminarProductoGaseosa += MetodosDelegados.ElimnarProductoPorDelegadoGaseosa;
                            evento.Gaseosa = (Gaseosa)producto;
                        }
                        else
                        {
                            evento.EliminarProductoMilanesa += MetodosDelegados.ElimnarProductoPorDelegadoMilanesa;
                            evento.Milanesas = (Milanesas)producto;
                        }

                        evento.mensajeMarca += MetodosDelegados.mensajeEliminado;
                        evento.Marca = "Eliminar";
                        if(listaDeProductos - producto) PublicarProductos();


                    }
                }
                else
                {
                    MessageBox.Show($"Seleccione un producto para elimniar.", "No se encontro producto.", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
            else
            {
                MessageBox.Show($"Su perfil de {usuario.perfil} no puede realizar dicha acción.", "Producto eliminado.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Cracion de un metodo dentro del formulario principal para la obtencion del ultimo elemento ingresado para ser tratado en la base de datos
        private Producto ultimoProductoIngresado()
        {
            Producto producto = this.listaDeProductos.ListaDeProductos.Last();

            return producto;
        }
    }
}
