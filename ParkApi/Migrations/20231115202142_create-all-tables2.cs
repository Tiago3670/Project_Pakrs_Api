using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkApi.Migrations
{
    /// <inheritdoc />
    public partial class createalltables2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_favourites_Users_UserId1",
                table: "favourites");

            migrationBuilder.DropForeignKey(
                name: "FK_favourites_parks_ParkId1",
                table: "favourites");

            migrationBuilder.DropIndex(
                name: "IX_favourites_ParkId1",
                table: "favourites");

            migrationBuilder.DropIndex(
                name: "IX_favourites_UserId1",
                table: "favourites");

            migrationBuilder.RenameColumn(
                name: "UserId1",
                table: "favourites",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "ParkId1",
                table: "favourites",
                newName: "ParkId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "favourites",
                newName: "UserId1");

            migrationBuilder.RenameColumn(
                name: "ParkId",
                table: "favourites",
                newName: "ParkId1");

            migrationBuilder.CreateIndex(
                name: "IX_favourites_ParkId1",
                table: "favourites",
                column: "ParkId1");

            migrationBuilder.CreateIndex(
                name: "IX_favourites_UserId1",
                table: "favourites",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_favourites_Users_UserId1",
                table: "favourites",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_favourites_parks_ParkId1",
                table: "favourites",
                column: "ParkId1",
                principalTable: "parks",
                principalColumn: "ParkId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
