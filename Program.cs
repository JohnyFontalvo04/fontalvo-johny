using System;
using System.IO;

class Program
{
    static int tarjetasValidas = 0;
    static int tarjetasInvalidas = 0;

    static int cantidadVisa = 0;
    static int cantidadMastercard = 0;
    static int cantidadAmericanExpress = 0;
    static int cantidadDiscover = 0;
    static int cantidadDesconocidas = 0;

    static Random generadorAleatorio = new Random();

    static void Main()
    {
        int opcionMenu;

        do
        {
            Console.Clear();
            Console.WriteLine("=== VALIDADOR DE TARJETAS ===");
            Console.WriteLine("1. Validar una tarjeta");
            Console.WriteLine("2. Validar desde archivo");
            Console.WriteLine("3. Generar número válido");
            Console.WriteLine("4. Estadísticas");
            Console.WriteLine("5. Salir");

            Console.Write("Seleccione una opción: ");
            opcionMenu = Convert.ToInt32(Console.ReadLine());

            switch (opcionMenu)
            {
                case 1:
                    ValidarTarjetaManual();
                    break;

                case 2:
                    Console.Write("Ingrese la ruta del archivo: ");
                    string rutaArchivo = Console.ReadLine();
                    ValidarTarjetasDesdeArchivo(rutaArchivo);
                    break;

                case 3:
                    string numeroGenerado = GenerarNumeroValido();

                    Console.WriteLine();
                    Console.WriteLine("Número generado: " + numeroGenerado);
                    Console.WriteLine("Marca: " + IdentificarMarca(numeroGenerado));

                    Console.WriteLine();
                    Console.WriteLine("Presione una tecla para continuar...");
                    Console.ReadKey();
                    break;

                case 4:
                    MostrarEstadisticas();
                    break;

                case 5:
                    Console.WriteLine("Saliendo del programa...");
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    Console.ReadKey();
                    break;
            }

        } while (opcionMenu != 5);
    }
    static void ValidarTarjetaManual()
    {
        Console.Clear();

        Console.Write("Ingrese el número de tarjeta: ");
        string numeroTarjeta = Console.ReadLine();

        string marcaTarjeta = IdentificarMarca(numeroTarjeta);
        bool esValida = ValidarTarjeta(numeroTarjeta);

        Console.WriteLine();
        Console.WriteLine("Número: " + numeroTarjeta);
        Console.WriteLine("Marca: " + marcaTarjeta);

        if (esValida)
        {
            Console.WriteLine("Estado: [✓] VÁLIDA");
        }
        else
        {
            Console.WriteLine("Estado: [X] INVÁLIDA");
        }

        ActualizarEstadisticas(esValida, marcaTarjeta);

        Console.WriteLine();
        Console.WriteLine("Presione una tecla para continuar...");
        Console.ReadKey();
    }
    static bool ValidarTarjeta(string numeroTarjeta)
    {
        int sumaDigitos = 0;
        bool duplicarDigito = false;

        for (int posicion = numeroTarjeta.Length - 1; posicion >= 0; posicion--)
        {
            if (!char.IsDigit(numeroTarjeta[posicion]))
            {
                return false;
            }

            int digitoActual = numeroTarjeta[posicion] - '0';

            if (duplicarDigito)
            {
                digitoActual = digitoActual * 2;

                if (digitoActual > 9)
                {
                    digitoActual = digitoActual - 9;
                }
            }

            sumaDigitos = sumaDigitos + digitoActual;
            duplicarDigito = !duplicarDigito;
        }

        if (sumaDigitos % 10 == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    static string IdentificarMarca(string numeroTarjeta)
    {
        if (numeroTarjeta.StartsWith("4") &&
            (numeroTarjeta.Length == 13 || numeroTarjeta.Length == 16))
        {
            return "Visa";
        }

        if (numeroTarjeta.Length == 16)
        {
            int prefijoTarjeta = Convert.ToInt32(numeroTarjeta.Substring(0, 2));

            if (prefijoTarjeta >= 51 && prefijoTarjeta <= 55)
            {
                return "Mastercard";
            }
        }

        if (numeroTarjeta.Length == 15 &&
            (numeroTarjeta.StartsWith("34") || numeroTarjeta.StartsWith("37")))
        {
            return "American Express";
        }

        if ((numeroTarjeta.StartsWith("6011") || numeroTarjeta.StartsWith("65")) &&
            numeroTarjeta.Length >= 16 &&
            numeroTarjeta.Length <= 19)
        {
            return "Discover";
        }

        return "Desconocida";
    }
    static void ValidarTarjetasDesdeArchivo(string rutaArchivo)
    {
        try
        {
            string[] listaTarjetas = File.ReadAllLines(rutaArchivo);

            foreach (string numeroTarjeta in listaTarjetas)
            {
                bool esValida = ValidarTarjeta(numeroTarjeta);
                string marcaTarjeta = IdentificarMarca(numeroTarjeta);

                if (esValida)
                {
                    Console.WriteLine(numeroTarjeta + " - " + marcaTarjeta + " - VÁLIDA");
                }
                else
                {
                    Console.WriteLine(numeroTarjeta + " - " + marcaTarjeta + " - INVÁLIDA");
                }

                ActualizarEstadisticas(esValida, marcaTarjeta);
            }

            Console.WriteLine();
            Console.WriteLine("===== RESUMEN =====");
            Console.WriteLine("Tarjetas válidas: " + tarjetasValidas);
            Console.WriteLine("Tarjetas inválidas: " + tarjetasInvalidas);

            Console.WriteLine();
            Console.WriteLine("Por marca:");
            Console.WriteLine("Visa: " + cantidadVisa);
            Console.WriteLine("Mastercard: " + cantidadMastercard);
            Console.WriteLine("American Express: " + cantidadAmericanExpress);
            Console.WriteLine("Discover: " + cantidadDiscover);
            Console.WriteLine("Desconocidas: " + cantidadDesconocidas);
        }
        catch (Exception error)
        {
            Console.WriteLine("Error al leer el archivo.");
            Console.WriteLine(error.Message);
        }

        Console.WriteLine();
        Console.WriteLine("Presione una tecla para continuar...");
        Console.ReadKey();
    }
    static string GenerarNumeroValido()
    {
        string numeroBase = "4";

        while (numeroBase.Length < 15)
        {
            numeroBase = numeroBase + generadorAleatorio.Next(10);
        }

        int digitoVerificador = CalcularDigitoLuhn(numeroBase);

        return numeroBase + digitoVerificador;
    }

    static int CalcularDigitoLuhn(string numeroBase)
    {
        int sumaDigitos = 0;
        bool duplicarDigito = true;

        for (int posicion = numeroBase.Length - 1; posicion >= 0; posicion--)
        {
            int digitoActual = numeroBase[posicion] - '0';

            if (duplicarDigito)
            {
                digitoActual = digitoActual * 2;

                if (digitoActual > 9)
                {
                    digitoActual = digitoActual - 9;
                }
            }

            sumaDigitos = sumaDigitos + digitoActual;
            duplicarDigito = !duplicarDigito;
        }

        int digitoVerificador = (10 - (sumaDigitos % 10)) % 10;

        return digitoVerificador;
    }
    static void MostrarEstadisticas()
    {
        Console.Clear();

        Console.WriteLine("===== ESTADÍSTICAS =====");
        Console.WriteLine();
        Console.WriteLine("Tarjetas válidas: " + tarjetasValidas);
        Console.WriteLine("Tarjetas inválidas: " + tarjetasInvalidas);

        Console.WriteLine();
        Console.WriteLine("Por marca:");
        Console.WriteLine("Visa: " + cantidadVisa);
        Console.WriteLine("Mastercard: " + cantidadMastercard);
        Console.WriteLine("American Express: " + cantidadAmericanExpress);
        Console.WriteLine("Discover: " + cantidadDiscover);
        Console.WriteLine("Desconocidas: " + cantidadDesconocidas);

        Console.WriteLine();
        Console.WriteLine("Presione una tecla para continuar...");
        Console.ReadKey();
    }

    static void ActualizarEstadisticas(bool esValida, string marcaTarjeta)
    {
        if (esValida)
        {
            tarjetasValidas = tarjetasValidas + 1;
        }
        else
        {
            tarjetasInvalidas = tarjetasInvalidas + 1;
        }

        switch (marcaTarjeta)
        {
            case "Visa":
                cantidadVisa = cantidadVisa + 1;
                break;

            case "Mastercard":
                cantidadMastercard = cantidadMastercard + 1;
                break;

            case "American Express":
                cantidadAmericanExpress = cantidadAmericanExpress + 1;
                break;

            case "Discover":
                cantidadDiscover = cantidadDiscover + 1;
                break;

            default:
                cantidadDesconocidas = cantidadDesconocidas + 1;
                break;
        }
    }
}