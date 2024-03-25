using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restful_API.Migrations
{
    public partial class SeedSchoolData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
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
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
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
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "State",
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
                    table.PrimaryKey("PK_State", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "CreatedDate", "ModifiedDate", "Name" },
                values: new object[] { 1, null, null, "Bangalore" });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "CreatedDate", "ModifiedDate", "Name" },
                values: new object[] { 1, null, null, "India" });

            migrationBuilder.InsertData(
                table: "School",
                columns: new[] { "Id", "Address", "City", "ContactNumber", "ContactPersonEmail", "ContactPersonName", "ContactPersonNumber", "CreatedDate", "ModifiedDate", "Name", "PhoneNumber", "PinCode", "State" },
                values: new object[] { 1, "Address", 1, "8951021503", "codevidyalaya@gmail.com", "Satya Prakash Tripathi", "8951021503", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "School", "8951021503", "563014", 1 });

            migrationBuilder.InsertData(
                table: "State",
                columns: new[] { "Id", "CreatedDate", "ModifiedDate", "Name" },
                values: new object[] { 1, null, null, "Karnataka" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DeleteData(
                table: "School",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
