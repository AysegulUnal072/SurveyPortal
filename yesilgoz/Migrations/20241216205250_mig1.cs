using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurveyPortal.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Surveys",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsActive",
                value: false);

            migrationBuilder.UpdateData(
                table: "Surveys",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsActive",
                value: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Surveys");
        }
    }
}
