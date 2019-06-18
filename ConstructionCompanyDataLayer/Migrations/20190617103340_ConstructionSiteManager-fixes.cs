using Microsoft.EntityFrameworkCore.Migrations;

namespace ConstructionCompanyDataLayer.Migrations
{
    public partial class ConstructionSiteManagerfixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConstructionSiteManagers_User_UserId1",
                table: "ConstructionSiteManagers");

            migrationBuilder.DropIndex(
                name: "IX_ConstructionSiteManagers_UserId1",
                table: "ConstructionSiteManagers");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "ConstructionSiteManagers");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ConstructionSiteManagers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConstructionSiteManagers_UserId",
                table: "ConstructionSiteManagers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConstructionSiteManagers_User_UserId",
                table: "ConstructionSiteManagers",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConstructionSiteManagers_User_UserId",
                table: "ConstructionSiteManagers");

            migrationBuilder.DropIndex(
                name: "IX_ConstructionSiteManagers_UserId",
                table: "ConstructionSiteManagers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ConstructionSiteManagers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "ConstructionSiteManagers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConstructionSiteManagers_UserId1",
                table: "ConstructionSiteManagers",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ConstructionSiteManagers_User_UserId1",
                table: "ConstructionSiteManagers",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
