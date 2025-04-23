using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb_3_API.Migrations
{
    /// <inheritdoc />
    public partial class relationToLink : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonServices_Links_LinkId",
                table: "PersonServices");

            migrationBuilder.DropIndex(
                name: "IX_PersonServices_LinkId",
                table: "PersonServices");

            migrationBuilder.DropColumn(
                name: "LinkId",
                table: "PersonServices");

            migrationBuilder.CreateIndex(
                name: "IX_Links_PersonServiceId",
                table: "Links",
                column: "PersonServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Links_PersonServices_PersonServiceId",
                table: "Links",
                column: "PersonServiceId",
                principalTable: "PersonServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Links_PersonServices_PersonServiceId",
                table: "Links");

            migrationBuilder.DropIndex(
                name: "IX_Links_PersonServiceId",
                table: "Links");

            migrationBuilder.AddColumn<int>(
                name: "LinkId",
                table: "PersonServices",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "PersonServices",
                keyColumn: "Id",
                keyValue: 1,
                column: "LinkId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PersonServices",
                keyColumn: "Id",
                keyValue: 2,
                column: "LinkId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PersonServices",
                keyColumn: "Id",
                keyValue: 3,
                column: "LinkId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PersonServices",
                keyColumn: "Id",
                keyValue: 4,
                column: "LinkId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_PersonServices_LinkId",
                table: "PersonServices",
                column: "LinkId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonServices_Links_LinkId",
                table: "PersonServices",
                column: "LinkId",
                principalTable: "Links",
                principalColumn: "Id");
        }
    }
}
