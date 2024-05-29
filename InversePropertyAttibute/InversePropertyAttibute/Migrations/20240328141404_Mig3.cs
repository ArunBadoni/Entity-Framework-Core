using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InversePropertyAttibute.Migrations
{
    /// <inheritdoc />
    public partial class Mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OfflineTeacherTeacherId",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_OfflineTeacherTeacherId",
                table: "Courses",
                column: "OfflineTeacherTeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Teachers_OfflineTeacherTeacherId",
                table: "Courses",
                column: "OfflineTeacherTeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Teachers_OfflineTeacherTeacherId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_OfflineTeacherTeacherId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "OfflineTeacherTeacherId",
                table: "Courses");
        }
    }
}
