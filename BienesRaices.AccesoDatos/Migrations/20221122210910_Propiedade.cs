using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BienesRaices.AccesoDatos.Migrations
{
    public partial class Propiedade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Propiedade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    ImagenUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescripcionCorta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescripcionLarga = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Habitaciones = table.Column<int>(type: "int", nullable: false),
                    Bano = table.Column<int>(type: "int", nullable: false),
                    Estacionamiento = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdVendedor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propiedade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Propiedade_Vendedor_IdVendedor",
                        column: x => x.IdVendedor,
                        principalTable: "Vendedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Propiedade_IdVendedor",
                table: "Propiedade",
                column: "IdVendedor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Propiedade");
        }
    }
}
