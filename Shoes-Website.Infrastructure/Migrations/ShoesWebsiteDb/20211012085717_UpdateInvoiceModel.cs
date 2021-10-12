using Microsoft.EntityFrameworkCore.Migrations;

namespace Shoes_Website.Infrastructure.Migrations.ShoesWebsiteDb
{
    public partial class UpdateInvoiceModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderedAmount",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderedAmount",
                table: "Invoices");
        }
    }
}
