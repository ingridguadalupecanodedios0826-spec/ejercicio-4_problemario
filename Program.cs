
using System;

namespace Ejercicio4
{
    // Clase que representa una bateria.
    class Bateria
    {
        // Propiedades de la bateria.
        public double VoltajeInicial { get; private set; }
        public double Incremento { get; private set; }
        public double VoltajeActual { get; private set; }
        public double VoltajeObjetivo { get; private set; }
        public int Ciclo { get; private set; }

        // Constructor de la clase.
        public Bateria()
        {
            VoltajeObjetivo = 12.6;
            Ciclo = 0;
        }

        // Solicita y valida los datos de entrada.
        public void CargarDatos()
        {
            while (true)
            {
                Console.Write("Voltaje inicial de la bateria (V): ");

                if (double.TryParse(Console.ReadLine(), out double v) &&
                    !double.IsNaN(v) && !double.IsInfinity(v) &&
                    v >= 0 && v <= VoltajeObjetivo)
                {
                    VoltajeInicial = v;
                    break;
                }

                Console.WriteLine(
                    "Error: ingrese un voltaje entre 0 y 12.6 V.");
            }

            while (true)
            {
                Console.Write("Incremento por ciclo (V): ");

                if (double.TryParse(Console.ReadLine(), out double inc) &&
                    !double.IsNaN(inc) && !double.IsInfinity(inc) &&
                    inc > 0)
                {
                    Incremento = inc;
                    break;
                }

                Console.WriteLine(
                    "Error: el incremento debe ser mayor que 0 V.");
            }

            VoltajeActual = VoltajeInicial;
        }

        // Incrementa el voltaje hasta alcanzar el objetivo.
        public void Cargar()
        {
            while (VoltajeActual < VoltajeObjetivo)
            {
                Ciclo++;

                VoltajeActual += Incremento;

                // Ajusta el ultimo incremento al limite establecido.
                if (VoltajeActual > VoltajeObjetivo)
                {
                    VoltajeActual = VoltajeObjetivo;
                }

                Console.WriteLine(
                    $"Ciclo {Ciclo}: {VoltajeActual:F2} V");
            }
        }

        // Muestra los resultados finales.
        public void MostrarResultados()
        {
            Console.WriteLine("\n--- RESULTADO DE CARGA ---");
            Console.WriteLine($"Ciclos realizados: {Ciclo}");
            Console.WriteLine($"Voltaje final: {VoltajeActual:F2} V");
            Console.WriteLine("Estado: CARGA COMPLETADA");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SISTEMA DE CARGA DE UNA BATERIA");
            Console.WriteLine("Voltaje objetivo: 12.60 V\n");

            // Creacion del objeto.
            Bateria bateria1 = new Bateria();

            bateria1.CargarDatos();
            bateria1.Cargar();
            bateria1.MostrarResultados();

            Console.WriteLine("\nPresione una tecla para finalizar.");
            Console.ReadKey();
        }
    }
}
