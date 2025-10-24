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
    public class CitasRepository
    {
        //Listar citas médicas.
        //Retorna una colección de objetos de tipo Citas.
        public IEnumerable<Citas> ListarCitasPorCliente(int clienteId)
        {
            //Conexión a la base de datos.
            using var db = new MySqlConnection(SistemaCitas_Context.ConnectionString);

            //Se declaran los parámetros del procedimiento almacenado.
            var parametros = new DynamicParameters();

            //Se agrega el parámetro de entrada para el ID del cliente.
            parametros.Add("p_Clie_Id", clienteId, DbType.Int32, ParameterDirection.Input);

            //Se ejecuta el procedimiento almacenado.
            //Mapea el resultado del procedimiento almacenado a la entidad Especialidades.
            var result = db.Query<Citas>("SP_Citas_ListarPorCliente", parametros, commandType: CommandType.StoredProcedure);

            //Retorno de datos.
            return result;
        }

        //Insertar una nueva cita médica.
        //Recibe un objeto de tipo Citas y retorna un objeto de tipo RequestStatus que indica el estado de la operación.
        public RequestStatus InsertarCitas(Citas citas) {
            //Validacion que los datos no lleguen vacíos.
            if (citas == null)
            {
                return new RequestStatus { CodeStatus = 0, MessageStatus = "Los datos llegaron vacíos o datos erróneos." };
            }

            //Conexión a la base de datos.
            using var db = new MySqlConnection(SistemaCitas_Context.ConnectionString);

            //Se declaran los parámetros del procedimiento almacenado.
            var parametros = new DynamicParameters();
            parametros.Add("p_Clie_Id", citas.Clie_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("p_Espe_Id", citas.Espe_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("p_Cita_Fecha", citas.Cita_Fecha, DbType.Date, ParameterDirection.Input);
            parametros.Add("p_Cita_Hora", citas.Cita_Hora, DbType.DateTime, ParameterDirection.Input);
            parametros.Add("p_Cita_Detalles", citas.Cita_Detalles, DbType.String, ParameterDirection.Input);
            parametros.Add("p_Cita_Estado", citas.Cita_Estado, DbType.String, ParameterDirection.Input);

            try
            {
                //Se ejecuta el procedimiento almacenado.
                //Mapea el resultado del procedimiento almacenado a la entidad RequestStatus.
                var result = db.QueryFirstOrDefault<RequestStatus>("SP_Citas_Insertar", parametros, commandType: CommandType.StoredProcedure);

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

        //Cancelacion de una cita médica.
        //Recibe un objeto de tipo Citas y retorna un objeto de tipo RequestStatus que indica el estado de la operación.
        public RequestStatus CancelarCita(Citas citas)
        {
            // Validacion que los datos no lleguen vacíos.
            if (citas == null)
            {
                return new RequestStatus { CodeStatus = 0, MessageStatus = "Los datos llegaron vacíos o datos erróneos." };
            }

            // Conexión a la base de datos.
            using var db = new MySqlConnection(SistemaCitas_Context.ConnectionString);

            // Se declaran los parámetros del procedimiento almacenado.
            var parametros = new DynamicParameters();
            parametros.Add("p_Cita_Id", citas.Cita_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("p_Cita_Fecha", citas.Cita_Fecha, DbType.Date, ParameterDirection.Input);

            try
            {
                // Se ejecuta el procedimiento almacenado.
                // Mapea el resultado del procedimiento almacenado a la entidad RequestStatus.
                var result = db.QueryFirstOrDefault<RequestStatus>("SP_Citas_Cancelar", parametros, commandType: CommandType.StoredProcedure);

                // Validacion de que el resultado no sea nulo.
                if (result == null)
                {
                    return new RequestStatus { CodeStatus = 0, MessageStatus = "Error desconocido." };
                }

                // Retorno de datos.
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
