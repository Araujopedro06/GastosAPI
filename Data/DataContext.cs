using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using GastosAPI.Models;

namespace GastosAPI.Data
{
    public class GastosContext : DbContext
    {
        public GastosContext(DbContextOptions<GastosContext> options) : base(options)
        {
        }

        public DbSet<Gasto> Gastos { get; set; }
        public DbSet<CategoriaGasto> CategoriaGastos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gasto>().ToTable("Gastos");
            modelBuilder.Entity<Gasto>().HasKey(g => g.Id);
            modelBuilder.Entity<Gasto>().Property(g => g.Descricao).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<Gasto>().Property(g => g.Valor).IsRequired().HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Gasto>().Property(g => g.Data).IsRequired();
            modelBuilder.Entity<Gasto>()
                .HasOne(g => g.CategoriaGasto)
                .WithMany()
                .HasForeignKey(g => g.CategoriaGastoId);

            modelBuilder.Entity<CategoriaGasto>().ToTable("CategoriaGastos");
            modelBuilder.Entity<CategoriaGasto>().HasKey(c => c.Id);
            modelBuilder.Entity<CategoriaGasto>().Property(c => c.Nome).IsRequired().HasMaxLength(100);

            
            modelBuilder.Entity<CategoriaGasto>().HasData(
                new CategoriaGasto { Id = 1, Nome = "Lazer" },
                new CategoriaGasto { Id = 2, Nome = "Contas" },
                new CategoriaGasto { Id = 3, Nome = "Aluguel" },
                new CategoriaGasto { Id = 4, Nome = "Comida"},
                new CategoriaGasto { Id = 5, Nome = "Trasporte"}
            
            );
        }
    }
}
