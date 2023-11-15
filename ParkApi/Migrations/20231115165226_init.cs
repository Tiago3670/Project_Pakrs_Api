using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ParkApi.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
               name: "LocationDetail",
               columns: table => new
               {
                   LocationId = table.Column<int>(type: "integer", nullable: false)
                       .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                   City = table.Column<string>(type: "text", nullable: false),
                   PostalCode = table.Column<string>(type: "text", nullable: false),
                   Street = table.Column<string>(type: "text", nullable: false),
                   Coordinates=table.Column<string>(type:"text", nullable:false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_LocationDetail", x => x.LocationId);
               });


              migrationBuilder.CreateTable(
                 name: "FeaturesList",
                 columns: table => new
                 {
                     FeaturesListId = table.Column<int>(type: "integer", nullable: false)
                         .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                     Food = table.Column<bool>(type: "bool", nullable: true),
                     Shops = table.Column<bool>(type: "bool", nullable: true),
                     Entertainment = table.Column<bool>(type: "bool", nullable: true),
                     Gym = table.Column<bool>(type: "bool", nullable: true),
                     WiFi = table.Column<bool>(type: "bool", nullable: true),
                     PetsAllowed = table.Column<bool>(type: "bool", nullable: true),
                 },
                 constraints: table =>
                 {
                     table.PrimaryKey("PK_FeaturesList", x => x.FeaturesListId);
                 });

              migrationBuilder.CreateTable(
                 name: "Parks",
                 columns: table => new
                 {
                     ParkId = table.Column<int>(type: "integer", nullable: false)
                         .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                     LocationId = table.Column<int>(type: "integer", nullable: false),
                     FeaturesListId = table.Column<int>(type: "integer", nullable: false),
                     ImageUrl = table.Column<string>(type: "text", nullable: false)
                 },
                 constraints: table =>
                 {
                     table.PrimaryKey("PK_Parks", x => x.ParkId);
                    // table.ForeignKey("");
                 });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Users");
            migrationBuilder.DropTable(name: "Parks");
            migrationBuilder.DropTable(name: "FeaturesList");
            migrationBuilder.DropTable(name: "LocationDetail");

        }
    }
}
