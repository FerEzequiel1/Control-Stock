using Control_de_ingresos;
internal class Program
{
    static void Main(string[] args)
    {
        AccesoDatos ado = new AccesoDatos();

        List<Arroz> list = ado.obtenerLista();

        foreach (Arroz arroz in list)
        {
            Console.WriteLine(arroz.ToString());
        } 

        Console.ReadKey();
    }
}