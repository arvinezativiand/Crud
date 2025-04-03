using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crud.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RPouyaFilesRecreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RPouyaFile",
                table: "RPouyaFile");

            migrationBuilder.RenameTable(
                name: "RPouyaFile",
                newName: "RPouyaFiles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RPouyaFiles",
                table: "RPouyaFiles",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RPouyaFiles",
                table: "RPouyaFiles");

            migrationBuilder.RenameTable(
                name: "RPouyaFiles",
                newName: "RPouyaFile");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RPouyaFile",
                table: "RPouyaFile",
                column: "Id");
        }
    }
}
