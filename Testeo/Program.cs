using Control_de_ingresos;
using System.Drawing;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Collections;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine($"Main hilo principal ={Thread.CurrentThread.ManagedThreadId}");


        Task cargarProductos = new Task(() =>
        {
            Console.WriteLine($"Hilo Segundario ={Thread.CurrentThread.ManagedThreadId}");

            for (int i = 1; i<5 ; i++)
            {
                Console.WriteLine($"Se ingreso producto {i}");
            }
        });

        cargarProductos.Start();
        Console.WriteLine("Empieza la carga de productos");

        cargarProductos.Wait();

        Console.WriteLine("Fin del hilo principal");

    }





















}
