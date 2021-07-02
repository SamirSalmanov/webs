using Microsoft.EntityFrameworkCore.Migrations;

namespace Websuper.Data.Migrations
{
    public partial class ContactUs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Text",
                table: "ContactUs",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Icon",
                table: "ContactUs",
                newName: "Phone");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "ContactUs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "ContactUs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Map",
                table: "ContactUs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "ContactUs");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "ContactUs");

            migrationBuilder.DropColumn(
                name: "Map",
                table: "ContactUs");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "ContactUs",
                newName: "Text");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "ContactUs",
                newName: "Icon");
        }
    }
}
