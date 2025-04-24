using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Labb_3_API.Migrations
{
    /// <inheritdoc />
    public partial class RenameServicetoIntrest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Links_PersonServices_PersonServiceId",
                table: "Links");

            migrationBuilder.DropTable(
                name: "PersonServices");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.RenameColumn(
                name: "PersonServiceId",
                table: "Links",
                newName: "PersonIntrestId");

            migrationBuilder.RenameIndex(
                name: "IX_Links_PersonServiceId",
                table: "Links",
                newName: "IX_Links_PersonIntrestId");

            migrationBuilder.CreateTable(
                name: "Intrests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intrests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonIntrests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    IntrestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonIntrests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonIntrests_Intrests_IntrestId",
                        column: x => x.IntrestId,
                        principalTable: "Intrests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonIntrests_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Intrests",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "Intresserad av olika musikgenrer och artister.", "Musik" },
                    { 2, "Följer och utövar olika sporter.", "Sport" },
                    { 3, "Fascinerad av den senaste tekniska utvecklingen.", "Teknologi" },
                    { 4, "Älskar att upptäcka nya platser och kulturer.", "Resor" }
                });

            migrationBuilder.InsertData(
                table: "PersonIntrests",
                columns: new[] { "Id", "IntrestId", "PersonId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 2, 2 },
                    { 4, 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Intrests_Title",
                table: "Intrests",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonIntrests_IntrestId",
                table: "PersonIntrests",
                column: "IntrestId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonIntrests_PersonId",
                table: "PersonIntrests",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Links_PersonIntrests_PersonIntrestId",
                table: "Links",
                column: "PersonIntrestId",
                principalTable: "PersonIntrests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Links_PersonIntrests_PersonIntrestId",
                table: "Links");

            migrationBuilder.DropTable(
                name: "PersonIntrests");

            migrationBuilder.DropTable(
                name: "Intrests");

            migrationBuilder.RenameColumn(
                name: "PersonIntrestId",
                table: "Links",
                newName: "PersonServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Links_PersonIntrestId",
                table: "Links",
                newName: "IX_Links_PersonServiceId");

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonServices_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonServices_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                columns: new[] { "Id", "PersonId", "ServiceId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 2, 2 },
                    { 4, 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonServices_PersonId",
                table: "PersonServices",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonServices_ServiceId",
                table: "PersonServices",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_Title",
                table: "Services",
                column: "Title",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Links_PersonServices_PersonServiceId",
                table: "Links",
                column: "PersonServiceId",
                principalTable: "PersonServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
