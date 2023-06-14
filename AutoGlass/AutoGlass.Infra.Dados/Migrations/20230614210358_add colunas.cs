using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoGlass.Infra.Dados.Migrations
{
    /// <inheritdoc />
    public partial class addcolunas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Produtos",
                newName: "DescricaoProduto");

            migrationBuilder.AddColumn<string>(
                name: "CNPJFornecedor",
                table: "Produtos",
                type: "varchar(14)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CodigoFornecedor",
                table: "Produtos",
                type: "Int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CodigoProduto",
                table: "Produtos",
                type: "Int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataFabricacao",
                table: "Produtos",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataValidade",
                table: "Produtos",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DescricaoFornecedor",
                table: "Produtos",
                type: "Varchar(1000)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CNPJFornecedor",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "CodigoFornecedor",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "CodigoProduto",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "DataFabricacao",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "DataValidade",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "DescricaoFornecedor",
                table: "Produtos");

            migrationBuilder.RenameColumn(
                name: "DescricaoProduto",
                table: "Produtos",
                newName: "Descricao");
        }
    }
}
