using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Graveyard_Backend.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "burried",
                columns: table => new
                {
                    id_z = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    lastname = table.Column<string>(type: "text", nullable: false),
                    date_of_birth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    date_of_death = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_burried", x => x.id_z);
                });

            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    Id_c = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Date_of_creation = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Password = table.Column<byte[]>(type: "bytea", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.Id_c);
                });

            migrationBuilder.CreateTable(
                name: "shop",
                columns: table => new
                {
                    id_i = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    kind = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shop", x => x.id_i);
                });

            migrationBuilder.CreateTable(
                name: "burials",
                columns: table => new
                {
                    id_b = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    burial_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    burriedid_z = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_burials", x => x.id_b);
                    table.ForeignKey(
                        name: "FK_burials_burried_burriedid_z",
                        column: x => x.burriedid_z,
                        principalTable: "burried",
                        principalColumn: "id_z",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "grave",
                columns: table => new
                {
                    id_g = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    x = table.Column<int>(type: "integer", nullable: false),
                    y = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false),
                    burriedid_z = table.Column<int>(type: "integer", nullable: false),
                    validUntil = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    customerId_c = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grave", x => x.id_g);
                    table.ForeignKey(
                        name: "FK_grave_burried_burriedid_z",
                        column: x => x.burriedid_z,
                        principalTable: "burried",
                        principalColumn: "id_z",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_grave_customer_customerId_c",
                        column: x => x.customerId_c,
                        principalTable: "customer",
                        principalColumn: "Id_c",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "owned_Roles",
                columns: table => new
                {
                    CustomerId_c = table.Column<int>(type: "integer", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_owned_Roles_customer_CustomerId_c",
                        column: x => x.CustomerId_c,
                        principalTable: "customer",
                        principalColumn: "Id_c",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "shopHistory",
                columns: table => new
                {
                    customerId_c = table.Column<int>(type: "integer", nullable: false),
                    Shopid_i = table.Column<int>(type: "integer", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    date_of_sell = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_shopHistory_customer_customerId_c",
                        column: x => x.customerId_c,
                        principalTable: "customer",
                        principalColumn: "Id_c",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_shopHistory_shop_Shopid_i",
                        column: x => x.Shopid_i,
                        principalTable: "shop",
                        principalColumn: "id_i",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "shopList",
                columns: table => new
                {
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false),
                    date_of_sell = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    customerId_c = table.Column<int>(type: "integer", nullable: false),
                    shopid_i = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_shopList_customer_customerId_c",
                        column: x => x.customerId_c,
                        principalTable: "customer",
                        principalColumn: "Id_c",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_shopList_shop_shopid_i",
                        column: x => x.shopid_i,
                        principalTable: "shop",
                        principalColumn: "id_i",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ownedGraves",
                columns: table => new
                {
                    customerId_c = table.Column<int>(type: "integer", nullable: false),
                    graveid_g = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_ownedGraves_customer_customerId_c",
                        column: x => x.customerId_c,
                        principalTable: "customer",
                        principalColumn: "Id_c",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ownedGraves_grave_graveid_g",
                        column: x => x.graveid_g,
                        principalTable: "grave",
                        principalColumn: "id_g",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_burials_burriedid_z",
                table: "burials",
                column: "burriedid_z");

            migrationBuilder.CreateIndex(
                name: "IX_grave_burriedid_z",
                table: "grave",
                column: "burriedid_z");

            migrationBuilder.CreateIndex(
                name: "IX_grave_customerId_c",
                table: "grave",
                column: "customerId_c");

            migrationBuilder.CreateIndex(
                name: "IX_owned_Roles_CustomerId_c",
                table: "owned_Roles",
                column: "CustomerId_c");

            migrationBuilder.CreateIndex(
                name: "IX_ownedGraves_customerId_c",
                table: "ownedGraves",
                column: "customerId_c");

            migrationBuilder.CreateIndex(
                name: "IX_ownedGraves_graveid_g",
                table: "ownedGraves",
                column: "graveid_g");

            migrationBuilder.CreateIndex(
                name: "IX_shopHistory_customerId_c",
                table: "shopHistory",
                column: "customerId_c");

            migrationBuilder.CreateIndex(
                name: "IX_shopHistory_Shopid_i",
                table: "shopHistory",
                column: "Shopid_i");

            migrationBuilder.CreateIndex(
                name: "IX_shopList_customerId_c",
                table: "shopList",
                column: "customerId_c");

            migrationBuilder.CreateIndex(
                name: "IX_shopList_shopid_i",
                table: "shopList",
                column: "shopid_i");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "burials");

            migrationBuilder.DropTable(
                name: "owned_Roles");

            migrationBuilder.DropTable(
                name: "ownedGraves");

            migrationBuilder.DropTable(
                name: "shopHistory");

            migrationBuilder.DropTable(
                name: "shopList");

            migrationBuilder.DropTable(
                name: "grave");

            migrationBuilder.DropTable(
                name: "shop");

            migrationBuilder.DropTable(
                name: "burried");

            migrationBuilder.DropTable(
                name: "customer");
        }
    }
}
