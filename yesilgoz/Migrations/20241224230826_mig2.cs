using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SurveyPortal.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Surveys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, true, "Categori 1" },
                    { 2, true, "Categori 2" },
                    { 3, true, "Categori 3" }
                });

            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "Id",
                keyValue: 1,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "IsActive" },
                values: new object[] { 2, true });

            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "Id",
                keyValue: 3,
                column: "CategoryId",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_CategoryId",
                table: "Surveys",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Surveys_Categories_CategoryId",
                table: "Surveys",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Surveys_Categories_CategoryId",
                table: "Surveys");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Surveys_CategoryId",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Surveys");

            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsActive",
                value: false);
        }
    }
}
