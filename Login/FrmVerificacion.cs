using Control_de_ingresos;
using System.IO;
using System;
using System.Text.Json;


namespace Login
{
    /// <summary>
    /// Primer formulario que se va mostrar en el programa donde el usuario se tendra que logear, pasando por tandas de verificación
    /// consultando a la base de datos para ingresar alCRUD principal.
    /// </summary>
    public partial class FrmVerificacion : Form
    {
        private Usuario usuario;

        public Usuario UsuarioIngresante
        {
            get { return usuario; }
        }
        public FrmVerificacion()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Se inicializa los atributos de la clase y se llama al constructor sin parametros por sobrecarga
        /// </summary>
        public FrmVerificacion(Usuario usuario) : this()
        {
            this.usuario = usuario;
            this.txtUsuario.Focus();

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            this.usuario = this.Verificar();
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Verificacion de los datos ingresados por el usuario con la base de datos
        /// </summary>
        /// <returns>
        /// Usuario logeado o null si no se encuentra.
        /// </returns>
        private Usuario Verificar()
        {
            Usuario rta = null;

            // Se pasa la URL de la ubicación del archivo JSON usado como base de dato para el analisis

            using (System.IO.StreamReader sr = new System.IO.StreamReader(@"..\\..\\..\\DataUsuarios.json"))
            {
                System.Text.Json.JsonSerializerOptions opciones = new System.Text.Json.JsonSerializerOptions();
                opciones.WriteIndented = true;

                string json_str = sr.ReadToEnd();

                
                List<Usuario> users = JsonSerializer.Deserialize<List<Usuario>>(json_str, opciones);

                // Se verifica a travez de la lista de usuarios deserializada con ayuda de la clases Usuario si 
                //los datos brindados por el usario coinciden con algun usurio registrado en el archivo JSON.

                foreach (Usuario item in users)
                {
                    if (item.correo == this.txtUsuario.Text && item.clave == this.txtContraseña.Text)
                    {
                        rta = item;
                        break;
                    }
                }
            }
            return rta;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Cada caracter de la contraseña puesta en el form se muestra como una * para portección de la misma.
        /// Con este método se cambia es simbolo por la contraseña textual que ingreso el usuario para poder ser visualizada.
        /// </summary>
       
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkContraseña.Checked)
            {
                this.txtContraseña.PasswordChar = '\0';

            }
            else
            {
                this.txtContraseña.PasswordChar = '*';

            }
        }

    }
}