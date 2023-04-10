using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Graveyard_Backend.Migrations
{
    /// <inheritdoc />
    public partial class v6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_grave_customer_CustomerId",
                table: "grave");

            migrationBuilder.DropForeignKey(
                name: "FK_ownedGraves_customer_CustomerId",
                table: "ownedGraves");

            migrationBuilder.DropForeignKey(
                name: "FK_shopHistory_customer_CustomerId",
                table: "shopHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_shopList_customer_CustomerId",
                table: "shopList");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "shopList",
                newName: "CustomerID");

            migrationBuilder.RenameIndex(
                name: "IX_shopList_CustomerId",
                table: "shopList",
                newName: "IX_shopList_CustomerID");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "shopHistory",
                newName: "CustomerID");

            migrationBuilder.RenameIndex(
                name: "IX_shopHistory_CustomerId",
                table: "shopHistory",
                newName: "IX_shopHistory_CustomerID");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "ownedGraves",
                newName: "CustomerID");

            migrationBuilder.RenameIndex(
                name: "IX_ownedGraves_CustomerId",
                table: "ownedGraves",
                newName: "IX_ownedGraves_CustomerID");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "grave",
                newName: "CustomerID");

            migrationBuilder.RenameIndex(
                name: "IX_grave_CustomerId",
                table: "grave",
                newName: "IX_grave_CustomerID");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "customer",
                newName: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_grave_customer_CustomerID",
                table: "grave",
                column: "CustomerID",
                principalTable: "customer",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ownedGraves_customer_CustomerID",
                table: "ownedGraves",
                column: "CustomerID",
                principalTable: "customer",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_shopHistory_customer_CustomerID",
                table: "shopHistory",
                column: "CustomerID",
                principalTable: "customer",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_shopList_customer_CustomerID",
                table: "shopList",
                column: "CustomerID",
                principalTable: "customer",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_grave_customer_CustomerID",
                table: "grave");

            migrationBuilder.DropForeignKey(
                name: "FK_ownedGraves_customer_CustomerID",
                table: "ownedGraves");

            migrationBuilder.DropForeignKey(
                name: "FK_shopHistory_customer_CustomerID",
                table: "shopHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_shopList_customer_CustomerID",
                table: "shopList");

            migrationBuilder.RenameColumn(
                name: "CustomerID",
                table: "shopList",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_shopList_CustomerID",
                table: "shopList",
                newName: "IX_shopList_CustomerId");

            migrationBuilder.RenameColumn(
                name: "CustomerID",
                table: "shopHistory",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_shopHistory_CustomerID",
                table: "shopHistory",
                newName: "IX_shopHistory_CustomerId");

            migrationBuilder.RenameColumn(
                name: "CustomerID",
                table: "ownedGraves",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_ownedGraves_CustomerID",
                table: "ownedGraves",
                newName: "IX_ownedGraves_CustomerId");

            migrationBuilder.RenameColumn(
                name: "CustomerID",
                table: "grave",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_grave_CustomerID",
                table: "grave",
                newName: "IX_grave_CustomerId");

            migrationBuilder.RenameColumn(
                name: "CustomerID",
                table: "customer",
                newName: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_grave_customer_CustomerId",
                table: "grave",
                column: "CustomerId",
                principalTable: "customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ownedGraves_customer_CustomerId",
                table: "ownedGraves",
                column: "CustomerId",
                principalTable: "customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_shopHistory_customer_CustomerId",
                table: "shopHistory",
                column: "CustomerId",
                principalTable: "customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_shopList_customer_CustomerId",
                table: "shopList",
                column: "CustomerId",
                principalTable: "customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
