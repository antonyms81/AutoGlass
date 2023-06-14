using AutoGlass.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGlass.Infra.Dados.ConfiguracaoDasEntidades
{
    public class ConfiguracaoProduto : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("Produtos");

            entityTypeBuilder.HasKey(x => x.Id);

            entityTypeBuilder.Property(x => x.Nome)
               .IsRequired()
               .HasColumnName("Nome")
               .HasColumnType($"Varchar({500})");

            entityTypeBuilder.Property(x => x.Descricao)
              .IsRequired()
              .HasColumnName("Descricao")
              .HasColumnType($"Varchar({1000})");

            entityTypeBuilder.Property(x => x.Situacao)
              .IsRequired()
              .HasColumnName("Situacao")
              .HasColumnType($"Int");
        }
    }
}
