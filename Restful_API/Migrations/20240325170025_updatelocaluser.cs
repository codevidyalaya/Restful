using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restful_API.Migrations
{
    public partial class updatelocaluser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "LocalUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "LocalUser",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
