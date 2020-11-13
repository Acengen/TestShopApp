using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppifiyAPI.Migrations
{
    public partial class AddingPriceAndDayInProductAndUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Day",
                table: "ProductAndUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "ProductAndUsers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Day",
                table: "ProductAndUsers");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "ProductAndUsers");
        }
    }
}
