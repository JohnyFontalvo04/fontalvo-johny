using SistemaGestionTareas.Enums;

namespace SistemaGestionTareas.Models
{
    public class TareaConVencimiento : Tarea
    {
        public DateTime FechaVencimiento { get; set; }

        public int DiasRestantes
        {
            get
            {
                return (FechaVencimiento - DateTime.Now).Days;
            }
        }

        public TareaConVencimiento()
        {

        }

        public TareaConVencimiento(string titulo,
                                   string descripcion,
                                   Prioridad prioridad,
                                   string categoria,
                                   DateTime fechaVencimiento)
            : base(titulo, descripcion, prioridad, categoria)
        {
            FechaVencimiento = fechaVencimiento;
        }

        public override void MostrarInfo()
        {
            base.MostrarInfo();

            Console.WriteLine($"Fecha de vencimiento: {FechaVencimiento:dd/MM/yyyy}");
            Console.WriteLine($"Días restantes: {DiasRestantes}");
            Console.WriteLine("----------------------------------------");
        }
    }
}