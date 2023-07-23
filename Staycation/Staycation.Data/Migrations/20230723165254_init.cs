using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Staycation.Data.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accommodations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Subtitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Categorisation = table.Column<int>(type: "int", nullable: false),
                    PersonCount = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FreeCancellation = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accommodations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accommodations_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccommodationId = table.Column<int>(type: "int", nullable: false),
                    Confirmed = table.Column<bool>(type: "bit", nullable: false),
                    PersonCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Accommodations_AccommodationId",
                        column: x => x.AccommodationId,
                        principalTable: "Accommodations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "ImageUrl", "Name", "PostalCode" },
                values: new object[,]
                {
                    { 1, "https://images2.imgbox.com/66/33/4ll057fa_o.jpg", "Argos", "21200" },
                    { 2, "https://images2.imgbox.com/62/d7/3rJYe9p9_o.jpg", "Chania", "74212" },
                    { 3, "https://images2.imgbox.com/34/8f/yeONFHwj_o.jpg", "Nafplion", "21100" },
                    { 4, "https://images2.imgbox.com/fd/3b/xYT7BlSR_o.jpg", "Osijek", "31000" }
                });

            migrationBuilder.InsertData(
                table: "Accommodations",
                columns: new[] { "Id", "Categorisation", "Description", "FreeCancellation", "ImageUrl", "LocationId", "PersonCount", "Price", "Subtitle", "Title", "Type" },
                values: new object[,]
                {
                    { 1, 4, "Family hotel", false, "https://picsum.photos/800/600", 3, 230, 133.99m, "Your getaway", "Adama", "Hotel" },
                    { 2, 4, "Villa in Nafplion", true, "https://picsum.photos/800/600", 3, 310, 199.99m, "Villa", "CasaKrystal", "Villa" },
                    { 3, 3, "Cozy studio near big parks", true, "https://picsum.photos/800/600", 4, 230, 49.99m, "Apartment in heart of Osijek", "Epoketa", "Apartment" }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "AccommodationId", "Confirmed", "Email", "PersonCount" },
                values: new object[,]
                {
                    { 1, 3, true, "mjmail@himail.com", 2 },
                    { 2, 1, true, "pero@himail.com", 9 },
                    { 3, 3, true, "lara@himail.com", 4 },
                    { 4, 2, true, "info@gert.hr", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accommodations_LocationId",
                table: "Accommodations",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Accommodations_Title",
                table: "Accommodations",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_AccommodationId",
                table: "Reservations",
                column: "AccommodationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Accommodations");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
