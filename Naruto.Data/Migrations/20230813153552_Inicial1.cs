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
            migrationBuilder.AddColumn<string>(
                name: "RefImage",
                table: "Clan",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RefImage",
                table: "Characters",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefImage",
                table: "Clan");

            migrationBuilder.DropColumn(
                name: "RefImage",
                table: "Characters");
        }
    }
}
