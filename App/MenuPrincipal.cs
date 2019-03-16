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
        private const float precioLocal = 1.25f;

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
                    Clear();
                    WriteLine("1. Registrar llamada Local");
                    WriteLine("2. Registrar llamada departamental");
                    WriteLine("3. Costo total de las llamadas locales");
                    WriteLine("4. Costo total de las llamdas departamentales");
                    WriteLine("5. Costo total de las llamdas");
                    WriteLine("6. Mostrar resumen");
                    WriteLine("0. Salir");
                    WriteLine("Ingrese su opción===>");
                    string valor = ReadLine();
                    if (EsNumero(valor) == true )
                    {
                        opcion = Convert.ToInt16(valor);   
                    }    
                    if (opcion == 1)
                    {
                        RegistrarLlamada(opcion);
                    }
                    else if (opcion == 2)
                    {
                        RegistrarLlamada(opcion);
                    }
                    else if(opcion == 3) 
                    {
                        MostrarCostoLlamadasLocales();
                    }
                    else if(opcion == 4)
                    {
                        MostrarDetalleLlamadasDepto();
                    }
                    else if (opcion == 6)
                    {
                        MostrarDetalle();
                    }
                }
                catch(OpcionMenuException e)
                {
                    WriteLine(e.Message);
                }
            } while (opcion != 0);
        }

        public Boolean EsNumero(string valor)
        {
            Boolean resultado = false;
            try
            {
                int numero = Convert.ToInt16(valor);
                resultado = true;
            }catch(Exception e)
            {
                throw new OpcionMenuException();
            }
            return resultado;
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
                ((LlamadaDepartamental)llamada).Franja = calcularFranja(DateTime.Now);
            }
            else
            {
                WriteLine("Tipo de llamada no registrado");
            }
            this.ListaDeLlamadas.Add(llamada);
        }

        public void MostrarDetalle()
        {
            foreach (var llamada in ListaDeLlamadas)
            {
                WriteLine(llamada);
            }
        }
        public void MostrarCostoLlamadasLocales()
        {
            double tiempoLlamada = 0;
            double costoTotal = 0.0;
            foreach(var elemento in ListaDeLlamadas)
            {
                if(elemento.GetType() == typeof(LlamadaLocal))
                {
                    tiempoLlamada += elemento.Duracion; 
                    costoTotal  += elemento.CalcularPrecio();                
                }
            }
            WriteLine($"Costo minuto: {precioLocal}");
            WriteLine($"Tiempo total de llamadas: {tiempoLlamada}");
            WriteLine($"Costo total: {costoTotal}");
        }

        public void MostrarDetalleLlamadasDepto()
        {
            double tiempoLlamadaFranjaUno = 0;
            double tiempoLlamadaFranjaDos = 0;
            double tiempoLlamadaFranjaTres = 0;
            double costoTotalFranjaUno = 0.0;
            double costoTotalFranjaDos = 0.0;
            double costoTotalFranjaTres = 0.0;            
            foreach(var elemento in ListaDeLlamadas)
            {
                if(elemento.GetType() == typeof(LlamadaDepartamental))
                {
                    switch(((LlamadaDepartamental)elemento).Franja)
                    {
                        case 0:
                            tiempoLlamadaFranjaUno += elemento.Duracion;
                            costoTotalFranjaUno += elemento.CalcularPrecio();
                            break;
                        case 1:
                            tiempoLlamadaFranjaDos += elemento.Duracion;
                            costoTotalFranjaDos += elemento.CalcularPrecio();
                            break;
                        case 2:
                            tiempoLlamadaFranjaTres += elemento.Duracion;
                            costoTotalFranjaTres += elemento.CalcularPrecio();
                            break;
                    }
                }                
            }
            WriteLine("Franja: 1");
            WriteLine($"Costo minuto: {precioUnoDepartamental}");
            WriteLine($"Tiempo total de llamadas: {tiempoLlamadaFranjaUno}");
            WriteLine($"Costo total: {costoTotalFranjaUno}");

            WriteLine("Franja: 2");
            WriteLine($"Costo minuto: {precioDosDepartamental}");
            WriteLine($"Tiempo total de llamadas: {tiempoLlamadaFranjaDos}");
            WriteLine($"Costo total: {costoTotalFranjaDos}");

            WriteLine("Franja: 3");
            WriteLine($"Costo minuto: {precioTresDepartamental}");
            WriteLine($"Tiempo total de llamadas: {tiempoLlamadaFranjaTres}");
            WriteLine($"Costo total: {costoTotalFranjaTres}");

        }

        public int calcularFranja(DateTime fecha)
        {
            int resultado = -1;

            return resultado; // 0,1,2
        }
    }

}




