using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shoes_Website.Infrastructure.Migrations.ShoesWebsiteDb
{
    public partial class UpdateProductModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Products",
                newName: "ImageExtension");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "Products",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ImageExtension",
                table: "Products",
                newName: "ImagePath");
        }
    }
}
