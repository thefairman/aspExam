using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class univer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "442a45a3-01a2-4c22-899e-40ae2b48c375");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "859f28ed-0bc8-4413-a1d9-c4e71f89e49f");

            migrationBuilder.CreateTable(
                name: "faculties",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_faculties", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "groups",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    facultyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_groups", x => x.id);
                    table.ForeignKey(
                        name: "FK_groups_faculties_facultyId",
                        column: x => x.facultyId,
                        principalTable: "faculties",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    lastName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    groupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.id);
                    table.ForeignKey(
                        name: "FK_students_groups_groupId",
                        column: x => x.groupId,
                        principalTable: "groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "88b786ca-c51d-469c-9ca9-e4236b74d0f4", "4f08009b-a146-4451-b702-2eac63acd2bc", "Administrators", "ADMINISTRATORS" },
                    { "bcfecaf6-9663-4a2e-ac61-b6f02b9edab4", "a73957f7-b03b-427b-94ed-8dc678853093", "Moderators", "MODERATORS" }
                });

            migrationBuilder.InsertData(
                table: "faculties",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("2bfefc83-4358-46f9-a50d-f60a8bd4fc50"), "Системного администрирования" },
                    { new Guid("096611f0-5051-49e8-8cd0-8dab152dbf48"), "Программирования" },
                    { new Guid("9451172e-6a04-4540-9187-eca5dd0e18c4"), "Компьютерной графики т дизайна" },
                    { new Guid("6f165049-2fa2-4cab-993f-94d3b598dbb2"), "Годичные курсы" },
                    { new Guid("7c321722-7e5b-4a0b-8e05-673b05a50b47"), "Базовый курс" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_groups_facultyId",
                table: "groups",
                column: "facultyId");

            migrationBuilder.CreateIndex(
                name: "IX_students_groupId",
                table: "students",
                column: "groupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "groups");

            migrationBuilder.DropTable(
                name: "faculties");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88b786ca-c51d-469c-9ca9-e4236b74d0f4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bcfecaf6-9663-4a2e-ac61-b6f02b9edab4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "859f28ed-0bc8-4413-a1d9-c4e71f89e49f", "f6cab353-d8b6-4d05-86a5-b91c3b793262", "Administrators", "ADMINISTRATORS" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "442a45a3-01a2-4c22-899e-40ae2b48c375", "81b56ef0-dc54-498a-af57-b2a7b012b8f7", "Moderators", "MODERATORS" });
        }
    }
}
