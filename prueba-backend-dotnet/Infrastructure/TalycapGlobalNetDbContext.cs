using Microsoft.EntityFrameworkCore;
using TalycapGlobalNet.Core;
using System;

namespace TalycapGlobalNet.Infrastructure
{
    public class TalycapGlobalNetDbContext : DbContext
    {
        public TalycapGlobalNetDbContext(DbContextOptions<TalycapGlobalNetDbContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().ToTable("Clientes");
            modelBuilder.Entity<Cliente>().HasIndex(c => c.Cedula).IsUnique();

            modelBuilder.Entity<Cliente>().HasData(
                new Cliente { Id = 1, Nombres = "Juan", Apellidos = "Perez", FechaNacimiento = new DateTime(1990, 1, 1), Cedula = "1017123456", Domicilio = "Cra 7 # 71-21", TelefonoCelular = "3101234567", Email = "juan.perez@example.co" },
                new Cliente { Id = 2, Nombres = "Maria", Apellidos = "Gomez", FechaNacimiento = new DateTime(1985, 5, 10), Cedula = "1017654321", Domicilio = "Cll 100 # 19-54", TelefonoCelular = "3209876543", Email = "maria.gomez@example.co" },
                new Cliente { Id = 3, Nombres = "Carlos", Apellidos = "Lopez", FechaNacimiento = new DateTime(1992, 8, 15), Cedula = "1017890123", Domicilio = "Av. El Dorado # 68c-61", TelefonoCelular = "3154567890", Email = "carlos.lopez@example.co" }
            );
        }
    }
}