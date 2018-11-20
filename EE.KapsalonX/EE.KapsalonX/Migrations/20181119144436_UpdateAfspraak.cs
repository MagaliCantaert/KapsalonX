using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EE.KapsalonX.Web.Migrations
{
    public partial class UpdateAfspraak : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tekst",
                table: "Events",
                newName: "Klant");

            migrationBuilder.RenameColumn(
                name: "StartDatum",
                table: "Events",
                newName: "StartTijd");

            migrationBuilder.RenameColumn(
                name: "EindDatum",
                table: "Events",
                newName: "EindTijd");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Events",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "Behandeling",
                table: "Events",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TimeSpan",
                table: "Afspraken",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Behandeling",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "TimeSpan",
                table: "Afspraken");

            migrationBuilder.RenameColumn(
                name: "StartTijd",
                table: "Events",
                newName: "StartDatum");

            migrationBuilder.RenameColumn(
                name: "Klant",
                table: "Events",
                newName: "Tekst");

            migrationBuilder.RenameColumn(
                name: "EindTijd",
                table: "Events",
                newName: "EindDatum");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Events",
                nullable: false,
                oldClrType: typeof(Guid))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
        }
    }
}
