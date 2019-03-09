using System;
using static System.Console;
using CentralTelefonica.Entidades;
using System.Collections.Generic;
using CentralTelefonica.Util;
namespace CentralTelefonica.App
{
    public class MenuPrincipal
    {
        private const float precioUnoDepartamental = 0.65f;
        private const float precioDosDepartamental = 0.85f;
        private const float precioTresDepartamental = 0.98f;
        private const float precioLocal = 0.49f;

        // public List<Llamada> ListaDeLlamadas = new List<Llamada>();
        public List<Llamada> ListaDeLlamadas { get; set; }

        public MenuPrincipal()
        {
            this.ListaDeLlamadas = new List<Llamada>();
        }
        public void MostrarMenu()
        {
            int opcion = 100;
            do
            {
                try
                {
                    WriteLine("1. Registrar llamada Local");
                    WriteLine("2. Registrar llamada departamental");
                    WriteLine("3. Costo total de las llamadas locales");
                    WriteLine("4. Costo total de las llamdas departamentales");
                    WriteLine("5. Costo total de las llamdas");
                    WriteLine("6. Mostrar resumen");
                    WriteLine("0. Salir");
                    WriteLine("Ingrese su opción===>");
                    string valor = ReadLine();
                    opcion = Convert.ToInt16(valor);
                    if (opcion == 1)
                    {
                        RegistrarLlamada(opcion);
                    }
                    else if (opcion == 2)
                    {
                        RegistrarLlamada(opcion);
                    }
                    else if (opcion == 6)
                    {
                        MostrarDetalleForeach();
                    }
                }
                catch (Exception e)
                {
                    throw new OpcionMenuException();
                }
            } while (opcion != 0);
        }
        public void RegistrarLlamada(int opcion)
        {
            string numeroOrigen = "";
            string numeroDestino = "";
            string duracion = "";
            Llamada llamada = null;
            WriteLine("Ingrese el número de origen");
            numeroOrigen = ReadLine();
            WriteLine("Ingrese el número de destino");
            numeroDestino = ReadLine();
            WriteLine("Duración de la llamada");
            duracion = ReadLine();
            if (opcion == 1)
            {
                llamada = new LlamadaLocal(numeroOrigen, numeroDestino, Convert.ToDouble(duracion));
                ((LlamadaLocal)llamada).Precio = precioLocal;
            }
            else if (opcion == 2)
            {
                llamada = new LlamadaDepartamental(numeroOrigen, numeroDestino, Convert.ToDouble(duracion));
                ((LlamadaDepartamental)llamada).PrecioUno = precioUnoDepartamental;
                ((LlamadaDepartamental)llamada).PrecioDos = precioDosDepartamental;
                ((LlamadaDepartamental)llamada).PrecioTres = precioDosDepartamental;
                ((LlamadaDepartamental)llamada).Franja = 0;
            }
            else
            {
                WriteLine("Tipo de llamada no registrado");
            }
            this.ListaDeLlamadas.Add(llamada);
        }
        public void MostrarDetalleWhile()
        {
            int i = 0;
            while (this.ListaDeLlamadas.Count > i)
            {
                WriteLine(this.ListaDeLlamadas[i]);
                i = i + 1;
                //i++;
                //i+=1;
            }
        }
        public void MostrarDetalleDoWhile()
        {
            int i = 0;
            do
            {
                WriteLine(this.ListaDeLlamadas[i]);
                i++;
            } while (this.ListaDeLlamadas.Count > i);
        }
        public void MostrarDetalleFor()
        {
            for (int i = 0; i < this.ListaDeLlamadas.Count; i++)
            {
                WriteLine(this.ListaDeLlamadas[i]);
            }
            for (; ; )
            {

            }
        }

        public void MostrarDetalleForeach()
        {
            foreach (var llamada in ListaDeLlamadas)
            {
                WriteLine(llamada);
            }
        }
    }
}