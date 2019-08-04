using Microsoft.EntityFrameworkCore.Migrations;

namespace ConstructionCompanyDataLayer.Migrations
{
    public partial class TaskRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Tasks",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Tasks");
        }
    }
}
