using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gezgineri.Data.Migrations
{
    /// <inheritdoc />
    public partial class FavoriteTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFavorite",
                table: "Places");

            migrationBuilder.CreateTable(
                name: "FavoritePlaces",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlaceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TravelerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsFavorite = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoritePlaces", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FavoritePlaces_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_FavoritePlaces_Travelers_TravelerId",
                        column: x => x.TravelerId,
                        principalTable: "Travelers",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavoritePlaces_PlaceId",
                table: "FavoritePlaces",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoritePlaces_TravelerId",
                table: "FavoritePlaces",
                column: "TravelerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoritePlaces");

            migrationBuilder.AddColumn<bool>(
                name: "IsFavorite",
                table: "Places",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
