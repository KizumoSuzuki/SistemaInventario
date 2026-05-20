using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaInventario.Migrations
{
    /// <inheritdoc />
    public partial class RelacionAlmacenProducto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlmacenProducto",
                columns: table => new
                {
                    AlmacenId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlmacenProducto", x => new { x.AlmacenId, x.ProductoId });
                    table.ForeignKey(
                        name: "FK_AlmacenProducto_Almacenes_AlmacenId",
                        column: x => x.AlmacenId,
                        principalTable: "Almacenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlmacenProducto_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlmacenProducto_ProductoId",
                table: "AlmacenProducto",
                column: "ProductoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlmacenProducto");
        }
    }
}
