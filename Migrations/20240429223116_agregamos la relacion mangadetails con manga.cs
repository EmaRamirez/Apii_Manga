using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_Tienda.Migrations
{
    /// <inheritdoc />
    public partial class agregamoslarelacionmangadetailsconmanga : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idManga",
                table: "MangaDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MangaDetails_idManga",
                table: "MangaDetails",
                column: "idManga");

            migrationBuilder.AddForeignKey(
                name: "FK_MangaDetails_Mangas_idManga",
                table: "MangaDetails",
                column: "idManga",
                principalTable: "Mangas",
                principalColumn: "idManga",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MangaDetails_Mangas_idManga",
                table: "MangaDetails");

            migrationBuilder.DropIndex(
                name: "IX_MangaDetails_idManga",
                table: "MangaDetails");

            migrationBuilder.DropColumn(
                name: "idManga",
                table: "MangaDetails");
        }
    }
}
