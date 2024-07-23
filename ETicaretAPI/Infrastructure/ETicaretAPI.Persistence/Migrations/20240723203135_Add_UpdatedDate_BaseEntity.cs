using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETicaretAPI.Persistence.Migrations
{
    public partial class Add_UpdatedDate_BaseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Created",
                table: "Products",
                newName: "Updateddate");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "Orders",
                newName: "Updateddate");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "Customers",
                newName: "Updateddate");

            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "Products",
                type: "real",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Customers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "Updateddate",
                table: "Products",
                newName: "Created");

            migrationBuilder.RenameColumn(
                name: "Updateddate",
                table: "Orders",
                newName: "Created");

            migrationBuilder.RenameColumn(
                name: "Updateddate",
                table: "Customers",
                newName: "Created");

            migrationBuilder.AlterColumn<long>(
                name: "Price",
                table: "Products",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }
    }
}
