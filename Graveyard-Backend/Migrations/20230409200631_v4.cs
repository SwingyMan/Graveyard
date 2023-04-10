using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Graveyard_Backend.Migrations
{
    /// <inheritdoc />
    public partial class v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "customer",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
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
        }
    }
}
