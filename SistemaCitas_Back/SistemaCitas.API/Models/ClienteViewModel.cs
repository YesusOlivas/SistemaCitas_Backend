using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaCitas.API.Models
{
    public class ClienteViewModel
    {
        [NotMapped]
        public string Usua_Nombre { get; set; }

        [NotMapped]
        public string Usua_Contraseña { get; set; }

        public int Clie_Id { get; set; }

        public string Clie_Dni { get; set; }

        public string Clie_Nombre { get; set; }

        public string Clie_Apellido { get; set; }

        public string Clie_Sexo { get; set; }

        public DateTime? Clie_FechaNacimiento { get; set; }
    }
}
