using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseGeneratedAttibuteinEFCore.Migrations
{
    /// <inheritdoc />
    public partial class Mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Students",
                type: "datetime2",
                nullable: false,
                computedColumnSql: "GETUTCDATE()",
                oldClrType: typeof(int),
                oldType: "int",
                oldComputedColumnSql: "GETUTCDATE()");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CreatedDate",
                table: "Students",
                type: "int",
                nullable: false,
                computedColumnSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComputedColumnSql: "GETUTCDATE()");
        }
    }
}
