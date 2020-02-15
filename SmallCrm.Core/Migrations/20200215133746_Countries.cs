using Microsoft.EntityFrameworkCore.Migrations;

namespace SmallCrm.Core.Migrations
{
    public partial class Countries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Customer_customerId",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "customerId",
                table: "Order",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_customerId",
                table: "Order",
                newName: "IX_Order_CustomerId");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Customer_CustomerId",
                table: "Order",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Customer_CustomerId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Customer");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Order",
                newName: "customerId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                newName: "IX_Order_customerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Customer_customerId",
                table: "Order",
                column: "customerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
