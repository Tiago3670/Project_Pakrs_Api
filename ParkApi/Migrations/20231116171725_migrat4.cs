using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ParkApi.Migrations
{
    /// <inheritdoc />
    public partial class migrat4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeaturesList_Parks_FeaturesListId",
                table: "FeaturesList");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationDetail_Parks_LocationId",
                table: "LocationDetail");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "LocationDetail",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "ParkId",
                table: "LocationDetail",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "FeaturesListId",
                table: "FeaturesList",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "ParkId",
                table: "FeaturesList",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_LocationDetail_ParkId",
                table: "LocationDetail",
                column: "ParkId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FeaturesList_ParkId",
                table: "FeaturesList",
                column: "ParkId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FeaturesList_Parks_ParkId",
                table: "FeaturesList",
                column: "ParkId",
                principalTable: "Parks",
                principalColumn: "ParkId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationDetail_Parks_ParkId",
                table: "LocationDetail",
                column: "ParkId",
                principalTable: "Parks",
                principalColumn: "ParkId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeaturesList_Parks_ParkId",
                table: "FeaturesList");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationDetail_Parks_ParkId",
                table: "LocationDetail");

            migrationBuilder.DropIndex(
                name: "IX_LocationDetail_ParkId",
                table: "LocationDetail");

            migrationBuilder.DropIndex(
                name: "IX_FeaturesList_ParkId",
                table: "FeaturesList");

            migrationBuilder.DropColumn(
                name: "ParkId",
                table: "LocationDetail");

            migrationBuilder.DropColumn(
                name: "ParkId",
                table: "FeaturesList");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "LocationDetail",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "FeaturesListId",
                table: "FeaturesList",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_FeaturesList_Parks_FeaturesListId",
                table: "FeaturesList",
                column: "FeaturesListId",
                principalTable: "Parks",
                principalColumn: "ParkId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationDetail_Parks_LocationId",
                table: "LocationDetail",
                column: "LocationId",
                principalTable: "Parks",
                principalColumn: "ParkId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
