using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RehberWeb.Migrations
{
    public partial class mg2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rapors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Raporun_Talep_Edildiği_Tarih = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Raporun_Durumu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rapors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Konum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KisiSayisi = table.Column<int>(type: "int", nullable: false),
                    TelefonSayisi = table.Column<int>(type: "int", nullable: false),
                    RaporId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_data", x => x.Id);
                    table.ForeignKey(
                        name: "FK_data_Rapors_RaporId",
                        column: x => x.RaporId,
                        principalTable: "Rapors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_data_RaporId",
                table: "data",
                column: "RaporId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "data");

            migrationBuilder.DropTable(
                name: "Rapors");
        }
    }
}
