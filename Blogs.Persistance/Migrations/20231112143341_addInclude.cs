using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blogs.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class addInclude : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("de97bc13-bd2e-4434-8b19-fa51704d5bd0"));

            migrationBuilder.AddColumn<Guid>(
                name: "BlogId1",
                table: "Comments",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId1",
                table: "Comments",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId1",
                table: "Blogs",
                type: "uuid",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("01051801-6828-4332-9620-4250f02820cc"),
                column: "CreatedTime",
                value: new DateTime(2023, 11, 12, 14, 33, 40, 900, DateTimeKind.Utc).AddTicks(4671));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9e2b4bff-a5ee-4f9f-9e1f-c11d62ee2ddf"),
                column: "CreatedTime",
                value: new DateTime(2023, 11, 12, 14, 33, 40, 900, DateTimeKind.Utc).AddTicks(4674));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "EmailAddress", "FirstName", "IsEmailAddressVerified", "LastName", "PasswordHash", "RoleId" },
                values: new object[] { new Guid("b14ea12b-46a0-417d-9586-79d33d00c4de"), 20, "abdurahmonsadriddinov0412@gmail.com", "Abdurahmon", true, "Sadriddinov", "Abdurahmon0440", new Guid("9e2b4bff-a5ee-4f9f-9e1f-c11d62ee2ddf") });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BlogId1",
                table: "Comments",
                column: "BlogId1");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId1",
                table: "Comments",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_UserId1",
                table: "Blogs",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Users_UserId1",
                table: "Blogs",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Blogs_BlogId1",
                table: "Comments",
                column: "BlogId1",
                principalTable: "Blogs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_UserId1",
                table: "Comments",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Users_UserId1",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Blogs_BlogId1",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_UserId1",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_BlogId1",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_UserId1",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_UserId1",
                table: "Blogs");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b14ea12b-46a0-417d-9586-79d33d00c4de"));

            migrationBuilder.DropColumn(
                name: "BlogId1",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Blogs");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("01051801-6828-4332-9620-4250f02820cc"),
                column: "CreatedTime",
                value: new DateTime(2023, 11, 12, 13, 36, 15, 336, DateTimeKind.Utc).AddTicks(1704));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9e2b4bff-a5ee-4f9f-9e1f-c11d62ee2ddf"),
                column: "CreatedTime",
                value: new DateTime(2023, 11, 12, 13, 36, 15, 336, DateTimeKind.Utc).AddTicks(1709));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "EmailAddress", "FirstName", "IsEmailAddressVerified", "LastName", "PasswordHash", "RoleId" },
                values: new object[] { new Guid("de97bc13-bd2e-4434-8b19-fa51704d5bd0"), 20, "abdurahmonsadriddinov0412@gmail.com", "Abdurahmon", true, "Sadriddinov", "Abdurahmon0440", new Guid("9e2b4bff-a5ee-4f9f-9e1f-c11d62ee2ddf") });
        }
    }
}
