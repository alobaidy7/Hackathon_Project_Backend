using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hackathon_Project_Backend.Migrations
{
    /// <inheritdoc />
    public partial class citiesadd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Reads");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Reads",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reads_CityId",
                table: "Reads",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reads_Cities_CityId",
                table: "Reads",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reads_Cities_CityId",
                table: "Reads");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Reads_CityId",
                table: "Reads");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Reads");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Reads",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
