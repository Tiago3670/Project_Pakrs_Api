using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkApi.Migrations
{
    /// <inheritdoc />
    public partial class createsecondconnection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "parks",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_parks_LocationId",
                table: "parks",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_parks_locationDetails_LocationId",
                table: "parks",
                column: "LocationId",
                principalTable: "locationDetails",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_parks_locationDetails_LocationId",
                table: "parks");

            migrationBuilder.DropIndex(
                name: "IX_parks_LocationId",
                table: "parks");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "parks");
        }
    }
}
