using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TownTalk.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialDataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Capital of the United Kingdom", "London" },
                    { 2, "Aloha", "Honolulu" },
                    { 3, "There's no there there", "Oakland" }
                });

            migrationBuilder.InsertData(
                table: "PointsOfInterest",
                columns: new[] { "Id", "Description", "Name", "TownId" },
                values: new object[,]
                {
                    { 1, "One of London's oldest food markets", "Borough Market", 1 },
                    { 2, "Historic castle with over 1,000 years of history", "Tower of London", 1 },
                    { 3, "This iconic landmark in Waikiki is one of Hawaii's most famous beaches", "Waikiki Beach", 2 },
                    { 4, "Popular volcanic tuff cone on Oahu", "Diamond Head", 2 },
                    { 5, "Entertainment and business destination on the waterfront", "Jack London Square", 3 },
                    { 6, "Large tidal lagoon in the center of Oakland", "Lake Merritt", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PointsOfInterest",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Towns",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Towns",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Towns",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
