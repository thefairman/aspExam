using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class userRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88b786ca-c51d-469c-9ca9-e4236b74d0f4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bcfecaf6-9663-4a2e-ac61-b6f02b9edab4");

            migrationBuilder.DeleteData(
                table: "faculties",
                keyColumn: "id",
                keyValue: new Guid("096611f0-5051-49e8-8cd0-8dab152dbf48"));

            migrationBuilder.DeleteData(
                table: "faculties",
                keyColumn: "id",
                keyValue: new Guid("2bfefc83-4358-46f9-a50d-f60a8bd4fc50"));

            migrationBuilder.DeleteData(
                table: "faculties",
                keyColumn: "id",
                keyValue: new Guid("6f165049-2fa2-4cab-993f-94d3b598dbb2"));

            migrationBuilder.DeleteData(
                table: "faculties",
                keyColumn: "id",
                keyValue: new Guid("7c321722-7e5b-4a0b-8e05-673b05a50b47"));

            migrationBuilder.DeleteData(
                table: "faculties",
                keyColumn: "id",
                keyValue: new Guid("9451172e-6a04-4540-9187-eca5dd0e18c4"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8cb205a2-326d-4694-ab14-4a478df489ad", "751d2bf5-b573-43d7-9e6a-068708e55c0b", "Administrators", "ADMINISTRATORS" },
                    { "f56aefe8-3b4a-49cb-9b0d-9c2c633708f0", "c0a6738b-350a-41c1-9ec2-709e4350b55c", "Moderators", "MODERATORS" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "859f28ed-0bc8-4413-a1d9-c4e71f89e49f", "d5a63167-9ad9-4f05-bff3-74dc627818da" });

            migrationBuilder.InsertData(
                table: "faculties",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("723ed937-0088-46aa-aaae-be49329e66c8"), "Системного администрирования" },
                    { new Guid("ddecb079-6a7a-46f9-8c36-1143fc978fb6"), "Программирования" },
                    { new Guid("f036c719-e85c-4b2c-a071-8155bc766e0e"), "Компьютерной графики т дизайна" },
                    { new Guid("9988df19-8ac7-4347-934d-0e7be81d8a2e"), "Годичные курсы" },
                    { new Guid("901c8da0-0eb3-48d6-a8a7-e2cf75b6a287"), "Базовый курс" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8cb205a2-326d-4694-ab14-4a478df489ad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f56aefe8-3b4a-49cb-9b0d-9c2c633708f0");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "859f28ed-0bc8-4413-a1d9-c4e71f89e49f", "d5a63167-9ad9-4f05-bff3-74dc627818da" });

            migrationBuilder.DeleteData(
                table: "faculties",
                keyColumn: "id",
                keyValue: new Guid("723ed937-0088-46aa-aaae-be49329e66c8"));

            migrationBuilder.DeleteData(
                table: "faculties",
                keyColumn: "id",
                keyValue: new Guid("901c8da0-0eb3-48d6-a8a7-e2cf75b6a287"));

            migrationBuilder.DeleteData(
                table: "faculties",
                keyColumn: "id",
                keyValue: new Guid("9988df19-8ac7-4347-934d-0e7be81d8a2e"));

            migrationBuilder.DeleteData(
                table: "faculties",
                keyColumn: "id",
                keyValue: new Guid("ddecb079-6a7a-46f9-8c36-1143fc978fb6"));

            migrationBuilder.DeleteData(
                table: "faculties",
                keyColumn: "id",
                keyValue: new Guid("f036c719-e85c-4b2c-a071-8155bc766e0e"));

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
        }
    }
}
