using Control_de_ingresos;
using System.Reflection;
using System;
using System.ComponentModel;

internal class Program
{
    static void Main(string[] args)
    {
        Arroz arroz1 = new Arroz("Arroz blanco", "Arroz", (EMarca)Enum.Parse(typeof(EMarca), "Gallo"), 3, 500f, "Brasil", "Pablo");
        Arroz arroz2 = new Arroz("Arroz Integral", "Arroz", (EMarca)Enum.Parse(typeof(EMarca), "Gallo"), 5, 600f, "Argentina", "Chacra Gonzalez");
        


        Gaseosa gaseosa1 = new Gaseosa("Seven up", "Gaseosa", (EMarca)Enum.Parse(typeof(EMarca), "SevenUp"), 3, 500f, 3f, "Lima");
        Gaseosa gaseosa2 = new Gaseosa("Pepsi", "Gaseosa", (EMarca)Enum.Parse(typeof(EMarca), "Pepsi"), 3, 500f, 3f, "Cola");

        GaseosaPorMayor gaseosaPorMayor1 = new GaseosaPorMayor("Trini", "Gaseosa Mayorista", (EMarca)Enum.Parse(typeof(EMarca), "Vienissima"), 4, 300f, 0.500f, "Uva", 1000, "Si");
        GaseosaPorMayor gaseosaPorMayor2 = new GaseosaPorMayor("Don Antonio", "Gaseosa Mayorista", (EMarca)Enum.Parse(typeof(EMarca), "Swift"), 4, 150f, 0.500f, "Naranja", 500, "No");

        Milanesas milanesa1 = new Milanesas("Fernando", "Milanesas", (EMarca)Enum.Parse(typeof(EMarca), "Gallo"), 20, 300f, "Vacuno", "Brasil");
        Milanesas milanesa2 = new Milanesas("Franco", "Milanesas", (EMarca)Enum.Parse(typeof(EMarca), "Gallo"), 20, 300f, "Bovino", "Argentino");
        


      
        DatosTabla<Gaseosa>.AgregarObjeto(gaseosa1);
        DatosTabla<Gaseosa>.AgregarObjeto(gaseosa2);
      
        



        Console.ReadKey();
    }
}