using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blogs.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class blogInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5abf9d85-edbe-48de-8bb4-22bd6d0641c4"));

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    PublishDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blogs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_UserId",
                table: "Blogs",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f9365115-ba56-4a75-a8d9-ff291ddd0478"));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("01051801-6828-4332-9620-4250f02820cc"),
                column: "CreatedTime",
                value: new DateTime(2023, 11, 12, 12, 50, 49, 592, DateTimeKind.Utc).AddTicks(4450));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9e2b4bff-a5ee-4f9f-9e1f-c11d62ee2ddf"),
                column: "CreatedTime",
                value: new DateTime(2023, 11, 12, 12, 50, 49, 592, DateTimeKind.Utc).AddTicks(4452));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "EmailAddress", "FirstName", "IsEmailAddressVerified", "LastName", "PasswordHash", "RoleId" },
                values: new object[] { new Guid("5abf9d85-edbe-48de-8bb4-22bd6d0641c4"), 20, "abdurahmonsadriddinov0412@gmail.com", "Abdurahmon", true, "Sadriddinov", "Abdurahmon0440", new Guid("9e2b4bff-a5ee-4f9f-9e1f-c11d62ee2ddf") });
        }
    }
}
