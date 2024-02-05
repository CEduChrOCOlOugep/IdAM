using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdAM.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeIdColumnType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
            name: "Id",
            table: "AspNetRoles",
            type: "nvarchar(450)",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "text");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
            name: "Id",
            table: "AspNetRoles",
            type: "text",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "nvarchar(450)");

        }
    }
}
