using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParqueSeguro.Infra.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Registros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Placa = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HoraChegada = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    HoraSaida = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Duracao = table.Column<long>(type: "bigint", nullable: true),
                    TotalHora = table.Column<int>(type: "int", nullable: true),
                    Preco = table.Column<double>(type: "double", precision: 14, scale: 2, nullable: true),
                    ValorPagar = table.Column<double>(type: "double", precision: 14, scale: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registros", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TabelaPrecos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataInicio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataFinal = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ValorInicial = table.Column<double>(type: "double", precision: 14, scale: 2, nullable: false),
                    ValorAdicional = table.Column<double>(type: "double", precision: 14, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelaPrecos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "TabelaPrecos",
                columns: new[] { "Id", "DataFinal", "DataInicio", "ValorAdicional", "ValorInicial" },
                values: new object[] { 1, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2.0, 2.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registros");

            migrationBuilder.DropTable(
                name: "TabelaPrecos");
        }
    }
}
