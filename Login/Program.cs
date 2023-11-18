using Aplicacion;

namespace Login
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            //ApplicationConfiguration.Initialize();
            //Application.Run(new FrmVerificacion());

            //Creo una instacia del formulario de verificacion

            FrmVerificacion frmVerificacion = new FrmVerificacion();

            frmVerificacion.StartPosition = FormStartPosition.CenterScreen;

            int intentos = 0;

            try
            {
                frmVerificacion.ShowDialog();


                while (intentos < 3 && frmVerificacion.DialogResult != DialogResult.Cancel)
                {
                    if (intentos == 2 && frmVerificacion.UsuarioIngresante == null)
                    {
                        MessageBox.Show("Se exedio la cantidad de intentos,intente nuevamentes más tarde.", "ATENCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    else if (frmVerificacion.UsuarioIngresante == null)
                    {
                        MessageBox.Show("Error en usario y/o contraseña", "CREDENCIALES", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        frmVerificacion.ShowDialog();
                    }
                    intentos++;

                    if (frmVerificacion.UsuarioIngresante != null)
                    {

                        FrmInicio frmInicio = new FrmInicio(frmVerificacion.UsuarioIngresante);
                        frmInicio.StartPosition = FormStartPosition.CenterScreen;

                        frmVerificacion.DialogResult= DialogResult.Cancel;
                        Application.Run(frmInicio);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error del tipo {ex}", "ATENCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        
     } 
}
