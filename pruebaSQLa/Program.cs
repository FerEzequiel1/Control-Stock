using Control_de_ingresos;
using System.Reflection;
using System;
using System.ComponentModel;

internal class Program
{
    static void Main(string[] args)
    {
        Arroz arroz1 = new Arroz("Arroz blanco", "Arroz", (EMarca)Enum.Parse(typeof(EMarca), "Gallo"), 3, 500f, "Argentina", "Pablo");
        Gaseosa gaseosa1 = new Gaseosa("Seven up", "Gaseosa", (EMarca)Enum.Parse(typeof(EMarca), "SevenUp"), 3, 500f, 3f, "POMELO");
        GaseosaPorMayor gaseosaPorMayor1 = new GaseosaPorMayor("Trini", "Gaseosa Mayorista", (EMarca)Enum.Parse(typeof(EMarca), "Vienissima"), 4, 300f, 500f, "Uva", 1000, "Si");



        DatosTabla<GaseosaPorMayor>.AgregarObjeto(gaseosaPorMayor1);

        Console.ReadKey();
    }
}