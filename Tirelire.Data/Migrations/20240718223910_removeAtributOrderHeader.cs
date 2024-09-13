using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tirelire.Data.Migrations
{
    /// <inheritdoc />
    public partial class removeAtributOrderHeader : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adresse",
                table: "OrderHeaders");

            migrationBuilder.DropColumn(
                name: "CodePostal",
                table: "OrderHeaders");

            migrationBuilder.DropColumn(
                name: "Pays",
                table: "OrderHeaders");

            migrationBuilder.DropColumn(
                name: "Tel",
                table: "OrderHeaders");

            migrationBuilder.DropColumn(
                name: "Ville",
                table: "OrderHeaders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Adresse",
                table: "OrderHeaders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CodePostal",
                table: "OrderHeaders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Pays",
                table: "OrderHeaders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tel",
                table: "OrderHeaders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Ville",
                table: "OrderHeaders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
