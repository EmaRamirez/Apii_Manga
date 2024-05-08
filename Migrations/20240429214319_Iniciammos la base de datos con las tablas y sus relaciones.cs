using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_Tienda.Migrations
{
    /// <inheritdoc />
    public partial class Iniciammoslabasededatosconlastablasysusrelaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    idAutor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.idAutor);
                });

            migrationBuilder.CreateTable(
                name: "Editoriales",
                columns: table => new
                {
                    idEditorial = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editoriales", x => x.idEditorial);
                });

            migrationBuilder.CreateTable(
                name: "MangaDetails",
                columns: table => new
                {
                    idMDetail = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tomoNro = table.Column<int>(type: "int", nullable: false),
                    reseña = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MangaDetails", x => x.idMDetail);
                });

            migrationBuilder.CreateTable(
                name: "Mangas",
                columns: table => new
                {
                    idManga = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    precio = table.Column<int>(type: "int", nullable: false),
                    cantidadTomos = table.Column<int>(type: "int", nullable: false),
                    idAutor = table.Column<int>(type: "int", nullable: false),
                    idEditorial = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mangas", x => x.idManga);
                    table.ForeignKey(
                        name: "FK_Mangas_Autores_idAutor",
                        column: x => x.idAutor,
                        principalTable: "Autores",
                        principalColumn: "idAutor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mangas_Editoriales_idEditorial",
                        column: x => x.idEditorial,
                        principalTable: "Editoriales",
                        principalColumn: "idEditorial",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mangas_idAutor",
                table: "Mangas",
                column: "idAutor");

            migrationBuilder.CreateIndex(
                name: "IX_Mangas_idEditorial",
                table: "Mangas",
                column: "idEditorial");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MangaDetails");

            migrationBuilder.DropTable(
                name: "Mangas");

            migrationBuilder.DropTable(
                name: "Autores");

            migrationBuilder.DropTable(
                name: "Editoriales");
        }
    }
}
