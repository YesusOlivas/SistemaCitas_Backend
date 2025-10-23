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
        private readonly CitasRepository _citasRepository;

        public ServicesCitas(CitasRepository citasRepository)
        {
            _citasRepository = citasRepository;
        }

        #region
        public IEnumerable<Citas> ListarCitasPorCliente(int clienteId)
        {
            var result = new ServiceResult();
            try
            {
                var list = _citasRepository.ListarCitasPorCliente(clienteId);
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<Citas> empleados = null;
                return empleados;
            }
        }
        #endregion
    }
}
