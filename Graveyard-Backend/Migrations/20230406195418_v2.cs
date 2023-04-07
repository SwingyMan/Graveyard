using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Graveyard_Backend.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "owned_Roles");

            migrationBuilder.AddColumn<string>(
                name: "Owned_role",
                table: "customer",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Owned_role",
                table: "customer");

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

            migrationBuilder.CreateIndex(
                name: "IX_owned_Roles_CustomerId_c",
                table: "owned_Roles",
                column: "CustomerId_c");
        }
    }
}
