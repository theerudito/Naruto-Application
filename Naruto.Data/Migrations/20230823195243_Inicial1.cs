using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Naruto.Data.Migrations
{
    /// <inheritdoc />
    public partial class Inicial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Auth",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auth", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "Clan",
                columns: table => new
                {
                    IdClan = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClanName = table.Column<string>(type: "TEXT", nullable: true),
                    Image = table.Column<string>(type: "TEXT", nullable: false),
                    RefImage = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clan", x => x.IdClan);
                });

            migrationBuilder.CreateTable(
                name: "Current",
                columns: table => new
                {
                    IdStatus = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Alive = table.Column<bool>(type: "INTEGER", nullable: false),
                    Status = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Current", x => x.IdStatus);
                });

            migrationBuilder.CreateTable(
                name: "Jutsu",
                columns: table => new
                {
                    IdJutsu = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    JutsuName = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jutsu", x => x.IdJutsu);
                });

            migrationBuilder.CreateTable(
                name: "Ocupation",
                columns: table => new
                {
                    IdOcupation = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OcupationName = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocupation", x => x.IdOcupation);
                });

            migrationBuilder.CreateTable(
                name: "Village",
                columns: table => new
                {
                    IdVillage = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VillageName = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Village", x => x.IdVillage);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    IdCharacter = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    Image = table.Column<string>(type: "TEXT", nullable: false),
                    RefImage = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<bool>(type: "INTEGER", nullable: false),
                    IdClan = table.Column<int>(type: "INTEGER", nullable: true),
                    ClanIdClan = table.Column<int>(type: "INTEGER", nullable: true),
                    IdVillage = table.Column<int>(type: "INTEGER", nullable: true),
                    VillagesIdVillage = table.Column<int>(type: "INTEGER", nullable: true),
                    IdJutsu = table.Column<int>(type: "INTEGER", nullable: true),
                    JutsusIdJutsu = table.Column<int>(type: "INTEGER", nullable: true),
                    IdOcupation = table.Column<int>(type: "INTEGER", nullable: true),
                    OcupationsIdOcupation = table.Column<int>(type: "INTEGER", nullable: true),
                    IdStatus = table.Column<int>(type: "INTEGER", nullable: true),
                    CurrentIdStatus = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.IdCharacter);
                    table.ForeignKey(
                        name: "FK_Characters_Clan_ClanIdClan",
                        column: x => x.ClanIdClan,
                        principalTable: "Clan",
                        principalColumn: "IdClan");
                    table.ForeignKey(
                        name: "FK_Characters_Current_CurrentIdStatus",
                        column: x => x.CurrentIdStatus,
                        principalTable: "Current",
                        principalColumn: "IdStatus");
                    table.ForeignKey(
                        name: "FK_Characters_Jutsu_JutsusIdJutsu",
                        column: x => x.JutsusIdJutsu,
                        principalTable: "Jutsu",
                        principalColumn: "IdJutsu");
                    table.ForeignKey(
                        name: "FK_Characters_Ocupation_OcupationsIdOcupation",
                        column: x => x.OcupationsIdOcupation,
                        principalTable: "Ocupation",
                        principalColumn: "IdOcupation");
                    table.ForeignKey(
                        name: "FK_Characters_Village_VillagesIdVillage",
                        column: x => x.VillagesIdVillage,
                        principalTable: "Village",
                        principalColumn: "IdVillage");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_ClanIdClan",
                table: "Characters",
                column: "ClanIdClan");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_CurrentIdStatus",
                table: "Characters",
                column: "CurrentIdStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_JutsusIdJutsu",
                table: "Characters",
                column: "JutsusIdJutsu");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_OcupationsIdOcupation",
                table: "Characters",
                column: "OcupationsIdOcupation");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_VillagesIdVillage",
                table: "Characters",
                column: "VillagesIdVillage");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auth");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Clan");

            migrationBuilder.DropTable(
                name: "Current");

            migrationBuilder.DropTable(
                name: "Jutsu");

            migrationBuilder.DropTable(
                name: "Ocupation");

            migrationBuilder.DropTable(
                name: "Village");
        }
    }
}
