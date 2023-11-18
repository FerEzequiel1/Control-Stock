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
    /// Este Formulario muestra a todos los usuarios que se logearon en el tiempo
    /// </summary>
    public partial class FrmHistorial : Form
    {
        public string path;
        public FrmHistorial(string path)
        {
            this.path = path;
            InitializeComponent();
        }

        private void FrmHistorial_Load(object sender, EventArgs e)
        {
            try
            {
                // Verifica si el archivo existe antes de intentar leerlo
                if (File.Exists(this.path))
                {
                    // Abre el archivo de registro para lectura
                    using (StreamReader logReader = new StreamReader(this.path))
                    {
                        string linea;
                        while ((linea = logReader.ReadLine()) != null)
                        {
                            // Procesa cada línea del archivo de registro
                            this.lstHistorial.Items.Add(linea);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("El archivo de registro no existe.");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error al leer el archivo de registro: " + ex.Message);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
