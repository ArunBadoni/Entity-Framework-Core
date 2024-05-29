using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseGeneratedAttibuteinEFCore.Migrations
{
    /// <inheritdoc />
    public partial class Mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedDate",
                table: "Students",
                type: "int",
                nullable: false,
                computedColumnSql: "GETUTCDATE()");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true,
                computedColumnSql: "[FirstName]+' '+[LastName]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Students");
        }
    }
}
