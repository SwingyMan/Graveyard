using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Graveyard_Backend.Migrations
{
    /// <inheritdoc />
    public partial class v5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_burials_burried_burriedid_z",
                table: "burials");

            migrationBuilder.DropForeignKey(
                name: "FK_grave_burried_burriedid_z",
                table: "grave");

            migrationBuilder.DropForeignKey(
                name: "FK_grave_customer_customerId_c",
                table: "grave");

            migrationBuilder.DropForeignKey(
                name: "FK_ownedGraves_customer_customerId_c",
                table: "ownedGraves");

            migrationBuilder.DropForeignKey(
                name: "FK_ownedGraves_grave_graveid_g",
                table: "ownedGraves");

            migrationBuilder.DropForeignKey(
                name: "FK_shopHistory_customer_customerId_c",
                table: "shopHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_shopHistory_shop_Shopid_i",
                table: "shopHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_shopList_customer_customerId_c",
                table: "shopList");

            migrationBuilder.DropForeignKey(
                name: "FK_shopList_shop_shopid_i",
                table: "shopList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_customer",
                table: "customer");

            migrationBuilder.DropColumn(
                name: "Id_c",
                table: "customer");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "customer");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "customer");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "customer");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "customer");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "customer");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "customer");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "customer");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "customer");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "customer");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "customer");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "customer");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "customer");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "customer");

            migrationBuilder.RenameColumn(
                name: "shopid_i",
                table: "shopList",
                newName: "shopItemID");

            migrationBuilder.RenameColumn(
                name: "customerId_c",
                table: "shopList",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_shopList_shopid_i",
                table: "shopList",
                newName: "IX_shopList_shopItemID");

            migrationBuilder.RenameIndex(
                name: "IX_shopList_customerId_c",
                table: "shopList",
                newName: "IX_shopList_CustomerId");

            migrationBuilder.RenameColumn(
                name: "customerId_c",
                table: "shopHistory",
                newName: "ShopItemID");

            migrationBuilder.RenameColumn(
                name: "Shopid_i",
                table: "shopHistory",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_shopHistory_Shopid_i",
                table: "shopHistory",
                newName: "IX_shopHistory_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_shopHistory_customerId_c",
                table: "shopHistory",
                newName: "IX_shopHistory_ShopItemID");

            migrationBuilder.RenameColumn(
                name: "id_i",
                table: "shop",
                newName: "ItemID");

            migrationBuilder.RenameColumn(
                name: "graveid_g",
                table: "ownedGraves",
                newName: "GraveID");

            migrationBuilder.RenameColumn(
                name: "customerId_c",
                table: "ownedGraves",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_ownedGraves_graveid_g",
                table: "ownedGraves",
                newName: "IX_ownedGraves_GraveID");

            migrationBuilder.RenameIndex(
                name: "IX_ownedGraves_customerId_c",
                table: "ownedGraves",
                newName: "IX_ownedGraves_CustomerId");

            migrationBuilder.RenameColumn(
                name: "customerId_c",
                table: "grave",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "burriedid_z",
                table: "grave",
                newName: "BurriedID");

            migrationBuilder.RenameColumn(
                name: "id_g",
                table: "grave",
                newName: "GraveID");

            migrationBuilder.RenameIndex(
                name: "IX_grave_customerId_c",
                table: "grave",
                newName: "IX_grave_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_grave_burriedid_z",
                table: "grave",
                newName: "IX_grave_BurriedID");

            migrationBuilder.RenameColumn(
                name: "AccessFailedCount",
                table: "customer",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "id_z",
                table: "burried",
                newName: "BurriedID");

            migrationBuilder.RenameColumn(
                name: "burriedid_z",
                table: "burials",
                newName: "BurriedID");

            migrationBuilder.RenameColumn(
                name: "id_b",
                table: "burials",
                newName: "ToBeBurriedID");

            migrationBuilder.RenameIndex(
                name: "IX_burials_burriedid_z",
                table: "burials",
                newName: "IX_burials_BurriedID");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "customer",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_customer",
                table: "customer",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_burials_burried_BurriedID",
                table: "burials",
                column: "BurriedID",
                principalTable: "burried",
                principalColumn: "BurriedID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_grave_burried_BurriedID",
                table: "grave",
                column: "BurriedID",
                principalTable: "burried",
                principalColumn: "BurriedID",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_ownedGraves_grave_GraveID",
                table: "ownedGraves",
                column: "GraveID",
                principalTable: "grave",
                principalColumn: "GraveID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_shopHistory_customer_CustomerId",
                table: "shopHistory",
                column: "CustomerId",
                principalTable: "customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_shopHistory_shop_ShopItemID",
                table: "shopHistory",
                column: "ShopItemID",
                principalTable: "shop",
                principalColumn: "ItemID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_shopList_customer_CustomerId",
                table: "shopList",
                column: "CustomerId",
                principalTable: "customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_shopList_shop_shopItemID",
                table: "shopList",
                column: "shopItemID",
                principalTable: "shop",
                principalColumn: "ItemID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_burials_burried_BurriedID",
                table: "burials");

            migrationBuilder.DropForeignKey(
                name: "FK_grave_burried_BurriedID",
                table: "grave");

            migrationBuilder.DropForeignKey(
                name: "FK_grave_customer_CustomerId",
                table: "grave");

            migrationBuilder.DropForeignKey(
                name: "FK_ownedGraves_customer_CustomerId",
                table: "ownedGraves");

            migrationBuilder.DropForeignKey(
                name: "FK_ownedGraves_grave_GraveID",
                table: "ownedGraves");

            migrationBuilder.DropForeignKey(
                name: "FK_shopHistory_customer_CustomerId",
                table: "shopHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_shopHistory_shop_ShopItemID",
                table: "shopHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_shopList_customer_CustomerId",
                table: "shopList");

            migrationBuilder.DropForeignKey(
                name: "FK_shopList_shop_shopItemID",
                table: "shopList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_customer",
                table: "customer");

            migrationBuilder.RenameColumn(
                name: "shopItemID",
                table: "shopList",
                newName: "shopid_i");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "shopList",
                newName: "customerId_c");

            migrationBuilder.RenameIndex(
                name: "IX_shopList_shopItemID",
                table: "shopList",
                newName: "IX_shopList_shopid_i");

            migrationBuilder.RenameIndex(
                name: "IX_shopList_CustomerId",
                table: "shopList",
                newName: "IX_shopList_customerId_c");

            migrationBuilder.RenameColumn(
                name: "ShopItemID",
                table: "shopHistory",
                newName: "customerId_c");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "shopHistory",
                newName: "Shopid_i");

            migrationBuilder.RenameIndex(
                name: "IX_shopHistory_ShopItemID",
                table: "shopHistory",
                newName: "IX_shopHistory_customerId_c");

            migrationBuilder.RenameIndex(
                name: "IX_shopHistory_CustomerId",
                table: "shopHistory",
                newName: "IX_shopHistory_Shopid_i");

            migrationBuilder.RenameColumn(
                name: "ItemID",
                table: "shop",
                newName: "id_i");

            migrationBuilder.RenameColumn(
                name: "GraveID",
                table: "ownedGraves",
                newName: "graveid_g");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "ownedGraves",
                newName: "customerId_c");

            migrationBuilder.RenameIndex(
                name: "IX_ownedGraves_GraveID",
                table: "ownedGraves",
                newName: "IX_ownedGraves_graveid_g");

            migrationBuilder.RenameIndex(
                name: "IX_ownedGraves_CustomerId",
                table: "ownedGraves",
                newName: "IX_ownedGraves_customerId_c");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "grave",
                newName: "customerId_c");

            migrationBuilder.RenameColumn(
                name: "BurriedID",
                table: "grave",
                newName: "burriedid_z");

            migrationBuilder.RenameColumn(
                name: "GraveID",
                table: "grave",
                newName: "id_g");

            migrationBuilder.RenameIndex(
                name: "IX_grave_CustomerId",
                table: "grave",
                newName: "IX_grave_customerId_c");

            migrationBuilder.RenameIndex(
                name: "IX_grave_BurriedID",
                table: "grave",
                newName: "IX_grave_burriedid_z");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "customer",
                newName: "AccessFailedCount");

            migrationBuilder.RenameColumn(
                name: "BurriedID",
                table: "burried",
                newName: "id_z");

            migrationBuilder.RenameColumn(
                name: "BurriedID",
                table: "burials",
                newName: "burriedid_z");

            migrationBuilder.RenameColumn(
                name: "ToBeBurriedID",
                table: "burials",
                newName: "id_b");

            migrationBuilder.RenameIndex(
                name: "IX_burials_BurriedID",
                table: "burials",
                newName: "IX_burials_burriedid_z");

            migrationBuilder.AlterColumn<int>(
                name: "AccessFailedCount",
                table: "customer",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "Id_c",
                table: "customer",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "customer",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "customer",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "customer",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "customer",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "customer",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "customer",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "customer",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "customer",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "customer",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "customer",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "customer",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "customer",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "customer",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_customer",
                table: "customer",
                column: "Id_c");

            migrationBuilder.AddForeignKey(
                name: "FK_burials_burried_burriedid_z",
                table: "burials",
                column: "burriedid_z",
                principalTable: "burried",
                principalColumn: "id_z",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_grave_burried_burriedid_z",
                table: "grave",
                column: "burriedid_z",
                principalTable: "burried",
                principalColumn: "id_z",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_grave_customer_customerId_c",
                table: "grave",
                column: "customerId_c",
                principalTable: "customer",
                principalColumn: "Id_c",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ownedGraves_customer_customerId_c",
                table: "ownedGraves",
                column: "customerId_c",
                principalTable: "customer",
                principalColumn: "Id_c",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ownedGraves_grave_graveid_g",
                table: "ownedGraves",
                column: "graveid_g",
                principalTable: "grave",
                principalColumn: "id_g",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_shopHistory_customer_customerId_c",
                table: "shopHistory",
                column: "customerId_c",
                principalTable: "customer",
                principalColumn: "Id_c",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_shopHistory_shop_Shopid_i",
                table: "shopHistory",
                column: "Shopid_i",
                principalTable: "shop",
                principalColumn: "id_i",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_shopList_customer_customerId_c",
                table: "shopList",
                column: "customerId_c",
                principalTable: "customer",
                principalColumn: "Id_c",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_shopList_shop_shopid_i",
                table: "shopList",
                column: "shopid_i",
                principalTable: "shop",
                principalColumn: "id_i",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
