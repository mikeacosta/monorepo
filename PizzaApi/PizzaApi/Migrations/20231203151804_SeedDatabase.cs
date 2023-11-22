using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaApi.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "pizza",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "very cheesy", "Cheese pizza" },
                    { 2, "lots of tuna", "Al Tono pizza" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "pizza",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "pizza",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
