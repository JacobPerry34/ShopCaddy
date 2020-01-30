using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopCaddy.Data.Migrations
{
    public partial class POProductToPO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderProducts_PurchaseOrders_PurchaseOrderId",
                table: "PurchaseOrderProducts");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseOrderProducts_PurchaseOrderId",
                table: "PurchaseOrderProducts");

            migrationBuilder.AddColumn<int>(
                name: "PurchaseOrderProductId",
                table: "PurchaseOrders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PurchaseOrderProductId1",
                table: "PurchaseOrders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_PurchaseOrderProductId1",
                table: "PurchaseOrders",
                column: "PurchaseOrderProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderProducts_PurchaseOrderId",
                table: "PurchaseOrderProducts",
                column: "PurchaseOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderProducts_PurchaseOrders_PurchaseOrderId",
                table: "PurchaseOrderProducts",
                column: "PurchaseOrderId",
                principalTable: "PurchaseOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrders_PurchaseOrderProducts_PurchaseOrderProductId1",
                table: "PurchaseOrders",
                column: "PurchaseOrderProductId1",
                principalTable: "PurchaseOrderProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderProducts_PurchaseOrders_PurchaseOrderId",
                table: "PurchaseOrderProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrders_PurchaseOrderProducts_PurchaseOrderProductId1",
                table: "PurchaseOrders");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseOrders_PurchaseOrderProductId1",
                table: "PurchaseOrders");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseOrderProducts_PurchaseOrderId",
                table: "PurchaseOrderProducts");

            migrationBuilder.DropColumn(
                name: "PurchaseOrderProductId",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "PurchaseOrderProductId1",
                table: "PurchaseOrders");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderProducts_PurchaseOrderId",
                table: "PurchaseOrderProducts",
                column: "PurchaseOrderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderProducts_PurchaseOrders_PurchaseOrderId",
                table: "PurchaseOrderProducts",
                column: "PurchaseOrderId",
                principalTable: "PurchaseOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
