using Microsoft.EntityFrameworkCore;
using ParqueSeguro.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ParqueSeguro.Infra.Persistence
{
    public class Context : DbContext
    {

        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<TabelaPreco> TabelaPrecos { get; set; }
        public DbSet<Registro> Registros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<TabelaPreco>().HasData(new TabelaPreco(1,new DateTime(2024, 1, 1), new DateTime(2024, 12, 31), 2.00, 2.00));


        }
    }
}
