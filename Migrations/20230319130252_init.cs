using Microsoft.EntityFrameworkCore.Migrations;

namespace Materials_storage_subsystem.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroupDogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupDogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tarifs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Object = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Conditions = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarifs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dogovors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDKl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDAg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDTr = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDGroup = table.Column<int>(type: "int", nullable: false),
                    Described = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TarifId = table.Column<int>(type: "int", nullable: true),
                    GroupDogId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dogovors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dogovors_GroupDogs_GroupDogId",
                        column: x => x.GroupDogId,
                        principalTable: "GroupDogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dogovors_Tarifs_TarifId",
                        column: x => x.TarifId,
                        principalTable: "Tarifs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StrSls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDKl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDAg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDDogv = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Described = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDGroup = table.Column<int>(type: "int", nullable: false),
                    DogovorId = table.Column<int>(type: "int", nullable: true),
                    GroupDogId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrSls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StrSls_Dogovors_DogovorId",
                        column: x => x.DogovorId,
                        principalTable: "Dogovors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StrSls_GroupDogs_GroupDogId",
                        column: x => x.GroupDogId,
                        principalTable: "GroupDogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dogovors_GroupDogId",
                table: "Dogovors",
                column: "GroupDogId");

            migrationBuilder.CreateIndex(
                name: "IX_Dogovors_TarifId",
                table: "Dogovors",
                column: "TarifId");

            migrationBuilder.CreateIndex(
                name: "IX_StrSls_DogovorId",
                table: "StrSls",
                column: "DogovorId");

            migrationBuilder.CreateIndex(
                name: "IX_StrSls_GroupDogId",
                table: "StrSls",
                column: "GroupDogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StrSls");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Dogovors");

            migrationBuilder.DropTable(
                name: "GroupDogs");

            migrationBuilder.DropTable(
                name: "Tarifs");
        }
    }
}
