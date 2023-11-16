using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Notifications.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddUserandUserSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NotificationTemplate",
                table: "NotificationTemplate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NotificationHistory",
                table: "NotificationHistory");

            migrationBuilder.RenameTable(
                name: "NotificationTemplate",
                newName: "NotificationTemplates");

            migrationBuilder.RenameTable(
                name: "NotificationHistory",
                newName: "NotificationHistories");

            migrationBuilder.RenameColumn(
                name: "NotificationType",
                table: "NotificationTemplates",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "SenderId",
                table: "NotificationHistories",
                newName: "TemplateId");

            migrationBuilder.RenameColumn(
                name: "ReceiverId",
                table: "NotificationHistories",
                newName: "SenderUserId");

            migrationBuilder.RenameColumn(
                name: "NotificationType",
                table: "NotificationHistories",
                newName: "Type");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Subject",
                table: "NotificationTemplates",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "NotificationTemplates",
                type: "character varying(129536)",
                maxLength: 129536,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256);

            migrationBuilder.AddColumn<int>(
                name: "TemplateType",
                table: "NotificationTemplates",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Subject",
                table: "NotificationHistories",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "NotificationHistories",
                type: "character varying(129536)",
                maxLength: 129536,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "ErrorMessage",
                table: "NotificationHistories",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSuccessful",
                table: "NotificationHistories",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ReceiverEmailAddress",
                table: "NotificationHistories",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReceiverPhoneNumber",
                table: "NotificationHistories",
                type: "character varying(32)",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ReceiverUserId",
                table: "NotificationHistories",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "SenderEmailAddress",
                table: "NotificationHistories",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderPhoneNumber",
                table: "NotificationHistories",
                type: "character varying(32)",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_NotificationTemplates",
                table: "NotificationTemplates",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NotificationHistories",
                table: "NotificationHistories",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UsersSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PreferredNotificationType = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersSettings_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NotificationHistories_ReceiverUserId",
                table: "NotificationHistories",
                column: "ReceiverUserId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationHistories_SenderUserId",
                table: "NotificationHistories",
                column: "SenderUserId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationHistories_TemplateId",
                table: "NotificationHistories",
                column: "TemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationHistories_NotificationTemplates_TemplateId",
                table: "NotificationHistories",
                column: "TemplateId",
                principalTable: "NotificationTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationHistories_Users_ReceiverUserId",
                table: "NotificationHistories",
                column: "ReceiverUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationHistories_Users_SenderUserId",
                table: "NotificationHistories",
                column: "SenderUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotificationHistories_NotificationTemplates_TemplateId",
                table: "NotificationHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_NotificationHistories_Users_ReceiverUserId",
                table: "NotificationHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_NotificationHistories_Users_SenderUserId",
                table: "NotificationHistories");

            migrationBuilder.DropTable(
                name: "UsersSettings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NotificationTemplates",
                table: "NotificationTemplates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NotificationHistories",
                table: "NotificationHistories");

            migrationBuilder.DropIndex(
                name: "IX_NotificationHistories_ReceiverUserId",
                table: "NotificationHistories");

            migrationBuilder.DropIndex(
                name: "IX_NotificationHistories_SenderUserId",
                table: "NotificationHistories");

            migrationBuilder.DropIndex(
                name: "IX_NotificationHistories_TemplateId",
                table: "NotificationHistories");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TemplateType",
                table: "NotificationTemplates");

            migrationBuilder.DropColumn(
                name: "ErrorMessage",
                table: "NotificationHistories");

            migrationBuilder.DropColumn(
                name: "IsSuccessful",
                table: "NotificationHistories");

            migrationBuilder.DropColumn(
                name: "ReceiverEmailAddress",
                table: "NotificationHistories");

            migrationBuilder.DropColumn(
                name: "ReceiverPhoneNumber",
                table: "NotificationHistories");

            migrationBuilder.DropColumn(
                name: "ReceiverUserId",
                table: "NotificationHistories");

            migrationBuilder.DropColumn(
                name: "SenderEmailAddress",
                table: "NotificationHistories");

            migrationBuilder.DropColumn(
                name: "SenderPhoneNumber",
                table: "NotificationHistories");

            migrationBuilder.RenameTable(
                name: "NotificationTemplates",
                newName: "NotificationTemplate");

            migrationBuilder.RenameTable(
                name: "NotificationHistories",
                newName: "NotificationHistory");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "NotificationTemplate",
                newName: "NotificationType");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "NotificationHistory",
                newName: "NotificationType");

            migrationBuilder.RenameColumn(
                name: "TemplateId",
                table: "NotificationHistory",
                newName: "SenderId");

            migrationBuilder.RenameColumn(
                name: "SenderUserId",
                table: "NotificationHistory",
                newName: "ReceiverId");

            migrationBuilder.AlterColumn<string>(
                name: "Subject",
                table: "NotificationTemplate",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "NotificationTemplate",
                type: "character varying(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(129536)",
                oldMaxLength: 129536);

            migrationBuilder.AlterColumn<string>(
                name: "Subject",
                table: "NotificationHistory",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "NotificationHistory",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(129536)",
                oldMaxLength: 129536);

            migrationBuilder.AddPrimaryKey(
                name: "PK_NotificationTemplate",
                table: "NotificationTemplate",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NotificationHistory",
                table: "NotificationHistory",
                column: "Id");
        }
    }
}
