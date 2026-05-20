using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaInventario.Migrations
{
    /// <inheritdoc />
    public partial class SeedSuperAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Contraseña", "Email", "Nombre", "Rol", "Telefono" },
                values: new object[] { 1, "jGl25bVBBBW96Qi9Te4V37Fnqchz/Eu4qB9vKrRIqRg=", "admin", "Super Administrador", 2, "0000000000" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
