using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParqueSeguro.Infra.Migrations
{
    public partial class ParqueSeguroMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "ValorInicial",
                table: "TabelaPrecos",
                type: "float(14)",
                precision: 14,
                scale: 2,
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double",
                oldPrecision: 14,
                oldScale: 2);

            migrationBuilder.AlterColumn<double>(
                name: "ValorAdicional",
                table: "TabelaPrecos",
                type: "float(14)",
                precision: 14,
                scale: 2,
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double",
                oldPrecision: 14,
                oldScale: 2);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInicio",
                table: "TabelaPrecos",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataFinal",
                table: "TabelaPrecos",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "TabelaPrecos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<double>(
                name: "ValorPagar",
                table: "Registros",
                type: "float(14)",
                precision: 14,
                scale: 2,
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double",
                oldPrecision: 14,
                oldScale: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Preco",
                table: "Registros",
                type: "float(14)",
                precision: 14,
                scale: 2,
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double",
                oldPrecision: 14,
                oldScale: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Placa",
                table: "Registros",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(8)",
                oldMaxLength: 8);

            migrationBuilder.AlterColumn<DateTime>(
                name: "HoraSaida",
                table: "Registros",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "HoraChegada",
                table: "Registros",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Registros",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "ValorInicial",
                table: "TabelaPrecos",
                type: "double",
                precision: 14,
                scale: 2,
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float(14)",
                oldPrecision: 14,
                oldScale: 2);

            migrationBuilder.AlterColumn<double>(
                name: "ValorAdicional",
                table: "TabelaPrecos",
                type: "double",
                precision: 14,
                scale: 2,
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float(14)",
                oldPrecision: 14,
                oldScale: 2);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInicio",
                table: "TabelaPrecos",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataFinal",
                table: "TabelaPrecos",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "TabelaPrecos",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<double>(
                name: "ValorPagar",
                table: "Registros",
                type: "double",
                precision: 14,
                scale: 2,
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float(14)",
                oldPrecision: 14,
                oldScale: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Preco",
                table: "Registros",
                type: "double",
                precision: 14,
                scale: 2,
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float(14)",
                oldPrecision: 14,
                oldScale: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Placa",
                table: "Registros",
                type: "varchar(8)",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8);

            migrationBuilder.AlterColumn<DateTime>(
                name: "HoraSaida",
                table: "Registros",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "HoraChegada",
                table: "Registros",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Registros",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }
    }
}
