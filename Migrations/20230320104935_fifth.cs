using Microsoft.EntityFrameworkCore.Migrations;

namespace Materials_storage_subsystem.Migrations
{
    public partial class fifth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IDKl",
                table: "StrSls");

            migrationBuilder.AlterColumn<int>(
                name: "IDAg",
                table: "StrSls",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AgentId",
                table: "StrSls",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IDKl",
                table: "Dogovors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IDAg",
                table: "Dogovors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AgentId",
                table: "Dogovors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KlientId",
                table: "Dogovors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StrSls_AgentId",
                table: "StrSls",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Dogovors_AgentId",
                table: "Dogovors",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Dogovors_KlientId",
                table: "Dogovors",
                column: "KlientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dogovors_Users_AgentId",
                table: "Dogovors",
                column: "AgentId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dogovors_Users_KlientId",
                table: "Dogovors",
                column: "KlientId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StrSls_Users_AgentId",
                table: "StrSls",
                column: "AgentId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dogovors_Users_AgentId",
                table: "Dogovors");

            migrationBuilder.DropForeignKey(
                name: "FK_Dogovors_Users_KlientId",
                table: "Dogovors");

            migrationBuilder.DropForeignKey(
                name: "FK_StrSls_Users_AgentId",
                table: "StrSls");

            migrationBuilder.DropIndex(
                name: "IX_StrSls_AgentId",
                table: "StrSls");

            migrationBuilder.DropIndex(
                name: "IX_Dogovors_AgentId",
                table: "Dogovors");

            migrationBuilder.DropIndex(
                name: "IX_Dogovors_KlientId",
                table: "Dogovors");

            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "StrSls");

            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "Dogovors");

            migrationBuilder.DropColumn(
                name: "KlientId",
                table: "Dogovors");

            migrationBuilder.AlterColumn<string>(
                name: "IDAg",
                table: "StrSls",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "IDKl",
                table: "StrSls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IDKl",
                table: "Dogovors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "IDAg",
                table: "Dogovors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
