using Microsoft.EntityFrameworkCore.Migrations;

namespace Wanderlust.Services.API.Migrations
{
    public partial class ChangedDBInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Landmarks",
                keyColumn: "LandmarkId",
                keyValue: 1,
                column: "MustSee",
                value: true);

            migrationBuilder.UpdateData(
                table: "Landmarks",
                keyColumn: "LandmarkId",
                keyValue: 2,
                column: "MustSee",
                value: true);

            migrationBuilder.UpdateData(
                table: "Landmarks",
                keyColumn: "LandmarkId",
                keyValue: 3,
                column: "MustSee",
                value: true);

            migrationBuilder.UpdateData(
                table: "Landmarks",
                keyColumn: "LandmarkId",
                keyValue: 4,
                column: "MustSee",
                value: true);

            migrationBuilder.UpdateData(
                table: "Landmarks",
                keyColumn: "LandmarkId",
                keyValue: 5,
                column: "MustSee",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Landmarks",
                keyColumn: "LandmarkId",
                keyValue: 1,
                column: "MustSee",
                value: false);

            migrationBuilder.UpdateData(
                table: "Landmarks",
                keyColumn: "LandmarkId",
                keyValue: 2,
                column: "MustSee",
                value: false);

            migrationBuilder.UpdateData(
                table: "Landmarks",
                keyColumn: "LandmarkId",
                keyValue: 3,
                column: "MustSee",
                value: false);

            migrationBuilder.UpdateData(
                table: "Landmarks",
                keyColumn: "LandmarkId",
                keyValue: 4,
                column: "MustSee",
                value: false);

            migrationBuilder.UpdateData(
                table: "Landmarks",
                keyColumn: "LandmarkId",
                keyValue: 5,
                column: "MustSee",
                value: false);
        }
    }
}
