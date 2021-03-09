using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RrNetBack.DAL.Migrations
{
    public partial class AddTimestampsOnUsersTale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: "NOW()");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: "NOW()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Users");
        }
    }
}
