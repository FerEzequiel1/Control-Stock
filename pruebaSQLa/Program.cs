using Control_de_ingresos;
internal class Program
{
    static void Main(string[] args)
    {
        AccesoDatos ado = new AccesoDatos();

        if (ado.Prueba())
        {
            Console.WriteLine("Se conecto");
        }
        else
        {
            Console.WriteLine("No se conecto");
        }

        Console.ReadKey();
    }
}