using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restful_API.Migrations
{
    public partial class updateStudentEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Category_CategoryId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Class_ClassesId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Gender_GendersId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Religion_ReligionId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Section_SectionsId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_StudyStatus_StudyStatusId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_CategoryId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_ClassesId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_GendersId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_ReligionId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_SectionsId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_StudyStatusId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "ClassesId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "GendersId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "SectionsId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "StudyStatusId",
                table: "Student");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClassesId",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GendersId",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SectionsId",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudyStatusId",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Student_CategoryId",
                table: "Student",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_ClassesId",
                table: "Student",
                column: "ClassesId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_GendersId",
                table: "Student",
                column: "GendersId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_ReligionId",
                table: "Student",
                column: "ReligionId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_SectionsId",
                table: "Student",
                column: "SectionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_StudyStatusId",
                table: "Student",
                column: "StudyStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Category_CategoryId",
                table: "Student",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Class_ClassesId",
                table: "Student",
                column: "ClassesId",
                principalTable: "Class",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Gender_GendersId",
                table: "Student",
                column: "GendersId",
                principalTable: "Gender",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Religion_ReligionId",
                table: "Student",
                column: "ReligionId",
                principalTable: "Religion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Section_SectionsId",
                table: "Student",
                column: "SectionsId",
                principalTable: "Section",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_StudyStatus_StudyStatusId",
                table: "Student",
                column: "StudyStatusId",
                principalTable: "StudyStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
