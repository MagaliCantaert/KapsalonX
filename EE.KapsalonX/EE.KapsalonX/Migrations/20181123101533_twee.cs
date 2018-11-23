using Microsoft.EntityFrameworkCore.Migrations;

namespace EE.KapsalonX.Web.Migrations
{
    public partial class twee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Afspraken_Klanten_AfspraakId",
                table: "Afspraken");

            migrationBuilder.CreateIndex(
                name: "IX_Afspraken_KlantGegevensId",
                table: "Afspraken",
                column: "KlantGegevensId");

            migrationBuilder.AddForeignKey(
                name: "FK_Afspraken_Klanten_KlantGegevensId",
                table: "Afspraken",
                column: "KlantGegevensId",
                principalTable: "Klanten",
                principalColumn: "KlantId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Afspraken_Klanten_KlantGegevensId",
                table: "Afspraken");

            migrationBuilder.DropIndex(
                name: "IX_Afspraken_KlantGegevensId",
                table: "Afspraken");

            migrationBuilder.AddForeignKey(
                name: "FK_Afspraken_Klanten_AfspraakId",
                table: "Afspraken",
                column: "AfspraakId",
                principalTable: "Klanten",
                principalColumn: "KlantId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
