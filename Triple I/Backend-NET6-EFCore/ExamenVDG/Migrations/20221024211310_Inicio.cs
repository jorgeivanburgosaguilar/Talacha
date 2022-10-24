using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamenVDG.Migrations
{
    public partial class Inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoConsola",
                columns: table => new
                {
                    IdTipoConsola = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoConsola", x => x.IdTipoConsola);
                });

            migrationBuilder.CreateTable(
                name: "TipoGenero",
                columns: table => new
                {
                    IdTipoGenero = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoGenero", x => x.IdTipoGenero);
                });

            migrationBuilder.CreateTable(
                name: "Videojuego",
                columns: table => new
                {
                    IdVideojuego = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Anio = table.Column<short>(type: "smallint", nullable: false),
                    Calificacion = table.Column<byte>(type: "tinyint", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    IdTipoConsola = table.Column<int>(type: "int", nullable: false),
                    IdTipoGenero = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videojuego", x => x.IdVideojuego);
                    table.ForeignKey(
                        name: "FK_Videojuego_TipoConsola",
                        column: x => x.IdTipoConsola,
                        principalTable: "TipoConsola",
                        principalColumn: "IdTipoConsola");
                    table.ForeignKey(
                        name: "FK_Videojuego_TipoGenero",
                        column: x => x.IdTipoGenero,
                        principalTable: "TipoGenero",
                        principalColumn: "IdTipoGenero");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Videojuego_IdTipoConsola",
                table: "Videojuego",
                column: "IdTipoConsola");

            migrationBuilder.CreateIndex(
                name: "IX_Videojuego_IdTipoGenero",
                table: "Videojuego",
                column: "IdTipoGenero");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Videojuego");

            migrationBuilder.DropTable(
                name: "TipoConsola");

            migrationBuilder.DropTable(
                name: "TipoGenero");
        }
    }
}
