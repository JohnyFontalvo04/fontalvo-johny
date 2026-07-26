using SistemaGestionTareas.Enums;
using SistemaGestionTareas.Interfaces;

namespace SistemaGestionTareas.Models
{
    public class Tarea : IExportable
    {
        private static int contador = 1;

        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Descripcion { get; set; }

        public Prioridad Prioridad { get; set; }

        public string Categoria { get; set; }

        public bool Completada { get; set; }

        public DateTime FechaCreacion { get; set; }

        public Tarea()
        {
        }

        public Tarea(string titulo, string descripcion,
                     Prioridad prioridad,
                     string categoria)
        {
            Id = contador++;

            Titulo = titulo;

            Descripcion = descripcion;

            Prioridad = prioridad;

            Categoria = categoria;

            Completada = false;

            FechaCreacion = DateTime.Now;
        }

        public virtual void MostrarInfo()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Título: {Titulo}");
            Console.WriteLine($"Descripción: {Descripcion}");
            Console.WriteLine($"Categoría: {Categoria}");
            Console.WriteLine($"Prioridad: {Prioridad}");
            Console.WriteLine($"Estado: {(Completada ? "Completada" : "Pendiente")}");
            Console.WriteLine($"Fecha: {FechaCreacion}");
            Console.WriteLine("----------------------------------------");
        }

        public string Exportar()
        {
            return $"{Id}|{Titulo}|{Prioridad}|{Completada}";
        }

        public static void ActualizarContador(int ultimoId)
        {
            contador = ultimoId + 1;
        }
    }
}