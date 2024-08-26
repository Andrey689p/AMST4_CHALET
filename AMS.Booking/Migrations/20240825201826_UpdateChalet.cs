using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmsBooking.Migrations
{
    /// <inheritdoc />
    public partial class UpdateChalet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Chalet",
                newName: "Quartos");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl1",
                table: "Chalet",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl2",
                table: "Chalet",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl3",
                table: "Chalet",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl4",
                table: "Chalet",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl1",
                table: "Chalet");

            migrationBuilder.DropColumn(
                name: "ImageUrl2",
                table: "Chalet");

            migrationBuilder.DropColumn(
                name: "ImageUrl3",
                table: "Chalet");

            migrationBuilder.DropColumn(
                name: "ImageUrl4",
                table: "Chalet");

            migrationBuilder.RenameColumn(
                name: "Quartos",
                table: "Chalet",
                newName: "ImageUrl");
        }
    }
}
