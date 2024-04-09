using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductAssesment.Migrations
{
    /// <inheritdoc />
    public partial class StockAllocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StockAllocation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AllocatedQty = table.Column<decimal>(type: "TEXT", nullable: false),
                    AllocatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ProductId = table.Column<long>(type: "INTEGER", nullable: false),
                    LocationId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockAllocation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockAllocation_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockAllocation_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StockAllocation_LocationId",
                table: "StockAllocation",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_StockAllocation_ProductId",
                table: "StockAllocation",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockAllocation");
        }
    }
}
