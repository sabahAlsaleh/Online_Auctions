using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjectApplication.Migrations.AuctionDb
{
    /// <inheritdoc />
    public partial class AuctionDB_UserName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuctionDBs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Auctioneer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartingPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionDBs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BidDBs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bidder = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TimePlaced = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuctionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BidDBs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BidDBs_AuctionDBs_AuctionId",
                        column: x => x.AuctionId,
                        principalTable: "AuctionDBs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AuctionDBs",
                columns: new[] { "Id", "Auctioneer", "Description", "EndDateTime", "Name", "StartingPrice", "UserName" },
                values: new object[] { -1, "Auctioneer 1", "Description 1", new DateTime(2023, 10, 23, 9, 38, 27, 213, DateTimeKind.Local).AddTicks(5941), "Auction And Bids plasce", 100m, "user@kth.se" });

            migrationBuilder.InsertData(
                table: "BidDBs",
                columns: new[] { "Id", "Amount", "AuctionId", "Bidder", "TimePlaced" },
                values: new object[,]
                {
                    { -2, 200m, -1, "Bidder 2", new DateTime(2023, 10, 23, 9, 38, 27, 213, DateTimeKind.Local).AddTicks(6112) },
                    { -1, 150m, -1, "Bidder1 ", new DateTime(2023, 10, 23, 9, 38, 27, 213, DateTimeKind.Local).AddTicks(6109) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BidDBs_AuctionId",
                table: "BidDBs",
                column: "AuctionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BidDBs");

            migrationBuilder.DropTable(
                name: "AuctionDBs");
        }
    }
}
