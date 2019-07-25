using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConstructionCompanyDataLayer.Migrations
{
    public partial class EquipmentAmountToQuantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsageEnd",
                table: "WorksheetEquipment");

            migrationBuilder.DropColumn(
                name: "UsageStart",
                table: "WorksheetEquipment");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "WorksheetEquipment",
                newName: "Quantity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "WorksheetEquipment",
                newName: "Amount");

            migrationBuilder.AddColumn<DateTime>(
                name: "UsageEnd",
                table: "WorksheetEquipment",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UsageStart",
                table: "WorksheetEquipment",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
