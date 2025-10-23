using Microsoft.Extensions.DependencyInjection;
using SistemaCitas.BusinessLogic.Services;
using SistemaCitas.DataAccess;
using SistemaCitas.DataAccess.Repositorios;

namespace SistemaCitas.BusinessLogic
{
    public static class ServiceConfiguration
    {
        public static void DataAccess(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<CitasRepository>();
            services.AddScoped<EspecialidadRepository>();
            SistemaCitas_Context.BuildConnectionString(connectionString);
        }

        public static void BusinessLogic(this IServiceCollection services)
        {
            services.AddScoped<ServicesCitas>();
        }
    }
}