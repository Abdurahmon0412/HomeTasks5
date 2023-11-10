using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Identity.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class initialAccessTokenmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                value: new DateTime(2023, 11, 10, 10, 5, 11, 519, DateTimeKind.Utc).AddTicks(2350));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7d07ea1f-9be7-48f0-ad91-5b83a5806baf"),
                column: "CreatedTime",
                value: new DateTime(2023, 11, 10, 10, 5, 11, 519, DateTimeKind.Utc).AddTicks(2353));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("df290f92-dd78-4fa7-9ce3-6b0056a8b68f"),
                column: "CreatedTime",
                value: new DateTime(2023, 11, 10, 10, 5, 11, 519, DateTimeKind.Utc).AddTicks(2354));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "EmailAddress", "FirstName", "IsEmailAddressVerified", "LastName", "PasswordHash", "RoleId" },
                values: new object[] { new Guid("90d9a341-f804-44c8-8598-c5a910546166"), 39, "Nimada@example.com", "John", true, "Smith", "asldjfqjewoqwa", new Guid("94e5b7aa-45ad-4267-9a5e-236670a15f82") });

            migrationBuilder.CreateIndex(
                name: "IX_AccessTokens_UserId",
                table: "AccessTokens",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AccessTokens_Users_UserId",
                table: "AccessTokens",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccessTokens_Users_UserId",
                table: "AccessTokens");

            migrationBuilder.DropIndex(
                name: "IX_AccessTokens_UserId",
                table: "AccessTokens");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("90d9a341-f804-44c8-8598-c5a910546166"));

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
    }
}
