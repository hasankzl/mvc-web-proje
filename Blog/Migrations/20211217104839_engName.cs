using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Migrations
{
    public partial class engName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EngName",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EngName",
                table: "Category");
        }
    }
}
