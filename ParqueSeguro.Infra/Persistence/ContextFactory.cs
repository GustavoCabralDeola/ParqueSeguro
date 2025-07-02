/*using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace ParqueSeguro.Infra.Persistence
{
    public class ContextFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {
            var basePath = Directory.GetCurrentDirectory();
            if (!File.Exists(Path.Combine(basePath, "appsettings.json")))
            {
                basePath = Path.Combine(basePath, "../..");
            }

            var configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();



            var optionsBuilder = new DbContextOptionsBuilder<Context>();

            var connectionString = configuration.GetConnectionString("ParqueSeguroConnection");

            optionsBuilder.UseSqlServer(connectionString, b => b.MigrationsAssembly("ParqueSeguro.Infra"));

            return new Context(optionsBuilder.Options);

        }
    }
}
*/