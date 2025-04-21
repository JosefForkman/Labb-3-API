using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Labb_3_API.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "BirthDate", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "anna.svensson@example.com", "Anna", "Svensson", "070-1234567" },
                    { 2, new DateTime(1985, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "erik.karlsson@example.com", "Erik", "Karlsson", "073-9876543" },
                    { 3, new DateTime(1998, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "lisa.andersson@example.com", "Lisa", "Andersson", "" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "Intresserad av olika musikgenrer och artister.", "Musik" },
                    { 2, "Följer och utövar olika sporter.", "Sport" },
                    { 3, "Fascinerad av den senaste tekniska utvecklingen.", "Teknologi" },
                    { 4, "Älskar att upptäcka nya platser och kulturer.", "Resor" }
                });

            migrationBuilder.InsertData(
                table: "PersonServices",
                columns: new[] { "PersonId", "ServiceId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 3, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PersonServices",
                keyColumns: new[] { "PersonId", "ServiceId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "PersonServices",
                keyColumns: new[] { "PersonId", "ServiceId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "PersonServices",
                keyColumns: new[] { "PersonId", "ServiceId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "PersonServices",
                keyColumns: new[] { "PersonId", "ServiceId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
