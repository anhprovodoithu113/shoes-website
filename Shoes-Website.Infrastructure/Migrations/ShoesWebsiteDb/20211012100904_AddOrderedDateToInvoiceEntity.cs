using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shoes_Website.Infrastructure.Migrations.ShoesWebsiteDb
{
    public partial class AddOrderedDateToInvoiceEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "OrderedDate",
                table: "Invoices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderedDate",
                table: "Invoices");
        }
    }
}
