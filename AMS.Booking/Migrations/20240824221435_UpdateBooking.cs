using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmsBooking.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfDays",
                table: "Booking");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Capacity",
                newName: "Id");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Booking",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Booking");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Capacity",
                newName: "id");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfDays",
                table: "Booking",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
