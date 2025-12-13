using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolHallBooking.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTeacherDutyFollowupRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TeacherProfileId",
                table: "TeacherDutyFollowups",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "FirstTeacherProfileId",
                table: "TeacherDutyFollowups",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeacherDutyFollowups_FirstTeacherProfileId",
                table: "TeacherDutyFollowups",
                column: "FirstTeacherProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherDutyFollowups_FirstTeacherProfiles_FirstTeacherProfileId",
                table: "TeacherDutyFollowups",
                column: "FirstTeacherProfileId",
                principalTable: "FirstTeacherProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeacherDutyFollowups_FirstTeacherProfiles_FirstTeacherProfileId",
                table: "TeacherDutyFollowups");

            migrationBuilder.DropIndex(
                name: "IX_TeacherDutyFollowups_FirstTeacherProfileId",
                table: "TeacherDutyFollowups");

            migrationBuilder.DropColumn(
                name: "FirstTeacherProfileId",
                table: "TeacherDutyFollowups");

            migrationBuilder.AlterColumn<int>(
                name: "TeacherProfileId",
                table: "TeacherDutyFollowups",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);
        }
    }
}
