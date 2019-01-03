using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EE.KapsalonX.Web.Migrations
{
    public partial class drie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "DuurTijd",
                table: "Behandelingen",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DuurTijd",
                table: "Behandelingen");
        }
    }
}
