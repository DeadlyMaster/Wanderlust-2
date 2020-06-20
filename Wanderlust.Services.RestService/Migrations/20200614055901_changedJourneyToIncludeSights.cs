using Microsoft.EntityFrameworkCore.Migrations;

namespace Wanderlust.Services.API.Migrations
{
    public partial class changedJourneyToIncludeSights : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Sights_JourneyId",
                table: "Sights",
                column: "JourneyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sights_Journeys_JourneyId",
                table: "Sights",
                column: "JourneyId",
                principalTable: "Journeys",
                principalColumn: "JourneyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sights_Journeys_JourneyId",
                table: "Sights");

            migrationBuilder.DropIndex(
                name: "IX_Sights_JourneyId",
                table: "Sights");
        }
    }
}
