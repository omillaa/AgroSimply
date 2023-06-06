using AgroSimply.Data.Map;
using AgroSimply.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AgroSimply.Data
{
    public class AgroSimplyDBcontext : DbContext
    {
        private readonly IConfiguration _configuration;

        public AgroSimplyDBcontext(DbContextOptions<AgroSimplyDBcontext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<ProdutorModels> Produtor { get; set; }
       public DbSet<PropriedadeModels> Propriedade { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = _configuration.GetConnectionString("DataBase");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutorMap());
           modelBuilder.ApplyConfiguration(new PropriedadeMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}

