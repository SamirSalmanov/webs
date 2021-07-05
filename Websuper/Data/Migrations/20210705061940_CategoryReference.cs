using Microsoft.EntityFrameworkCore.Migrations;

namespace Websuper.Data.Migrations
{
    public partial class CategoryReference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Galleries_Categories_CategoryID",
                table: "Galleries");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "Galleries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Galleries_Categories_CategoryID",
                table: "Galleries",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Galleries_Categories_CategoryID",
                table: "Galleries");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "Galleries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Galleries_Categories_CategoryID",
                table: "Galleries",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
