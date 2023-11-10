using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Identity.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class adduserinitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("6d3503ab-1a35-47b9-be09-b24ff4fbf6bf"),
                column: "CreatedTime",
                value: new DateTime(2023, 11, 10, 10, 0, 13, 560, DateTimeKind.Utc).AddTicks(5904));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7d07ea1f-9be7-48f0-ad91-5b83a5806baf"),
                column: "CreatedTime",
                value: new DateTime(2023, 11, 10, 10, 0, 13, 560, DateTimeKind.Utc).AddTicks(5907));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("df290f92-dd78-4fa7-9ce3-6b0056a8b68f"),
                column: "CreatedTime",
                value: new DateTime(2023, 11, 10, 10, 0, 13, 560, DateTimeKind.Utc).AddTicks(5909));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "EmailAddress", "FirstName", "IsEmailAddressVerified", "LastName", "PasswordHash", "RoleId" },
                values: new object[] { new Guid("09c95277-b051-4196-8dcf-6c6d66da1bd2"), 39, "Nimada@example.com", "John", true, "Smith", "asldjfqjewoqwa", new Guid("94e5b7aa-45ad-4267-9a5e-236670a15f82") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("09c95277-b051-4196-8dcf-6c6d66da1bd2"));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("6d3503ab-1a35-47b9-be09-b24ff4fbf6bf"),
                column: "CreatedTime",
                value: new DateTime(2023, 11, 10, 9, 51, 17, 784, DateTimeKind.Utc).AddTicks(4314));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7d07ea1f-9be7-48f0-ad91-5b83a5806baf"),
                column: "CreatedTime",
                value: new DateTime(2023, 11, 10, 9, 51, 17, 784, DateTimeKind.Utc).AddTicks(4317));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("df290f92-dd78-4fa7-9ce3-6b0056a8b68f"),
                column: "CreatedTime",
                value: new DateTime(2023, 11, 10, 9, 51, 17, 784, DateTimeKind.Utc).AddTicks(4318));
        }
    }
}
