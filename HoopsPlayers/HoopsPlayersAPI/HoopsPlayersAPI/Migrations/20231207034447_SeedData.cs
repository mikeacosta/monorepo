using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HoopsPlayersAPI.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "HoopsPlayers",
                columns: new[] { "Id", "Country", "FirstName", "LastName", "Team" },
                values: new object[,]
                {
                    { 1, "USA", "Stephen", "Curry", "Warriors" },
                    { 2, "SRB", "Nikola", "Jokic", "Nuggets" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HoopsPlayers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HoopsPlayers",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
