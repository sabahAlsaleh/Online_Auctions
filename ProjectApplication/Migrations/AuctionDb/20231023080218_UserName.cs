using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectApplication.Migrations.AuctionDb
{
    /// <inheritdoc />
    public partial class UserName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AuctionDBs",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "EndDateTime", "UserName" },
                values: new object[] { new DateTime(2023, 10, 23, 10, 2, 18, 65, DateTimeKind.Local).AddTicks(2475), "sabahaa@kth.se" });

            migrationBuilder.UpdateData(
                table: "BidDBs",
                keyColumn: "Id",
                keyValue: -2,
                column: "TimePlaced",
                value: new DateTime(2023, 10, 23, 10, 2, 18, 65, DateTimeKind.Local).AddTicks(2665));

            migrationBuilder.UpdateData(
                table: "BidDBs",
                keyColumn: "Id",
                keyValue: -1,
                column: "TimePlaced",
                value: new DateTime(2023, 10, 23, 10, 2, 18, 65, DateTimeKind.Local).AddTicks(2661));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AuctionDBs",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "EndDateTime", "UserName" },
                values: new object[] { new DateTime(2023, 10, 23, 9, 38, 27, 213, DateTimeKind.Local).AddTicks(5941), "user@kth.se" });

            migrationBuilder.UpdateData(
                table: "BidDBs",
                keyColumn: "Id",
                keyValue: -2,
                column: "TimePlaced",
                value: new DateTime(2023, 10, 23, 9, 38, 27, 213, DateTimeKind.Local).AddTicks(6112));

            migrationBuilder.UpdateData(
                table: "BidDBs",
                keyColumn: "Id",
                keyValue: -1,
                column: "TimePlaced",
                value: new DateTime(2023, 10, 23, 9, 38, 27, 213, DateTimeKind.Local).AddTicks(6109));
        }
    }
}
