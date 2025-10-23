using Dapper;
using MySql.Data.MySqlClient;
using SistemaCitas.DataAccess.Context;
using SistemaCitas.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCitas.DataAccess.Repositorios
{
    public class CitasRepository : IRepository<Citas>
    {
        public RequestStatus Delete(Citas item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Citas> Find(Citas? item)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(Citas item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Citas> ListarCitasPorCliente(int clienteId)
        {
            using var db = new MySqlConnection(SistemaCitas_Context.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("p_Clie_Id", clienteId, DbType.Int32, ParameterDirection.Input);
            var result = db.Query<Citas>("SP_Citas_ListarPorCliente", parametros, commandType: CommandType.StoredProcedure);

            return result;
        }

        public IEnumerable<Citas> List()
        {
            throw new NotImplementedException();
        }

        public RequestStatus Update(Citas item)
        {
            throw new NotImplementedException();
        }
    }
}
