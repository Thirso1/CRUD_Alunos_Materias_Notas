using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUD_AlunosMateriasNotas.Migrations
{
    /// <inheritdoc />
    public partial class updateNotas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Data",
                table: "Notas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "Valor",
                table: "Notas",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "Notas");

            migrationBuilder.DropColumn(
                name: "Valor",
                table: "Notas");
        }
    }
}
