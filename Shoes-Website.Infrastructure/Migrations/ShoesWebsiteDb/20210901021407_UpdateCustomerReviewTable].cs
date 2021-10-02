using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shoes_Website.Infrastructure.Migrations.ShoesWebsiteDb
{
    public partial class UpdateCustomerReviewTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "CustomerReviews",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "CustomerReviews");
        }
    }
}
