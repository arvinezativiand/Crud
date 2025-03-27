using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crud.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class BaseEntityUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RPouyaUsers",
                table: "RPouyaUsers");

            migrationBuilder.AlterColumn<string>(
                name: "IdNumber",
                table: "RPouyaUsers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<decimal>(
                name: "Id",
                table: "RPouyaUsers",
                type: "decimal(20,0)",
                nullable: false,
                defaultValue: 0m)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RPouyaUsers",
                table: "RPouyaUsers",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RPouyaUsers",
                table: "RPouyaUsers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "RPouyaUsers");

            migrationBuilder.AlterColumn<string>(
                name: "IdNumber",
                table: "RPouyaUsers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RPouyaUsers",
                table: "RPouyaUsers",
                column: "IdNumber");
        }
    }
}
