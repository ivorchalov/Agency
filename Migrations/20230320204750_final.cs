using Microsoft.EntityFrameworkCore.Migrations;

namespace Materials_storage_subsystem.Migrations
{
    public partial class final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IDKl",
                table: "StrSls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KlientId",
                table: "StrSls",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "StrSls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StrSls_KlientId",
                table: "StrSls",
                column: "KlientId");

            migrationBuilder.AddForeignKey(
                name: "FK_StrSls_Users_KlientId",
                table: "StrSls",
                column: "KlientId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StrSls_Users_KlientId",
                table: "StrSls");

            migrationBuilder.DropIndex(
                name: "IX_StrSls_KlientId",
                table: "StrSls");

            migrationBuilder.DropColumn(
                name: "IDKl",
                table: "StrSls");

            migrationBuilder.DropColumn(
                name: "KlientId",
                table: "StrSls");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "StrSls");
        }
    }
}
