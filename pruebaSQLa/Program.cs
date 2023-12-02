using Control_de_ingresos;
using System.Reflection;
using System;
using System.ComponentModel;

internal class Program
{
    static void Main(string[] args)
    {
        Arroz arroz1 = new Arroz("Arroz Integral", "Arroz", (EMarca)Enum.Parse(typeof(EMarca), "Gallo"), 25, 600f, "Argentina", "TOTI");
        Arroz arroz2 = new Arroz("Arroz Integral", "Arroz", (EMarca)Enum.Parse(typeof(EMarca), "Gallo"), 2, 1300f, "china", "pato");

        Gaseosa gaseosa2 = new Gaseosa("Seven up", "Gaseosa", (EMarca)Enum.Parse(typeof(EMarca), "SevenUp"), 3, 500f, 3f, "POMELO");
        Gaseosa gaseosa1 = new Gaseosa("Marisola", "Gaseosa", (EMarca)Enum.Parse(typeof(EMarca), "Gallo"), 3, 1500f, 3f, "uva");

       
        GaseosaPorMayor gaseosaPorMayor1 = new GaseosaPorMayor("Trini", "Gaseosa Mayorista", (EMarca)Enum.Parse(typeof(EMarca), "Vienissima"), 4, 300f, 500f, "Uva", 1000, "Si");
        
        GaseosaPorMayor gaseosaPorMayor2 = new GaseosaPorMayor("Pepcon", "Gaseosa Mayorista", (EMarca)Enum.Parse(typeof(EMarca), "SevenUp"), 4, 300f, 500f, "LIMA", 1000, "No");

        Milanesas milanga = new Milanesas("Fernando", "Milanesas", (EMarca)Enum.Parse(typeof(EMarca), "Gallo"), 20, 300f, "Vacuno", "Paraguay");
        Milanesas milanga2 = new Milanesas("CatMiau", "Milanesas", (EMarca)Enum.Parse(typeof(EMarca), "SevenUp"), 533, 200f, "Gato", "China");

        DatosTabla<GaseosaPorMayor>.EliminarProducto(gaseosaPorMayor1);
        


        Console.ReadKey();
    }
}