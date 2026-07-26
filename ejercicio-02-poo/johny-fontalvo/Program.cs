using SistemaGestionTareas.Enums;
using SistemaGestionTareas.Models;
using SistemaGestionTareas.Services;

namespace SistemaGestionTareas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GestorTareas gestor = new GestorTareas();

            gestor.CargarDeJSON("tareas.json");

            int opcion;

            do
            {
                Console.Clear();

                Console.WriteLine("=====================================");
                Console.WriteLine("       GESTOR DE TAREAS");
                Console.WriteLine("=====================================");
                Console.WriteLine("1. Agregar tarea");
                Console.WriteLine("2. Listar todas");
                Console.WriteLine("3. Listar por categoría");
                Console.WriteLine("4. Listar por prioridad");
                Console.WriteLine("5. Marcar como completada");
                Console.WriteLine("6. Mostrar tareas vencidas");
                Console.WriteLine("7. Eliminar tarea");
                Console.WriteLine("8. Exportar a JSON");
                Console.WriteLine("9. Salir");
                Console.WriteLine();

                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    opcion = 0;
                }

                Console.Clear();

                switch (opcion)
                {
                    case 1:
                        AgregarTarea(gestor);
                        break;

                    case 2:
                        ListarTodas(gestor);
                        break;

                    case 3:
                        ListarCategoria(gestor);
                        break;

                    case 4:
                        ListarPrioridad(gestor);
                        break;

                    case 5:
                        Completar(gestor);
                        break;

                    case 6:
                        MostrarVencidas(gestor);
                        break;

                    case 7:
                        Eliminar(gestor);
                        break;

                    case 8:
                        gestor.GuardarEnJSON("tareas.json");
                        Console.WriteLine("Archivo exportado correctamente.");
                        break;

                    case 9:
                        gestor.GuardarEnJSON("tareas.json");
                        Console.WriteLine("Hasta pronto.");
                        break;

                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }

                if (opcion != 9)
                {
                    Console.WriteLine();
                    Console.WriteLine("Presione ENTER para continuar...");
                    Console.ReadLine();
                }

            } while (opcion != 9);
        }

        static void AgregarTarea(GestorTareas gestor)
        {
            Console.Write("Título: ");
            string titulo = Console.ReadLine();

            Console.Write("Descripción: ");
            string descripcion = Console.ReadLine();

            Console.Write("Categoría: ");
            string categoria = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Prioridad");
            Console.WriteLine("1. Baja");
            Console.WriteLine("2. Media");
            Console.WriteLine("3. Alta");
            Console.WriteLine("4. Crítica");

            Console.Write("Seleccione: ");

            int op = int.Parse(Console.ReadLine());

            Prioridad prioridad = (Prioridad)(op - 1);

            Console.WriteLine();
            Console.Write("¿Tiene fecha de vencimiento? (S/N): ");

            string respuesta = Console.ReadLine().ToUpper();

            if (respuesta == "S")
            {
                Console.Write("Ingrese fecha (dd/MM/yyyy): ");

                DateTime fecha = DateTime.Parse(Console.ReadLine());

                gestor.Agregar(

                    new TareaConVencimiento(

                        titulo,

                        descripcion,

                        prioridad,

                        categoria,

                        fecha));

            }
            else
            {
                gestor.Agregar(

                    new Tarea(

                        titulo,

                        descripcion,

                        prioridad,

                        categoria));
            }

            Console.WriteLine();
            Console.WriteLine("Tarea agregada correctamente.");
        }

        static void ListarTodas(GestorTareas gestor)
        {
            if (gestor.Tareas.Count == 0)
            {
                Console.WriteLine("No existen tareas.");
                return;
            }

            Console.WriteLine("===== LISTADO POLIMÓRFICO =====");
            Console.WriteLine();

            foreach (Tarea tarea in gestor.Tareas)
            {
                tarea.MostrarInfo();
            }
        }

        static void ListarCategoria(GestorTareas gestor)
        {
            Console.Write("Categoría: ");

            string categoria = Console.ReadLine();

            List<Tarea> lista =
                gestor.ListarPorCategoria(categoria);

            foreach (var tarea in lista)
            {
                tarea.MostrarInfo();
            }
        }

        static void ListarPrioridad(GestorTareas gestor)
        {
            Console.WriteLine("1. Baja");
            Console.WriteLine("2. Media");
            Console.WriteLine("3. Alta");
            Console.WriteLine("4. Crítica");

            Console.Write("Seleccione: ");

            int op = int.Parse(Console.ReadLine());

            Prioridad prioridad = (Prioridad)(op - 1);

            List<Tarea> lista =
                gestor.ListarPorPrioridad(prioridad);

            foreach (var tarea in lista)
            {
                tarea.MostrarInfo();
            }
        }

        static void Completar(GestorTareas gestor)
        {
            Console.Write("ID de la tarea: ");

            int id = int.Parse(Console.ReadLine());

            gestor.Completar(id);

            Console.WriteLine("Tarea completada.");
        }

        static void MostrarVencidas(GestorTareas gestor)
        {
            List<Tarea> lista =
                gestor.ObtenerVencidas();

            if (lista.Count == 0)
            {
                Console.WriteLine("No existen tareas vencidas.");
                return;
            }

            foreach (var tarea in lista)
            {
                tarea.MostrarInfo();
            }
        }

        static void Eliminar(GestorTareas gestor)
        {
            Console.Write("ID de la tarea: ");

            int id = int.Parse(Console.ReadLine());

            gestor.Eliminar(id);

            Console.WriteLine("Tarea eliminada.");
        }
    }
}