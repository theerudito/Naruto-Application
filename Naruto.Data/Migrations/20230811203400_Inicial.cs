using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Naruto.Data.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clan",
                columns: table => new
                {
                    IdClan = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClanName = table.Column<string>(type: "TEXT", nullable: true),
                    Image = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clan", x => x.IdClan);
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
                    IdClan = table.Column<int>(type: "INTEGER", nullable: true),
                    ClanIdClan = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.IdCharacter);
                    table.ForeignKey(
                        name: "FK_Characters_Clan_ClanIdClan",
                        column: x => x.ClanIdClan,
                        principalTable: "Clan",
                        principalColumn: "IdClan");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_ClanIdClan",
                table: "Characters",
                column: "ClanIdClan");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Clan");
        }
    }
}
