using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tirelire.Data.Migrations
{
    /// <inheritdoc />
    public partial class addEmailToOrderHeaderToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "OrderHeaders",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "OrderHeaders");
        }
    }
}
