using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaInventario.Migrations
{
    /// <inheritdoc />
    public partial class AddAlmacenProductos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlmacenProducto_Almacenes_AlmacenId",
                table: "AlmacenProducto");

            migrationBuilder.DropForeignKey(
                name: "FK_AlmacenProducto_Productos_ProductoId",
                table: "AlmacenProducto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AlmacenProducto",
                table: "AlmacenProducto");

            migrationBuilder.RenameTable(
                name: "AlmacenProducto",
                newName: "AlmacenProductos");

            migrationBuilder.RenameIndex(
                name: "IX_AlmacenProducto_ProductoId",
                table: "AlmacenProductos",
                newName: "IX_AlmacenProductos_ProductoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlmacenProductos",
                table: "AlmacenProductos",
                columns: new[] { "AlmacenId", "ProductoId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AlmacenProductos_Almacenes_AlmacenId",
                table: "AlmacenProductos",
                column: "AlmacenId",
                principalTable: "Almacenes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlmacenProductos_Productos_ProductoId",
                table: "AlmacenProductos",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlmacenProductos_Almacenes_AlmacenId",
                table: "AlmacenProductos");

            migrationBuilder.DropForeignKey(
                name: "FK_AlmacenProductos_Productos_ProductoId",
                table: "AlmacenProductos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AlmacenProductos",
                table: "AlmacenProductos");

            migrationBuilder.RenameTable(
                name: "AlmacenProductos",
                newName: "AlmacenProducto");

            migrationBuilder.RenameIndex(
                name: "IX_AlmacenProductos_ProductoId",
                table: "AlmacenProducto",
                newName: "IX_AlmacenProducto_ProductoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlmacenProducto",
                table: "AlmacenProducto",
                columns: new[] { "AlmacenId", "ProductoId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AlmacenProducto_Almacenes_AlmacenId",
                table: "AlmacenProducto",
                column: "AlmacenId",
                principalTable: "Almacenes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlmacenProducto_Productos_ProductoId",
                table: "AlmacenProducto",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
