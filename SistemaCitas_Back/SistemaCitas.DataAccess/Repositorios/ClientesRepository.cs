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
    public class ClientesRepository
    {
        //Insertar una nuevo Cliente.
        //Recibe un objeto de tipo Clientes y retorna un objeto de tipo RequestStatus que indica el estado de la operación.
        public RequestStatus RegistrarCliente(Clientes cliente) {
            //Validacion que los datos no lleguen vacíos.
            if (cliente == null)
            {
                return new RequestStatus { CodeStatus = 0, MessageStatus = "Los datos llegaron vacíos o datos erróneos." };
            }

            //Conexión a la base de datos.
            using var db = new MySqlConnection(SistemaCitas_Context.ConnectionString);

            //Se declaran los parámetros del procedimiento almacenado.
            var parametros = new DynamicParameters();
            parametros.Add("p_Clie_Id", cliente.Usua_Nombre, DbType.String, ParameterDirection.Input);
            parametros.Add("p_Espe_Id", cliente.Usua_Contraseña, DbType.String, ParameterDirection.Input);
            parametros.Add("p_Cita_Fecha", cliente.Clie_Dni, DbType.String, ParameterDirection.Input);
            parametros.Add("p_Cita_Hora", cliente.Clie_Nombre, DbType.String, ParameterDirection.Input);
            parametros.Add("p_Cita_Hora", cliente.Clie_Apellido, DbType.String, ParameterDirection.Input);
            parametros.Add("p_Cita_Hora", cliente.Clie_Sexo, DbType.String, ParameterDirection.Input);
            parametros.Add("p_Cita_Detalles", cliente.Clie_FechaNacimiento, DbType.Date, ParameterDirection.Input);

            try
            {
                //Se ejecuta el procedimiento almacenado.
                //Mapea el resultado del procedimiento almacenado a la entidad RequestStatus.
                var result = db.QueryFirstOrDefault<RequestStatus>("SP_Clientes_Insertar", parametros, commandType: CommandType.StoredProcedure);

                //Validacion de que el resultado no sea nulo.
                if (result == null)
                {
                    return new RequestStatus { CodeStatus = 0, MessageStatus = "Error desconocido." };
                }

                //Retorno de datos.
                return result;
            }
            // Excepción manejada
            catch (Exception ex)
            {
                return new RequestStatus { CodeStatus = 0, MessageStatus = $"Error inesperado: {ex.Message}" };
            }
        }
    }
}
