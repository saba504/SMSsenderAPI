using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMSsenderAPI.Migrations
{
    /// <inheritdoc />
    public partial class MyMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Smses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Smses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
