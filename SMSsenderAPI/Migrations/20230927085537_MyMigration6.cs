using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMSsenderAPI.Migrations
{
    /// <inheritdoc />
    public partial class MyMigration6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sms2Template");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime",
                table: "Smses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime",
                table: "Smses",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "Sms2Template",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SmsId = table.Column<int>(type: "int", nullable: false),
                    TemplateId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sms2Template", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sms2Template_Smses_SmsId",
                        column: x => x.SmsId,
                        principalTable: "Smses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sms2Template_Templates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "Templates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sms2Template_SmsId",
                table: "Sms2Template",
                column: "SmsId");

            migrationBuilder.CreateIndex(
                name: "IX_Sms2Template_TemplateId",
                table: "Sms2Template",
                column: "TemplateId");
        }
    }
}
