using AutoGlass.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGlass.Infra.Dados.Contexto
{
    public class AutoGlassContexto : DbContext
    {
        public AutoGlassContexto()
        {

        }

        public AutoGlassContexto(DbContextOptions<AutoGlassContexto> options) : base(options)
        {

        }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS01;Database=DbAutoGlass;Integrated Security=true;encrypt=false;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var assembly = typeof(AutoGlassContexto).Assembly;

            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }
    }
}
