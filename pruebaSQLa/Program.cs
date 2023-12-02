using Control_de_ingresos;
using System.Reflection;
using System;
using System.ComponentModel;

internal class Program
{
    static void Main(string[] args)
    {
        Arroz arroz1 = new Arroz("Arroz blanco", "Arroz", (EMarca)Enum.Parse(typeof(EMarca), "Gallo"), 3, 500f, "Argentina", "Pablo");

        DatosTabla<Arroz>.AgregarObjeto(arroz1);    

        Console.ReadKey();
    }
}