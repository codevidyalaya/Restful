using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restful_API.Migrations
{
    public partial class updateStudentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentName",
                table: "Student",
                newName: "StudentCode");

            migrationBuilder.AddColumn<string>(
                name: "AadharNumber",
                table: "Student",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "AdmissionDate",
                table: "Student",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "AdmissionInClass",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AdmissionInSection",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AdmissionNumber",
                table: "Student",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BloodGroup",
                table: "Student",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClassesId",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CurrentClass",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CurrentSection",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Student",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EmergencyContactNumber",
                table: "Student",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FatherName",
                table: "Student",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Student",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Student",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Gender",
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

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Student",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "Student",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MotherName",
                table: "Student",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProfileImage",
                table: "Student",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ReligionId",
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
                name: "Status",
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

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Religion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Religion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Section",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Section", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudyStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyStatus", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreatedDate", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, null, null, "General" },
                    { 2, null, null, "SC" },
                    { 3, null, null, "ST" },
                    { 4, null, null, "OBC" },
                    { 5, null, null, "Others" }
                });

            migrationBuilder.InsertData(
                table: "Class",
                columns: new[] { "Id", "CreatedDate", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, null, null, "Daycare" },
                    { 2, null, null, "Playgroup" },
                    { 3, null, null, "Nursery" },
                    { 4, null, null, "LKG" },
                    { 5, null, null, "UKG" }
                });

            migrationBuilder.InsertData(
                table: "Gender",
                columns: new[] { "Id", "CreatedDate", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, null, null, "Male" },
                    { 2, null, null, "Female" }
                });

            migrationBuilder.InsertData(
                table: "Religion",
                columns: new[] { "Id", "CreatedDate", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, null, null, "Hindu" },
                    { 2, null, null, "Muslim" },
                    { 3, null, null, "Sikh" },
                    { 4, null, null, "Christian" },
                    { 5, null, null, "Others" }
                });

            migrationBuilder.InsertData(
                table: "Section",
                columns: new[] { "Id", "CreatedDate", "ModifiedDate", "Name" },
                values: new object[] { 1, null, null, "A" });

            migrationBuilder.InsertData(
                table: "StudyStatus",
                columns: new[] { "Id", "CreatedDate", "ModifiedDate", "Name" },
                values: new object[] { 1, null, null, "Study" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "Religion");

            migrationBuilder.DropTable(
                name: "Section");

            migrationBuilder.DropTable(
                name: "StudyStatus");

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
                name: "AadharNumber",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "AdmissionDate",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "AdmissionInClass",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "AdmissionInSection",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "AdmissionNumber",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "BloodGroup",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "ClassesId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "CurrentClass",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "CurrentSection",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "EmergencyContactNumber",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "FatherName",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "GendersId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "MotherName",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "ProfileImage",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "ReligionId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "SectionsId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "StudyStatusId",
                table: "Student");

            migrationBuilder.RenameColumn(
                name: "StudentCode",
                table: "Student",
                newName: "StudentName");
        }
    }
}
