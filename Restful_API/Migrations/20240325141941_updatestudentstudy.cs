using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restful_API.Migrations
{
    public partial class updatestudentstudy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Class_CurrentClassId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Student");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Class_CurrentClassId",
                table: "Student",
                column: "CurrentClassId",
                principalTable: "Class",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Class_CurrentClassId",
                table: "Student");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Class_CurrentClassId",
                table: "Student",
                column: "CurrentClassId",
                principalTable: "Class",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
