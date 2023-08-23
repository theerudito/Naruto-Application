using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Naruto.Data.Migrations
{
    /// <inheritdoc />
    public partial class Inicial4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JutsusIdJutsu",
                table: "Characters",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OcupationsIdOcupation",
                table: "Characters",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusIdStatus",
                table: "Characters",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VillagesIdVillage",
                table: "Characters",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Jutsu",
                columns: table => new
                {
                    IdJutsu = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    JutsuName = table.Column<string>(type: "TEXT", nullable: true)
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
                    OcupationName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocupation", x => x.IdOcupation);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    IdStatus = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Alive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.IdStatus);
                });

            migrationBuilder.CreateTable(
                name: "Village",
                columns: table => new
                {
                    IdVillage = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VillageName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Village", x => x.IdVillage);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_JutsusIdJutsu",
                table: "Characters",
                column: "JutsusIdJutsu");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_OcupationsIdOcupation",
                table: "Characters",
                column: "OcupationsIdOcupation");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_StatusIdStatus",
                table: "Characters",
                column: "StatusIdStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_VillagesIdVillage",
                table: "Characters",
                column: "VillagesIdVillage");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Jutsu_JutsusIdJutsu",
                table: "Characters",
                column: "JutsusIdJutsu",
                principalTable: "Jutsu",
                principalColumn: "IdJutsu");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Ocupation_OcupationsIdOcupation",
                table: "Characters",
                column: "OcupationsIdOcupation",
                principalTable: "Ocupation",
                principalColumn: "IdOcupation");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Status_StatusIdStatus",
                table: "Characters",
                column: "StatusIdStatus",
                principalTable: "Status",
                principalColumn: "IdStatus");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Village_VillagesIdVillage",
                table: "Characters",
                column: "VillagesIdVillage",
                principalTable: "Village",
                principalColumn: "IdVillage");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Jutsu_JutsusIdJutsu",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Ocupation_OcupationsIdOcupation",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Status_StatusIdStatus",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Village_VillagesIdVillage",
                table: "Characters");

            migrationBuilder.DropTable(
                name: "Jutsu");

            migrationBuilder.DropTable(
                name: "Ocupation");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Village");

            migrationBuilder.DropIndex(
                name: "IX_Characters_JutsusIdJutsu",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_OcupationsIdOcupation",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_StatusIdStatus",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_VillagesIdVillage",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "JutsusIdJutsu",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "OcupationsIdOcupation",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "StatusIdStatus",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "VillagesIdVillage",
                table: "Characters");
        }
    }
}
