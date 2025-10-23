using SistemaCitas.Entities.Entities;

namespace SistemaCitas.API.Models
{
    public class CitasViewModel
    {
        public int Cita_Id { get; set; }

        public int Clie_Id { get; set; }

        public int Espe_Id { get; set; }

        public DateTime Cita_Fecha { get; set; }

        public TimeSpan Cita_Hora { get; set; }

        public string Cita_Detalles { get; set; }

        public string Cita_Estado { get; set; }

        public virtual Clientes Clie { get; set; }

        public virtual Especialidades Espe { get; set; }
    }
}
