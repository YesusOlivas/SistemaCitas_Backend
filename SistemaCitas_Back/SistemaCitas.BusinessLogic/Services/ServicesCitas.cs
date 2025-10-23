using SistemaCitas.DataAccess.Repositorios;
using SistemaCitas.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCitas.BusinessLogic.Services
{
    public class ServicesCitas
    {
        // Repositories
        private readonly CitasRepository _citasRepository;
        private readonly EspecialidadRepository _especialidadRepository;

        //  Contructor para inyeccion de los repositories
        public ServicesCitas(CitasRepository citasRepository, EspecialidadRepository especialidadRepository)
        {
            _citasRepository = citasRepository;
            _especialidadRepository = especialidadRepository;
        }

        #region Citas
        //Listar Citas por Cliente
        //Recibe el ID del cliente como parámetro y retorna una colección de objetos de tipo Citas.
        public IEnumerable<Citas> ListarCitasPorCliente(int clienteId)
        {
            try
            {
                // Llamada al repositorio para listar las citas por cliente
                var list = _citasRepository.ListarCitasPorCliente(clienteId);

                // Retorno de la lista de citas
                return list;
            }
            // Excepción manejada
            catch (Exception ex)
            {
                // En caso de error, se retorna null
                IEnumerable<Citas> empleados = null;
                return empleados;
            }
        }

        //Insertar Cita
        public RequestStatus InsertarCitas(Citas citas)
        {
            try
            {
                // Llamada al repositorio para insertar la cita
                var result = _citasRepository.InsertarCitas(citas);

                // Retorno del estado de la solicitud
                return result;
            }
            // Excepción manejada
            catch (Exception ex)
            {
                // En caso de error, se retorna un estado de solicitud con código 0 y mensaje de error
                return new RequestStatus { CodeStatus = 0, MessageStatus = ex.Message };
            }
        }

        public RequestStatus CancelarCita(Citas citas)
        {
            try
            {
                // Llamada al repositorio para insertar la cita
                var result = _citasRepository.CancelarCita(citas);

                // Retorno del estado de la solicitud
                return result;
            }
            catch (Exception ex)
            {
                // En caso de error, se retorna un estado de solicitud con código 0 y mensaje de error
                return new RequestStatus { CodeStatus = 0, MessageStatus = ex.Message };
            }
        }
        #endregion

        #region Especialidades
        //Listar Especialidades
        public IEnumerable<Especialidades> ListarEspecialidades()
        {
            try
            {
                //Llamada al repositorio para listar las especialidades
                var list = _especialidadRepository.ListarEspecialidades();

                //Retorno de la lista de especialidades
                return list;
            }
            //Excepción manejada
            catch (Exception ex)
            {
                //En caso de error, se retorna null
                IEnumerable<Especialidades> especialidades = null;
                return especialidades;
            }
        #endregion
        }
    }
}