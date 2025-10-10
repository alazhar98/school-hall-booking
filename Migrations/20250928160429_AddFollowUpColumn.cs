using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolHallBooking.Migrations
{
    /// <inheritdoc />
    public partial class AddFollowUpColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AfterExecution",
                table: "TrainingProgramDesigns");

            migrationBuilder.DropColumn(
                name: "DuringExecution",
                table: "TrainingProgramDesigns");

            migrationBuilder.DropColumn(
                name: "EvaluationMethod",
                table: "TrainingProgramDesigns");

            migrationBuilder.DropColumn(
                name: "WillBeFollowedUp",
                table: "TrainingProgramDesigns");

            migrationBuilder.RenameColumn(
                name: "FollowUpPlan",
                table: "TrainingProgramDesigns",
                newName: "ProposedFollowUpPlan");

            migrationBuilder.AddColumn<string>(
                name: "FollowUp",
                table: "TrainingProgramDesigns",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProgramEvaluation",
                table: "TrainingProgramDesigns",
                type: "TEXT",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FollowUp",
                table: "TrainingProgramDesigns");

            migrationBuilder.DropColumn(
                name: "ProgramEvaluation",
                table: "TrainingProgramDesigns");

            migrationBuilder.RenameColumn(
                name: "ProposedFollowUpPlan",
                table: "TrainingProgramDesigns",
                newName: "FollowUpPlan");

            migrationBuilder.AddColumn<bool>(
                name: "AfterExecution",
                table: "TrainingProgramDesigns",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DuringExecution",
                table: "TrainingProgramDesigns",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "EvaluationMethod",
                table: "TrainingProgramDesigns",
                type: "TEXT",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "WillBeFollowedUp",
                table: "TrainingProgramDesigns",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }
    }
}
