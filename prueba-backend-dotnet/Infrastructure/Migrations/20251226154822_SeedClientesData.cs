using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TalycapGlobalNet.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedClientesData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "Apellidos", "Cuit", "Domicilio", "Email", "FechaNacimiento", "Nombres", "TelefonoCelular" },
                values: new object[,]
                {
                    { 1, "Perez", "20123456789", "Calle Falsa 123", "juan.perez@example.com", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Juan", "1122334455" },
                    { 2, "Gomez", "27987654321", "Avenida Siempre Viva 742", "maria.gomez@example.com", new DateTime(1985, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maria", "5566778899" },
                    { 3, "Lopez", "20234567890", "Boulevard de los Sueños Rotos 456", "carlos.lopez@example.com", new DateTime(1992, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carlos", "3344556677" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
