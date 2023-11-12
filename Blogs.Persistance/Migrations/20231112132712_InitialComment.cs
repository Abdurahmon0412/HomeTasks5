using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blogs.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class InitialComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f9365115-ba56-4a75-a8d9-ff291ddd0478"));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("01051801-6828-4332-9620-4250f02820cc"),
                column: "CreatedTime",
                value: new DateTime(2023, 11, 12, 13, 27, 12, 208, DateTimeKind.Utc).AddTicks(9347));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9e2b4bff-a5ee-4f9f-9e1f-c11d62ee2ddf"),
                column: "CreatedTime",
                value: new DateTime(2023, 11, 12, 13, 27, 12, 208, DateTimeKind.Utc).AddTicks(9350));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "EmailAddress", "FirstName", "IsEmailAddressVerified", "LastName", "PasswordHash", "RoleId" },
                values: new object[] { new Guid("00d86ede-bc63-4827-8916-d5e399a8733f"), 20, "abdurahmonsadriddinov0412@gmail.com", "Abdurahmon", true, "Sadriddinov", "Abdurahmon0440", new Guid("9e2b4bff-a5ee-4f9f-9e1f-c11d62ee2ddf") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00d86ede-bc63-4827-8916-d5e399a8733f"));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("01051801-6828-4332-9620-4250f02820cc"),
                column: "CreatedTime",
                value: new DateTime(2023, 11, 12, 13, 19, 52, 119, DateTimeKind.Utc).AddTicks(9609));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9e2b4bff-a5ee-4f9f-9e1f-c11d62ee2ddf"),
                column: "CreatedTime",
                value: new DateTime(2023, 11, 12, 13, 19, 52, 119, DateTimeKind.Utc).AddTicks(9616));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "EmailAddress", "FirstName", "IsEmailAddressVerified", "LastName", "PasswordHash", "RoleId" },
                values: new object[] { new Guid("f9365115-ba56-4a75-a8d9-ff291ddd0478"), 20, "abdurahmonsadriddinov0412@gmail.com", "Abdurahmon", true, "Sadriddinov", "Abdurahmon0440", new Guid("9e2b4bff-a5ee-4f9f-9e1f-c11d62ee2ddf") });
        }
    }
}
