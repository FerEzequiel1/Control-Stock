using static WinFormsApp1.Delegados;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            mostrarEdad(2);
        }
         
        public void mostrarEdad(int nRet) 
        {
            Persona persona = new Persona();
            persona.mensaje1 += AccesoDelegadoscs.mensajeDelegado;
            persona.mensaje2 += AccesoDelegadoscs.mensajeDelegad2;
            persona.Edad = nRet;

        }
        
    }
}