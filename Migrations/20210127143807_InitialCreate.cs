using Microsoft.EntityFrameworkCore.Migrations;

namespace Mags.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produs",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EAN = table.Column<string>(nullable: true),
                    Nume = table.Column<string>(nullable: true),
                    Lungime = table.Column<decimal>(nullable: false),
                    Latime = table.Column<decimal>(nullable: false),
                    Inaltime = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produs", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produs");
        }
    }
}
