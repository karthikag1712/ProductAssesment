using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductAssesment.Migrations
{
    /// <inheritdoc />
    public partial class StockAllocation1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockAllocation_Locations_LocationId",
                table: "StockAllocation");

            migrationBuilder.DropForeignKey(
                name: "FK_StockAllocation_Products_ProductId",
                table: "StockAllocation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StockAllocation",
                table: "StockAllocation");

            migrationBuilder.RenameTable(
                name: "StockAllocation",
                newName: "StockAllocations");

            migrationBuilder.RenameIndex(
                name: "IX_StockAllocation_ProductId",
                table: "StockAllocations",
                newName: "IX_StockAllocations_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_StockAllocation_LocationId",
                table: "StockAllocations",
                newName: "IX_StockAllocations_LocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StockAllocations",
                table: "StockAllocations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StockAllocations_Locations_LocationId",
                table: "StockAllocations",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockAllocations_Products_ProductId",
                table: "StockAllocations",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockAllocations_Locations_LocationId",
                table: "StockAllocations");

            migrationBuilder.DropForeignKey(
                name: "FK_StockAllocations_Products_ProductId",
                table: "StockAllocations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StockAllocations",
                table: "StockAllocations");

            migrationBuilder.RenameTable(
                name: "StockAllocations",
                newName: "StockAllocation");

            migrationBuilder.RenameIndex(
                name: "IX_StockAllocations_ProductId",
                table: "StockAllocation",
                newName: "IX_StockAllocation_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_StockAllocations_LocationId",
                table: "StockAllocation",
                newName: "IX_StockAllocation_LocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StockAllocation",
                table: "StockAllocation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StockAllocation_Locations_LocationId",
                table: "StockAllocation",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockAllocation_Products_ProductId",
                table: "StockAllocation",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
