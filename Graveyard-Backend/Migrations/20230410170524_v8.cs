using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Graveyard_Backend.Migrations
{
    /// <inheritdoc />
    public partial class v8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_grave_customer_CustomerID",
                table: "grave");

            migrationBuilder.DropTable(
                name: "identityRoles");

            migrationBuilder.DropIndex(
                name: "IX_grave_CustomerID",
                table: "grave");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "grave");

            migrationBuilder.CreateTable(
                name: "graveOwner",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "integer", nullable: false),
                    GraveID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_graveOwner_customer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "customer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_graveOwner_grave_GraveID",
                        column: x => x.GraveID,
                        principalTable: "grave",
                        principalColumn: "GraveID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_graveOwner_CustomerID",
                table: "graveOwner",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_graveOwner_GraveID",
                table: "graveOwner",
                column: "GraveID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "graveOwner");

            migrationBuilder.AddColumn<int>(
                name: "CustomerID",
                table: "grave",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "identityRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    NormalizedName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_identityRoles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_grave_CustomerID",
                table: "grave",
                column: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_grave_customer_CustomerID",
                table: "grave",
                column: "CustomerID",
                principalTable: "customer",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
