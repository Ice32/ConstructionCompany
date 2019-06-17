using Microsoft.EntityFrameworkCore.Migrations;

namespace ConstructionCompanyDataLayer.Migrations
{
    public partial class Constructionsitesaddedproperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConstructionSites_User_CreatedById",
                table: "ConstructionSites");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ConstructionSites",
                newName: "Address");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedById",
                table: "ConstructionSites",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ConstructionSites",
                type: "text",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ConstructionSites_User_CreatedById",
                table: "ConstructionSites",
                column: "CreatedById",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConstructionSites_User_CreatedById",
                table: "ConstructionSites");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ConstructionSites");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "ConstructionSites",
                newName: "UserId");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedById",
                table: "ConstructionSites",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ConstructionSites_User_CreatedById",
                table: "ConstructionSites",
                column: "CreatedById",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
