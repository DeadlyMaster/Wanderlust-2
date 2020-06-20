using Microsoft.EntityFrameworkCore.Migrations;

namespace Wanderlust.Services.API.Migrations
{
    public partial class addedLandmarkInSight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Sights_LandmarkId",
                table: "Sights",
                column: "LandmarkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sights_Landmarks_LandmarkId",
                table: "Sights",
                column: "LandmarkId",
                principalTable: "Landmarks",
                principalColumn: "LandmarkId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sights_Landmarks_LandmarkId",
                table: "Sights");

            migrationBuilder.DropIndex(
                name: "IX_Sights_LandmarkId",
                table: "Sights");
        }
    }
}
