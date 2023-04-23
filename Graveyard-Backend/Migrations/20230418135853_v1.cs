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
                    BurriedID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    lastname = table.Column<string>(type: "text", nullable: false),
                    date_of_birth = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    date_of_death = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_burried", x => x.BurriedID);
                });

            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Date_of_creation = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Owned_role = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "burials",
                columns: table => new
                {
                    ToBeBurriedID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    burial_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    BurriedID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_burials", x => x.ToBeBurriedID);
                    table.ForeignKey(
                        name: "FK_burials_burried_BurriedID",
                        column: x => x.BurriedID,
                        principalTable: "burried",
                        principalColumn: "BurriedID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "grave",
                columns: table => new
                {
                    GraveID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    x = table.Column<int>(type: "integer", nullable: false),
                    y = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false),
                    BurriedID = table.Column<int>(type: "integer", nullable: false),
                    validUntil = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grave", x => x.GraveID);
                    table.ForeignKey(
                        name: "FK_grave_burried_BurriedID",
                        column: x => x.BurriedID,
                        principalTable: "burried",
                        principalColumn: "BurriedID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "carts",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carts", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_carts_customer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "customer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "shopHistory",
                columns: table => new
                {
                    shopHistoryID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerID = table.Column<int>(type: "integer", nullable: false),
                    date_of_buyment = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shopHistory", x => x.shopHistoryID);
                    table.ForeignKey(
                        name: "FK_shopHistory_customer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "customer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "shop",
                columns: table => new
                {
                    ItemID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    kind = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    shopHistoryID = table.Column<int>(type: "integer", nullable: false),
                    CartId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shop", x => x.ItemID);
                    table.ForeignKey(
                        name: "FK_shop_carts_CartId",
                        column: x => x.CartId,
                        principalTable: "carts",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_shop_shopHistory_shopHistoryID",
                        column: x => x.shopHistoryID,
                        principalTable: "shopHistory",
                        principalColumn: "shopHistoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_burials_BurriedID",
                table: "burials",
                column: "BurriedID");

            migrationBuilder.CreateIndex(
                name: "IX_carts_CustomerID",
                table: "carts",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_grave_BurriedID",
                table: "grave",
                column: "BurriedID");

            migrationBuilder.CreateIndex(
                name: "IX_shop_CartId",
                table: "shop",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_shop_shopHistoryID",
                table: "shop",
                column: "shopHistoryID");

            migrationBuilder.CreateIndex(
                name: "IX_shopHistory_CustomerID",
                table: "shopHistory",
                column: "CustomerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "burials");

            migrationBuilder.DropTable(
                name: "grave");

            migrationBuilder.DropTable(
                name: "shop");

            migrationBuilder.DropTable(
                name: "burried");

            migrationBuilder.DropTable(
                name: "carts");

            migrationBuilder.DropTable(
                name: "shopHistory");

            migrationBuilder.DropTable(
                name: "customer");
        }
    }
}
