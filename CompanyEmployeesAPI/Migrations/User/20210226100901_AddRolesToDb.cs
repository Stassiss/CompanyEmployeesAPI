using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyEmployeesAPI.Migrations.User
{
    public partial class AddRolesToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1806a35a-25d8-4dcf-944d-b824f1d7d1c9", "38981439-ac86-4c77-bed8-c54c88543c50", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "226dd242-41fc-4626-abba-21ea8da88c0d", "40938834-992a-479a-b4a0-bea32b81422d", "Visitor", "VISITOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1806a35a-25d8-4dcf-944d-b824f1d7d1c9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "226dd242-41fc-4626-abba-21ea8da88c0d");
        }
    }
}
