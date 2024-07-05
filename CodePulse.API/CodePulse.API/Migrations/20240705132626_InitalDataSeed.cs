using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CodePulse.API.Migrations
{
    /// <inheritdoc />
    public partial class InitalDataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "UrlHandle" },
                values: new object[,]
                {
                    { new Guid("15096235-0b6b-4a6e-9390-2f2a0a6f7b08"), "TypeScript", "ts-blogs" },
                    { new Guid("34540768-eda6-4962-b9e6-ac3976484c4a"), "C#", "csharp-blogs" },
                    { new Guid("8adaae23-11d1-4038-828d-6a4b5a800c52"), "CSS", "css-blogs" },
                    { new Guid("c5eb4603-2e0b-457d-8ed4-da1f29fe4981"), "HTML", "html-blogs" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("15096235-0b6b-4a6e-9390-2f2a0a6f7b08"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("34540768-eda6-4962-b9e6-ac3976484c4a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8adaae23-11d1-4038-828d-6a4b5a800c52"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c5eb4603-2e0b-457d-8ed4-da1f29fe4981"));
        }
    }
}
