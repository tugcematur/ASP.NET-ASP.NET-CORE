using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiRelations.Migrations
{
    public partial class İlk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Egitmenler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EgitmenAd = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Egitmenler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ogrenciler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ogrenciler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EgitmenOgrenci",
                columns: table => new
                {
                    EgitmenlerId = table.Column<int>(type: "int", nullable: false),
                    OgrencilerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EgitmenOgrenci", x => new { x.EgitmenlerId, x.OgrencilerId });
                    table.ForeignKey(
                        name: "FK_EgitmenOgrenci_Egitmenler_EgitmenlerId",
                        column: x => x.EgitmenlerId,
                        principalTable: "Egitmenler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EgitmenOgrenci_Ogrenciler_OgrencilerId",
                        column: x => x.OgrencilerId,
                        principalTable: "Ogrenciler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EgitmenOgrenci_OgrencilerId",
                table: "EgitmenOgrenci",
                column: "OgrencilerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EgitmenOgrenci");

            migrationBuilder.DropTable(
                name: "Egitmenler");

            migrationBuilder.DropTable(
                name: "Ogrenciler");
        }
    }
}
