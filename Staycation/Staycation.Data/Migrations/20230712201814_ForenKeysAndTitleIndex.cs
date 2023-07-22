using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Staycation.Data.Migrations
{
    /// <inheritdoc />
    public partial class ForenKeysAndTitleIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Accommodations",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_AccommodationId",
                table: "Reservations",
                column: "AccommodationId");

            migrationBuilder.CreateIndex(
                name: "IX_Accommodations_LocationId",
                table: "Accommodations",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Accommodations_Title",
                table: "Accommodations",
                column: "Title",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Accommodations_Locations_LocationId",
                table: "Accommodations",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Accommodations_AccommodationId",
                table: "Reservations",
                column: "AccommodationId",
                principalTable: "Accommodations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accommodations_Locations_LocationId",
                table: "Accommodations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Accommodations_AccommodationId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_AccommodationId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Accommodations_LocationId",
                table: "Accommodations");

            migrationBuilder.DropIndex(
                name: "IX_Accommodations_Title",
                table: "Accommodations");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Accommodations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
