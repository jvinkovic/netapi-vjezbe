using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Staycation.Data.Migrations
{
    /// <inheritdoc />
    public partial class podaci : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Accommodations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Accommodations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Accommodations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
