using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restful_API.Migrations
{
    public partial class updateStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudyStatusId",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Student_StudyStatusId",
                table: "Student",
                column: "StudyStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_StudyStatus_StudyStatusId",
                table: "Student",
                column: "StudyStatusId",
                principalTable: "StudyStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_StudyStatus_StudyStatusId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_StudyStatusId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "StudyStatusId",
                table: "Student");
        }
    }
}
