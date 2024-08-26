using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmsBooking.Migrations
{
    /// <inheritdoc />
    public partial class Final : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quartos",
                table: "Chalet",
                newName: "Benefícios");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Benefícios",
                table: "Chalet",
                newName: "Quartos");
        }
    }
}
