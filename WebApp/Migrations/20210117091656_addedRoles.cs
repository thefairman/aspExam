using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class addedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "859f28ed-0bc8-4413-a1d9-c4e71f89e49f", "f6cab353-d8b6-4d05-86a5-b91c3b793262", "Administrators", "ADMINISTRATORS" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "442a45a3-01a2-4c22-899e-40ae2b48c375", "81b56ef0-dc54-498a-af57-b2a7b012b8f7", "Moderators", "MODERATORS" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "442a45a3-01a2-4c22-899e-40ae2b48c375");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "859f28ed-0bc8-4413-a1d9-c4e71f89e49f");
        }
    }
}
