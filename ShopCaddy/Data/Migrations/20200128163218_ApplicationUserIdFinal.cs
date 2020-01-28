using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopCaddy.Data.Migrations
{
    public partial class ApplicationUserIdFinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_ApplicationUserId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderProducts_AspNetUsers_ApplicationUserId",
                table: "PurchaseOrderProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrders_AspNetUsers_ApplicationUserId",
                table: "PurchaseOrders");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseOrders_ApplicationUserId",
                table: "PurchaseOrders");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseOrderProducts_ApplicationUserId",
                table: "PurchaseOrderProducts");

            migrationBuilder.DropIndex(
                name: "IX_Products_ApplicationUserId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "PurchaseOrders",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "PurchaseOrders",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "PurchaseOrderProducts",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "PurchaseOrderProducts",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "Products",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_ApplicationUserId1",
                table: "PurchaseOrders",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderProducts_ApplicationUserId1",
                table: "PurchaseOrderProducts",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ApplicationUserId1",
                table: "Products",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_ApplicationUserId1",
                table: "Products",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderProducts_AspNetUsers_ApplicationUserId1",
                table: "PurchaseOrderProducts",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrders_AspNetUsers_ApplicationUserId1",
                table: "PurchaseOrders",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_ApplicationUserId1",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderProducts_AspNetUsers_ApplicationUserId1",
                table: "PurchaseOrderProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrders_AspNetUsers_ApplicationUserId1",
                table: "PurchaseOrders");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseOrders_ApplicationUserId1",
                table: "PurchaseOrders");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseOrderProducts_ApplicationUserId1",
                table: "PurchaseOrderProducts");

            migrationBuilder.DropIndex(
                name: "IX_Products_ApplicationUserId1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "PurchaseOrderProducts");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "PurchaseOrders",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "PurchaseOrderProducts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Products",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_ApplicationUserId",
                table: "PurchaseOrders",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderProducts_ApplicationUserId",
                table: "PurchaseOrderProducts",
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
        }
    }
}
