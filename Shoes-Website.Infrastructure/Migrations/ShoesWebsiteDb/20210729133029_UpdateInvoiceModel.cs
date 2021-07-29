using Microsoft.EntityFrameworkCore.Migrations;

namespace Shoes_Website.Infrastructure.Migrations.ShoesWebsiteDb
{
    public partial class UpdateInvoiceModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_ProductOptions_ProductOptionsId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_ProductOptionsId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "productOptionId",
                table: "Invoices");

            migrationBuilder.AlterColumn<int>(
                name: "ProductOptionsId",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ProductOptionsId",
                table: "Invoices",
                column: "ProductOptionsId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_ProductOptions_ProductOptionsId",
                table: "Invoices",
                column: "ProductOptionsId",
                principalTable: "ProductOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_ProductOptions_ProductOptionsId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_ProductOptionsId",
                table: "Invoices");

            migrationBuilder.AlterColumn<int>(
                name: "ProductOptionsId",
                table: "Invoices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "productOptionId",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ProductOptionsId",
                table: "Invoices",
                column: "ProductOptionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_ProductOptions_ProductOptionsId",
                table: "Invoices",
                column: "ProductOptionsId",
                principalTable: "ProductOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
