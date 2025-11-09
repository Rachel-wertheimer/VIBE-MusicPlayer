using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace clean.data.Migrations
{
    public partial class creatDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dataSinger",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dataSinger", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dataAlbums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameAlbums = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameCertore = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    year = table.Column<int>(type: "int", nullable: false),
                    SingerId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dataAlbums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dataAlbums_dataSinger_SingerId",
                        column: x => x.SingerId,
                        principalTable: "dataSinger",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "dataSonges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameSonges = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameCertore = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlbumsId = table.Column<int>(type: "int", nullable: true),
                    SingerId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dataSonges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dataSonges_dataAlbums_AlbumsId",
                        column: x => x.AlbumsId,
                        principalTable: "dataAlbums",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_dataSonges_dataSinger_SingerId",
                        column: x => x.SingerId,
                        principalTable: "dataSinger",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_dataAlbums_SingerId",
                table: "dataAlbums",
                column: "SingerId");

            migrationBuilder.CreateIndex(
                name: "IX_dataSonges_AlbumsId",
                table: "dataSonges",
                column: "AlbumsId");

            migrationBuilder.CreateIndex(
                name: "IX_dataSonges_SingerId",
                table: "dataSonges",
                column: "SingerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dataSonges");

            migrationBuilder.DropTable(
                name: "dataAlbums");

            migrationBuilder.DropTable(
                name: "dataSinger");
        }
    }
}
