using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EE.KapsalonX.Web.Migrations
{
    public partial class vijf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DuurTijd",
                table: "Behandelingen");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DuurTijd",
                table: "Behandelingen",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
