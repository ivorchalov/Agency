using Microsoft.EntityFrameworkCore.Migrations;

namespace Materials_storage_subsystem.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IDGroup",
                table: "StrSls");

            migrationBuilder.DropColumn(
                name: "IDGroup",
                table: "Dogovors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IDGroup",
                table: "StrSls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IDGroup",
                table: "Dogovors",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
