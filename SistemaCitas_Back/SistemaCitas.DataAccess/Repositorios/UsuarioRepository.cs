using Dapper;
using SistemaCitas.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCitas.DataAccess.Repositorios
{
    public class UsuarioRepository
    {
        // Método para iniciar sesión de un usuario
        // Recibe un objeto de tipo Usuarios y retorna un objeto de tipo RequestStatus que indica el estado de la operación.
        public RequestStatus IniciarSesion(Usuarios usuarios)
        {
            //Validacion que los datos no lleguen vacíos.
            if (usuarios == null)
            {
                return new RequestStatus { CodeStatus = 0, MessageStatus = "Los datos llegaron vacíos o datos erróneos." };
            }

            //Conexión a la base de datos.
            using var db = new MySql.Data.MySqlClient.MySqlConnection(SistemaCitas_Context.ConnectionString);

            //Se declaran los parámetros del procedimiento almacenado.
            var parametros = new Dapper.DynamicParameters();
            parametros.Add("p_Usua_Nombre", usuarios.Usua_Nombre, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parametros.Add("p_Usua_Contraseña", usuarios.Usua_Contraseña, System.Data.DbType.String, System.Data.ParameterDirection.Input);

            try
            {
                //Se ejecuta el procedimiento almacenado.
                //Mapea el resultado del procedimiento almacenado a la entidad RequestStatus.
                var result = db.QueryFirstOrDefault<RequestStatus>("SP_Usuarios_Login", parametros, commandType: System.Data.CommandType.StoredProcedure);

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
                return new RequestStatus { CodeStatus = 0, MessageStatus = ex.Message };
            }
        }
    }
}
