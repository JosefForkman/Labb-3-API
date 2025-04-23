using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Labb_3_API.Migrations
{
    /// <inheritdoc />
    public partial class LinkTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonServices",
                table: "PersonServices");

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

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PersonServices",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "LinkId",
                table: "PersonServices",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonServices",
                table: "PersonServices",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "PersonServices",
                columns: new[] { "Id", "LinkId", "PersonId", "ServiceId" },
                values: new object[,]
                {
                    { 1, null, 1, 1 },
                    { 2, null, 1, 2 },
                    { 3, null, 2, 2 },
                    { 4, null, 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonServices_LinkId",
                table: "PersonServices",
                column: "LinkId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonServices_PersonId",
                table: "PersonServices",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonServices_Links_LinkId",
                table: "PersonServices",
                column: "LinkId",
                principalTable: "Links",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonServices_Links_LinkId",
                table: "PersonServices");

            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonServices",
                table: "PersonServices");

            migrationBuilder.DropIndex(
                name: "IX_PersonServices_LinkId",
                table: "PersonServices");

            migrationBuilder.DropIndex(
                name: "IX_PersonServices_PersonId",
                table: "PersonServices");

            migrationBuilder.DeleteData(
                table: "PersonServices",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PersonServices",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PersonServices",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PersonServices",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PersonServices");

            migrationBuilder.DropColumn(
                name: "LinkId",
                table: "PersonServices");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonServices",
                table: "PersonServices",
                columns: new[] { "PersonId", "ServiceId" });

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
    }
}
