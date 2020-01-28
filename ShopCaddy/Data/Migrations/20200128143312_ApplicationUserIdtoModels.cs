using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopCaddy.Data.Migrations
{
    public partial class ApplicationUserIdtoModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Vendors",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "PurchaseOrders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "PurchaseOrderProducts",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "ProductTypes",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_ApplicationUserId",
                table: "Vendors",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_ApplicationUserId",
                table: "PurchaseOrders",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderProducts_ApplicationUserId",
                table: "PurchaseOrderProducts",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypes_ApplicationUserId",
                table: "ProductTypes",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ApplicationUserId",
                table: "Products",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_ApplicationUserId",
                table: "Products",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTypes_AspNetUsers_ApplicationUserId",
                table: "ProductTypes",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderProducts_AspNetUsers_ApplicationUserId",
                table: "PurchaseOrderProducts",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrders_AspNetUsers_ApplicationUserId",
                table: "PurchaseOrders",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendors_AspNetUsers_ApplicationUserId",
                table: "Vendors",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_ApplicationUserId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTypes_AspNetUsers_ApplicationUserId",
                table: "ProductTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderProducts_AspNetUsers_ApplicationUserId",
                table: "PurchaseOrderProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrders_AspNetUsers_ApplicationUserId",
                table: "PurchaseOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendors_AspNetUsers_ApplicationUserId",
                table: "Vendors");

            migrationBuilder.DropIndex(
                name: "IX_Vendors_ApplicationUserId",
                table: "Vendors");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseOrders_ApplicationUserId",
                table: "PurchaseOrders");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseOrderProducts_ApplicationUserId",
                table: "PurchaseOrderProducts");

            migrationBuilder.DropIndex(
                name: "IX_ProductTypes_ApplicationUserId",
                table: "ProductTypes");

            migrationBuilder.DropIndex(
                name: "IX_Products_ApplicationUserId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "PurchaseOrderProducts");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Vendors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "ProductTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
