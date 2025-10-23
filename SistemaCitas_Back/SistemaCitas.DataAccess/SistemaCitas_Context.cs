using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaCitas.DataAccess.Context;

namespace SistemaCitas.DataAccess
{
    public class SistemaCitas_Context : DbContext
    {
        public static string ConnectionString { get; set; }

        public SistemaCitas_Context()
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }

        public SistemaCitas_Context(DbContextOptions<SistemaCitas_Context> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured && !string.IsNullOrEmpty(ConnectionString))
            {
                optionsBuilder.UseMySql(
                    ConnectionString,
                    new MySqlServerVersion(new Version(8, 0, 33))
                );
            }
            base.OnConfiguring(optionsBuilder);
        }

        public static void BuildConnectionString(string connection)
        {
            ConnectionString = connection;
        }
    }
}