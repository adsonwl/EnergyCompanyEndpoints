using EnergyEndpoint.Domain.Entities;
using EnergyEndpoint.Infra.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EnergyEndpoint.Infra.Data
{
    public class EnergyEndpointDbContext : DbContext
    {
        private readonly IConfiguration _configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        public DbSet<Endpoint> Endpoints { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new EndpointConfiguration())
                        .Entity<Endpoint>().HasKey(o => o.SerialNumber);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(_configuration.GetConnectionString("dbName"));
        }
    }
}
