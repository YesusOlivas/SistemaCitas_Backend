using Dapper;
using MySql.Data.MySqlClient;
using SistemaCitas.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCitas.DataAccess.Repositorios
{
    public class EspecialidadRepository
    {
        //Listar especialidades médicas.
        //Retorna una colección de objetos de tipo Especialidades.
        public IEnumerable<Especialidades> ListarEspecialidades()
        {
            //Conexión a la base de datos.
            using var db = new MySqlConnection(SistemaCitas_Context.ConnectionString);

            //Se ejecuta el procedimiento almacenado.
            //Mapea el resultado del procedimiento almacenado a la entidad Especialidades.
            var result = db.Query<Especialidades>("SP_Especialidades_Listar", commandType: System.Data.CommandType.StoredProcedure);

            //Retorno de datos.
            return result;
        }
    }
}
