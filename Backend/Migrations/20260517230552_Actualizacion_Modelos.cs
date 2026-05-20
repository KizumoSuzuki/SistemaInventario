using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaInventario.Migrations
{
    /// <inheritdoc />
    public partial class Actualizacion_Modelos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Usuarios",
                newName: "Contraseña");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Clientes",
                newName: "Nombre");

            migrationBuilder.AlterColumn<int>(
                name: "Rol",
                table: "Usuarios",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Contraseña",
                table: "Usuarios",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Clientes",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "Rol",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
