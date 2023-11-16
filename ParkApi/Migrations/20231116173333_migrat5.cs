using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkApi.Migrations
{
    /// <inheritdoc />
    public partial class migrat5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocationDetail_Parks_ParkId",
                table: "LocationDetail");

            migrationBuilder.RenameColumn(
                name: "FeaturesListId",
                table: "FeaturesList",
                newName: "FeaturesId");

            migrationBuilder.AlterColumn<int>(
                name: "ParkId",
                table: "LocationDetail",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_LocationDetail_Parks_ParkId",
                table: "LocationDetail",
                column: "ParkId",
                principalTable: "Parks",
                principalColumn: "ParkId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocationDetail_Parks_ParkId",
                table: "LocationDetail");

            migrationBuilder.RenameColumn(
                name: "FeaturesId",
                table: "FeaturesList",
                newName: "FeaturesListId");

            migrationBuilder.AlterColumn<int>(
                name: "ParkId",
                table: "LocationDetail",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationDetail_Parks_ParkId",
                table: "LocationDetail",
                column: "ParkId",
                principalTable: "Parks",
                principalColumn: "ParkId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
