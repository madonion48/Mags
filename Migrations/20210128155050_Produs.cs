using Microsoft.EntityFrameworkCore.Migrations;

namespace Mags.Migrations
{
    public partial class Produs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comanda",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Client = table.Column<string>(nullable: true),
                    EANID = table.Column<int>(nullable: true),
                    Cantitate = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comanda", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comanda_Produs_EANID",
                        column: x => x.EANID,
                        principalTable: "Produs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Receptie",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Furnizor = table.Column<string>(nullable: true),
                    EANID = table.Column<int>(nullable: true),
                    EAN_Produs = table.Column<string>(nullable: true),
                    SSCC = table.Column<string>(nullable: true),
                    Cantitate = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receptie", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Receptie_Produs_EANID",
                        column: x => x.EANID,
                        principalTable: "Produs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stoc",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EANID = table.Column<int>(nullable: true),
                    Produs = table.Column<string>(nullable: true),
                    Furnizor = table.Column<string>(nullable: true),
                    SSCC = table.Column<string>(nullable: true),
                    Cantitate = table.Column<decimal>(nullable: false),
                    Adresa = table.Column<string>(nullable: true),
                    ReceptieID = table.Column<int>(nullable: true),
                    ComandaID = table.Column<int>(nullable: true),
                    Client = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stoc", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Stoc_Comanda_ComandaID",
                        column: x => x.ComandaID,
                        principalTable: "Comanda",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stoc_Produs_EANID",
                        column: x => x.EANID,
                        principalTable: "Produs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stoc_Receptie_ReceptieID",
                        column: x => x.ReceptieID,
                        principalTable: "Receptie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comanda_EANID",
                table: "Comanda",
                column: "EANID");

            migrationBuilder.CreateIndex(
                name: "IX_Receptie_EANID",
                table: "Receptie",
                column: "EANID");

            migrationBuilder.CreateIndex(
                name: "IX_Stoc_ComandaID",
                table: "Stoc",
                column: "ComandaID");

            migrationBuilder.CreateIndex(
                name: "IX_Stoc_EANID",
                table: "Stoc",
                column: "EANID");

            migrationBuilder.CreateIndex(
                name: "IX_Stoc_ReceptieID",
                table: "Stoc",
                column: "ReceptieID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stoc");

            migrationBuilder.DropTable(
                name: "Comanda");

            migrationBuilder.DropTable(
                name: "Receptie");
        }
    }
}
