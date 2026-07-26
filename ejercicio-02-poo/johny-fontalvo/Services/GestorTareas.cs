using SistemaGestionTareas.Enums;
using SistemaGestionTareas.Models;
using SistemaGestionTareas.Persistence;
using System.Text.Json;

namespace SistemaGestionTareas.Services
{
    public class GestorTareas
    {
        public List<Tarea> Tareas { get; set; }

        public GestorTareas()
        {
            Tareas = new List<Tarea>();
        }

        public void Agregar(Tarea tarea)
        {
            Tareas.Add(tarea);
        }

        public void Completar(int id)
        {
            Tarea tarea = Tareas.FirstOrDefault(x => x.Id == id);

            if (tarea != null)
            {
                tarea.Completada = true;
            }
        }

        public void Eliminar(int id)
        {
            Tarea tarea = Tareas.FirstOrDefault(x => x.Id == id);

            if (tarea != null)
            {
                Tareas.Remove(tarea);
            }
        }

        public List<Tarea> ListarPorCategoria(string categoria)
        {
            return Tareas.Where(x =>
                x.Categoria.Equals(categoria,
                StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Tarea> ListarPorPrioridad(Prioridad prioridad)
        {
            return Tareas.Where(x => x.Prioridad == prioridad).ToList();
        }

        public List<Tarea> ObtenerVencidas()
        {
            List<Tarea> vencidas = new List<Tarea>();

            foreach (var tarea in Tareas)
            {
                if (tarea is TareaConVencimiento tv)
                {
                    if (tv.FechaVencimiento < DateTime.Now && !tv.Completada)
                    {
                        vencidas.Add(tv);
                    }
                }
            }

            return vencidas;
        }

        public void GuardarEnJSON(string archivo)
        {
            List<TareaDTO> lista = new List<TareaDTO>();

            foreach (var tarea in Tareas)
            {
                TareaDTO dto = new TareaDTO();

                dto.Id = tarea.Id;
                dto.Titulo = tarea.Titulo;
                dto.Descripcion = tarea.Descripcion;
                dto.Prioridad = tarea.Prioridad;
                dto.Categoria = tarea.Categoria;
                dto.Completada = tarea.Completada;
                dto.FechaCreacion = tarea.FechaCreacion;

                if (tarea is TareaConVencimiento tv)
                {
                    dto.Tipo = "Vencimiento";
                    dto.FechaVencimiento = tv.FechaVencimiento;
                }
                else
                {
                    dto.Tipo = "Simple";
                }

                lista.Add(dto);
            }

            var opciones = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            File.WriteAllText(
                archivo,
                JsonSerializer.Serialize(lista, opciones));
        }

        public void CargarDeJSON(string archivo)
        {
            try
            {
                if (!File.Exists(archivo))
                    return;

                string json = File.ReadAllText(archivo);

                List<TareaDTO> lista =
                    JsonSerializer.Deserialize<List<TareaDTO>>(json);

                if (lista == null)
                    return;

                Tareas.Clear();

                foreach (var dto in lista)
                {
                    if (dto.Tipo == "Vencimiento")
                    {
                        TareaConVencimiento tarea =
                            new TareaConVencimiento();

                        tarea.Id = dto.Id;
                        tarea.Titulo = dto.Titulo;
                        tarea.Descripcion = dto.Descripcion;
                        tarea.Prioridad = dto.Prioridad;
                        tarea.Categoria = dto.Categoria;
                        tarea.Completada = dto.Completada;
                        tarea.FechaCreacion = dto.FechaCreacion;
                        tarea.FechaVencimiento =
                            dto.FechaVencimiento ?? DateTime.Now;

                        Tareas.Add(tarea);
                    }
                    else
                    {
                        Tarea tarea = new Tarea();

                        tarea.Id = dto.Id;
                        tarea.Titulo = dto.Titulo;
                        tarea.Descripcion = dto.Descripcion;
                        tarea.Prioridad = dto.Prioridad;
                        tarea.Categoria = dto.Categoria;
                        tarea.Completada = dto.Completada;
                        tarea.FechaCreacion = dto.FechaCreacion;

                        Tareas.Add(tarea);
                    }
                }

                if (Tareas.Count > 0)
                {
                    Tarea.ActualizarContador(Tareas.Max(x => x.Id));
                }
            }
            catch
            {
                Console.WriteLine("No fue posible cargar el archivo JSON.");
            }
        }
    }
}