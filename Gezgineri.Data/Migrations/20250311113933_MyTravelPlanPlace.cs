using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gezgineri.Data.Migrations
{
    /// <inheritdoc />
    public partial class MyTravelPlanPlace : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TravelPlanPlaces");

            migrationBuilder.DropTable(
                name: "TravelPlans");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Places",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "MyTravels",
                newName: "Country");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Places",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "MyTravelPlans",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MyTravelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlaceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyTravelPlans", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MyTravelPlans_MyTravels_MyTravelId",
                        column: x => x.MyTravelId,
                        principalTable: "MyTravels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MyTravelPlans_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MyTravelPlans_MyTravelId",
                table: "MyTravelPlans",
                column: "MyTravelId");

            migrationBuilder.CreateIndex(
                name: "IX_MyTravelPlans_PlaceId",
                table: "MyTravelPlans",
                column: "PlaceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyTravelPlans");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Places");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Places",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "MyTravels",
                newName: "Location");

            migrationBuilder.CreateTable(
                name: "TravelPlans",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MyTravelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelPlans", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TravelPlans_MyTravels_MyTravelId",
                        column: x => x.MyTravelId,
                        principalTable: "MyTravels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TravelPlanPlaces",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlaceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TravelPlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelPlanPlaces", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TravelPlanPlaces_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TravelPlanPlaces_TravelPlans_TravelPlanId",
                        column: x => x.TravelPlanId,
                        principalTable: "TravelPlans",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TravelPlanPlaces_PlaceId",
                table: "TravelPlanPlaces",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelPlanPlaces_TravelPlanId",
                table: "TravelPlanPlaces",
                column: "TravelPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelPlans_MyTravelId",
                table: "TravelPlans",
                column: "MyTravelId");
        }
    }
}
