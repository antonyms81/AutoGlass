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

            entityTypeBuilder.Property(x => x.DescricaoProduto)
              .IsRequired()
              .HasColumnName("DescricaoProduto")
              .HasColumnType($"Varchar({1000})");

            entityTypeBuilder.Property(x => x.DescricaoFornecedor)
              .HasColumnName("DescricaoFornecedor")
              .HasColumnType($"Varchar({1000})");

            entityTypeBuilder.Property(x => x.CodigoProduto)
             .IsRequired()
             .HasColumnName("CodigoProduto")
             .HasColumnType($"Int");

            entityTypeBuilder.Property(x => x.CodigoFornecedor)
             .HasColumnName("CodigoFornecedor")
             .HasColumnType($"Int");

            entityTypeBuilder.Property(x => x.CNPJFornecedor)
              .HasColumnName("CNPJFornecedor")
              .HasColumnType("varchar(14)");

            entityTypeBuilder.Property(x => x.DataFabricacao)
               .IsRequired()
               .HasColumnName("DataFabricacao")
               .HasColumnType("datetime");

            entityTypeBuilder.Property(x => x.DataValidade)
               .IsRequired()
               .HasColumnName("DataValidade")
               .HasColumnType("datetime");

            entityTypeBuilder.Property(x => x.Situacao)
              .IsRequired()
              .HasColumnName("Situacao")
              .HasColumnType($"Int");
        }
    }
}
