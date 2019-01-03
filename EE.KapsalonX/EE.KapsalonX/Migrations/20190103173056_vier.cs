using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EE.KapsalonX.Web.Migrations
{
    public partial class vier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DuurTijd",
                table: "Behandelingen",
                nullable: false,
                oldClrType: typeof(TimeSpan));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "DuurTijd",
                table: "Behandelingen",
                nullable: false,
                oldClrType: typeof(DateTime));
        }
    }
}
