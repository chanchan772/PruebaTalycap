using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TalycapGlobalNet.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenamedCuitToCedula : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cuit",
                table: "Clientes");

            migrationBuilder.AddColumn<string>(
                name: "Cedula",
                table: "Clientes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Cedula", "Domicilio", "Email", "TelefonoCelular" },
                values: new object[] { "1017123456", "Cra 7 # 71-21", "juan.perez@example.co", "3101234567" });

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Cedula", "Domicilio", "Email", "TelefonoCelular" },
                values: new object[] { "1017654321", "Cll 100 # 19-54", "maria.gomez@example.co", "3209876543" });

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Cedula", "Domicilio", "Email", "TelefonoCelular" },
                values: new object[] { "1017890123", "Av. El Dorado # 68c-61", "carlos.lopez@example.co", "3154567890" });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_Cedula",
                table: "Clientes",
                column: "Cedula",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Clientes_Cedula",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Cedula",
                table: "Clientes");

            migrationBuilder.AddColumn<string>(
                name: "Cuit",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Cuit", "Domicilio", "Email", "TelefonoCelular" },
                values: new object[] { "20123456789", "Calle Falsa 123", "juan.perez@example.com", "1122334455" });

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Cuit", "Domicilio", "Email", "TelefonoCelular" },
                values: new object[] { "27987654321", "Avenida Siempre Viva 742", "maria.gomez@example.com", "5566778899" });

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Cuit", "Domicilio", "Email", "TelefonoCelular" },
                values: new object[] { "20234567890", "Boulevard de los Sueños Rotos 456", "carlos.lopez@example.com", "3344556677" });
        }
    }
}
