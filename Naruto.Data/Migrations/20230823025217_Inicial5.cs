using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Naruto.Data.Migrations
{
    /// <inheritdoc />
    public partial class Inicial5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdJutsu",
                table: "Characters",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdOcupation",
                table: "Characters",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdStatus",
                table: "Characters",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdVillage",
                table: "Characters",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdJutsu",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "IdOcupation",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "IdStatus",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "IdVillage",
                table: "Characters");
        }
    }
}
