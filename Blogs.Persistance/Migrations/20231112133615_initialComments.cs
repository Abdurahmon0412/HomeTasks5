using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blogs.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class initialComments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00d86ede-bc63-4827-8916-d5e399a8733f"));

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    BlogId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
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

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BlogId",
                table: "Comments",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("de97bc13-bd2e-4434-8b19-fa51704d5bd0"));

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
    }
}
