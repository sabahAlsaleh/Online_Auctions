using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjectApplication.Migrations.AuctionDb
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BidDBs",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "BidDBs",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "AuctionDBs",
                keyColumn: "Id",
                keyValue: -1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AuctionDBs",
                columns: new[] { "Id", "Auctioneer", "Description", "EndDateTime", "Name", "StartingPrice", "UserName" },
                values: new object[] { -1, "Auctioneer 1", "Description 1", new DateTime(2023, 10, 23, 10, 8, 58, 253, DateTimeKind.Local).AddTicks(6339), "Auction And Bids plasce", 100m, "sabahaa@kth.se" });

            migrationBuilder.InsertData(
                table: "BidDBs",
                columns: new[] { "Id", "Amount", "AuctionId", "Bidder", "TimePlaced" },
                values: new object[,]
                {
                    { -2, 200m, -1, "Bidder 2", new DateTime(2023, 10, 23, 10, 8, 58, 253, DateTimeKind.Local).AddTicks(6524) },
                    { -1, 150m, -1, "Bidder1 ", new DateTime(2023, 10, 23, 10, 8, 58, 253, DateTimeKind.Local).AddTicks(6521) }
                });
        }
    }
}
