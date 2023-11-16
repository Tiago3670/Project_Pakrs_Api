using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ParkApi.Migrations
{
    /// <inheritdoc />
    public partial class migrat3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parks_FeaturesList_FeaturesIDFeaturesListId",
                table: "Parks");

            migrationBuilder.DropIndex(
                name: "IX_Parks_FeaturesIDFeaturesListId",
                table: "Parks");

            migrationBuilder.DropColumn(
                name: "FeaturesIDFeaturesListId",
                table: "Parks");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeaturesList_Parks_FeaturesListId",
                table: "FeaturesList");

            migrationBuilder.AddColumn<int>(
                name: "FeaturesIDFeaturesListId",
                table: "Parks",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FeaturesListId",
                table: "FeaturesList",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateIndex(
                name: "IX_Parks_FeaturesIDFeaturesListId",
                table: "Parks",
                column: "FeaturesIDFeaturesListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parks_FeaturesList_FeaturesIDFeaturesListId",
                table: "Parks",
                column: "FeaturesIDFeaturesListId",
                principalTable: "FeaturesList",
                principalColumn: "FeaturesListId");
        }
    }
}
