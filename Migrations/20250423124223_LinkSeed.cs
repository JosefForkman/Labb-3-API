using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Labb_3_API.Migrations
{
    /// <inheritdoc />
    public partial class LinkSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Links",
                columns: new[] { "Id", "PersonServiceId", "Title", "Url" },
                values: new object[,]
                {
                    { 1, 1, "Länk 1", "https://example.com/link1" },
                    { 2, 2, "Länk 2", "https://example.com/link2" },
                    { 3, 3, "Länk 3", "https://example.com/link3" },
                    { 4, 4, "Länk 4", "https://example.com/link4" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
