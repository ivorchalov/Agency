using Microsoft.EntityFrameworkCore.Migrations;

namespace Materials_storage_subsystem.Migrations
{
    public partial class fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dogovors_GroupDogs_GroupDogId",
                table: "Dogovors");

            migrationBuilder.DropForeignKey(
                name: "FK_StrSls_GroupDogs_GroupDogId",
                table: "StrSls");

            migrationBuilder.DropTable(
                name: "GroupDogs");

            migrationBuilder.DropIndex(
                name: "IX_StrSls_GroupDogId",
                table: "StrSls");

            migrationBuilder.DropIndex(
                name: "IX_Dogovors_GroupDogId",
                table: "Dogovors");

            migrationBuilder.DropColumn(
                name: "GroupDogId",
                table: "StrSls");

            migrationBuilder.DropColumn(
                name: "GroupDogId",
                table: "Dogovors");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Dogovors",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Dogovors");

            migrationBuilder.AddColumn<int>(
                name: "GroupDogId",
                table: "StrSls",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GroupDogId",
                table: "Dogovors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GroupDogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupDogs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StrSls_GroupDogId",
                table: "StrSls",
                column: "GroupDogId");

            migrationBuilder.CreateIndex(
                name: "IX_Dogovors_GroupDogId",
                table: "Dogovors",
                column: "GroupDogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dogovors_GroupDogs_GroupDogId",
                table: "Dogovors",
                column: "GroupDogId",
                principalTable: "GroupDogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StrSls_GroupDogs_GroupDogId",
                table: "StrSls",
                column: "GroupDogId",
                principalTable: "GroupDogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
