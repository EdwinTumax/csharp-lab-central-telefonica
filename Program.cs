using System;
using System.Collections.Generic;
using CentralTelefonica.Entidades;
using CentralTelefonica.App;
using CentralTelefonica.Util;
namespace CentralTelefonica
{
    class Program
    {
        static void Main(string[] args)
        {
                DateTime fecha = DateTime.Now;
                Console.WriteLine($"fecha: {fecha}" );     
                Console.WriteLine($"Dia: {fecha.DayOfWeek}" );
                Console.WriteLine($"Hora: {fecha.Hour}");
                Console.WriteLine($"Minuto {fecha.Minute}");           
                MenuPrincipal menu = new MenuPrincipal();
                menu.MostrarMenu();                
        }
    }
}
