using SistemaGestionTareas.Enums;

namespace SistemaGestionTareas.Persistence
{
    public class TareaDTO
    {
        public string Tipo { get; set; }

        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Descripcion { get; set; }

        public Prioridad Prioridad { get; set; }

        public string Categoria { get; set; }

        public bool Completada { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime? FechaVencimiento { get; set; }
    }
}