using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restful_API.Migrations
{
    public partial class updateStudentforeignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Student",
                newName: "StatusId");

            migrationBuilder.RenameColumn(
                name: "CurrentSection",
                table: "Student",
                newName: "CurrentSectionId");

            migrationBuilder.RenameColumn(
                name: "CurrentClass",
                table: "Student",
                newName: "CurrentClassId");

            migrationBuilder.RenameColumn(
                name: "AdmissionInSection",
                table: "Student",
                newName: "AdmissionInSectionId");

            migrationBuilder.RenameColumn(
                name: "AdmissionInClass",
                table: "Student",
                newName: "AdmissionInClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_AdmissionInClassId",
                table: "Student",
                column: "AdmissionInClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_AdmissionInSectionId",
                table: "Student",
                column: "AdmissionInSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_CategoryId",
                table: "Student",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_CurrentClassId",
                table: "Student",
                column: "CurrentClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_CurrentSectionId",
                table: "Student",
                column: "CurrentSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_ReligionId",
                table: "Student",
                column: "ReligionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Category_CategoryId",
                table: "Student",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Class_AdmissionInClassId",
                table: "Student",
                column: "AdmissionInClassId",
                principalTable: "Class",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Class_CurrentClassId",
                table: "Student",
                column: "CurrentClassId",
                principalTable: "Class",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Religion_ReligionId",
                table: "Student",
                column: "ReligionId",
                principalTable: "Religion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Section_AdmissionInSectionId",
                table: "Student",
                column: "AdmissionInSectionId",
                principalTable: "Section",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Section_CurrentSectionId",
                table: "Student",
                column: "CurrentSectionId",
                principalTable: "Section",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Category_CategoryId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Class_AdmissionInClassId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Class_CurrentClassId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Religion_ReligionId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Section_AdmissionInSectionId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Section_CurrentSectionId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_AdmissionInClassId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_AdmissionInSectionId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_CategoryId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_CurrentClassId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_CurrentSectionId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_ReligionId",
                table: "Student");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "Student",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "CurrentSectionId",
                table: "Student",
                newName: "CurrentSection");

            migrationBuilder.RenameColumn(
                name: "CurrentClassId",
                table: "Student",
                newName: "CurrentClass");

            migrationBuilder.RenameColumn(
                name: "AdmissionInSectionId",
                table: "Student",
                newName: "AdmissionInSection");

            migrationBuilder.RenameColumn(
                name: "AdmissionInClassId",
                table: "Student",
                newName: "AdmissionInClass");
        }
    }
}
