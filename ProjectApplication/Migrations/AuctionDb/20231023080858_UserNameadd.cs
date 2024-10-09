using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectApplication.Migrations.AuctionDb
{
    /// <inheritdoc />
    public partial class UserNameadd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AuctionDBs",
                keyColumn: "Id",
                keyValue: -1,
                column: "EndDateTime",
                value: new DateTime(2023, 10, 23, 10, 8, 58, 253, DateTimeKind.Local).AddTicks(6339));

            migrationBuilder.UpdateData(
                table: "BidDBs",
                keyColumn: "Id",
                keyValue: -2,
                column: "TimePlaced",
                value: new DateTime(2023, 10, 23, 10, 8, 58, 253, DateTimeKind.Local).AddTicks(6524));

            migrationBuilder.UpdateData(
                table: "BidDBs",
                keyColumn: "Id",
                keyValue: -1,
                column: "TimePlaced",
                value: new DateTime(2023, 10, 23, 10, 8, 58, 253, DateTimeKind.Local).AddTicks(6521));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AuctionDBs",
                keyColumn: "Id",
                keyValue: -1,
                column: "EndDateTime",
                value: new DateTime(2023, 10, 23, 10, 2, 18, 65, DateTimeKind.Local).AddTicks(2475));

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
    }
}
