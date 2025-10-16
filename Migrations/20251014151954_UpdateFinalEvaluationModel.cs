using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolHallBooking.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFinalEvaluationModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActivitiesMatchTopics",
                table: "FinalEvaluations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CombiningTheoryAndPractice",
                table: "FinalEvaluations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CommitmentToTrainingTopics",
                table: "FinalEvaluations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConfidenceAfterProgram",
                table: "FinalEvaluations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ConfidenceBeforeProgram",
                table: "FinalEvaluations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ContributesToCurrentJob",
                table: "FinalEvaluations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DevelopmentAspects",
                table: "FinalEvaluations",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EducationalQualification",
                table: "FinalEvaluations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EvaluationDate",
                table: "FinalEvaluations",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "JobTitle",
                table: "FinalEvaluations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KnowledgeAfterProgram",
                table: "FinalEvaluations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KnowledgeBeforeProgram",
                table: "FinalEvaluations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MeetsPersonalExpectations",
                table: "FinalEvaluations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ParticipantName",
                table: "FinalEvaluations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ProgramDateSuitability",
                table: "FinalEvaluations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RelatedFunctions",
                table: "FinalEvaluations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SchoolName",
                table: "FinalEvaluations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SkillsAfterProgram",
                table: "FinalEvaluations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SkillsBeforeProgram",
                table: "FinalEvaluations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SupportFromProgramStaff",
                table: "FinalEvaluations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TopicsSuitableForParticipants",
                table: "FinalEvaluations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TrainerAbilityToConveyInformation",
                table: "FinalEvaluations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TrainerInteractionWithParticipants",
                table: "FinalEvaluations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TrainerMasteryOfMaterial",
                table: "FinalEvaluations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TrainingMaterialAdequacy",
                table: "FinalEvaluations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TrainingRoomSuitability",
                table: "FinalEvaluations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActivitiesMatchTopics",
                table: "FinalEvaluations");

            migrationBuilder.DropColumn(
                name: "CombiningTheoryAndPractice",
                table: "FinalEvaluations");

            migrationBuilder.DropColumn(
                name: "CommitmentToTrainingTopics",
                table: "FinalEvaluations");

            migrationBuilder.DropColumn(
                name: "ConfidenceAfterProgram",
                table: "FinalEvaluations");

            migrationBuilder.DropColumn(
                name: "ConfidenceBeforeProgram",
                table: "FinalEvaluations");

            migrationBuilder.DropColumn(
                name: "ContributesToCurrentJob",
                table: "FinalEvaluations");

            migrationBuilder.DropColumn(
                name: "DevelopmentAspects",
                table: "FinalEvaluations");

            migrationBuilder.DropColumn(
                name: "EducationalQualification",
                table: "FinalEvaluations");

            migrationBuilder.DropColumn(
                name: "EvaluationDate",
                table: "FinalEvaluations");

            migrationBuilder.DropColumn(
                name: "JobTitle",
                table: "FinalEvaluations");

            migrationBuilder.DropColumn(
                name: "KnowledgeAfterProgram",
                table: "FinalEvaluations");

            migrationBuilder.DropColumn(
                name: "KnowledgeBeforeProgram",
                table: "FinalEvaluations");

            migrationBuilder.DropColumn(
                name: "MeetsPersonalExpectations",
                table: "FinalEvaluations");

            migrationBuilder.DropColumn(
                name: "ParticipantName",
                table: "FinalEvaluations");

            migrationBuilder.DropColumn(
                name: "ProgramDateSuitability",
                table: "FinalEvaluations");

            migrationBuilder.DropColumn(
                name: "RelatedFunctions",
                table: "FinalEvaluations");

            migrationBuilder.DropColumn(
                name: "SchoolName",
                table: "FinalEvaluations");

            migrationBuilder.DropColumn(
                name: "SkillsAfterProgram",
                table: "FinalEvaluations");

            migrationBuilder.DropColumn(
                name: "SkillsBeforeProgram",
                table: "FinalEvaluations");

            migrationBuilder.DropColumn(
                name: "SupportFromProgramStaff",
                table: "FinalEvaluations");

            migrationBuilder.DropColumn(
                name: "TopicsSuitableForParticipants",
                table: "FinalEvaluations");

            migrationBuilder.DropColumn(
                name: "TrainerAbilityToConveyInformation",
                table: "FinalEvaluations");

            migrationBuilder.DropColumn(
                name: "TrainerInteractionWithParticipants",
                table: "FinalEvaluations");

            migrationBuilder.DropColumn(
                name: "TrainerMasteryOfMaterial",
                table: "FinalEvaluations");

            migrationBuilder.DropColumn(
                name: "TrainingMaterialAdequacy",
                table: "FinalEvaluations");

            migrationBuilder.DropColumn(
                name: "TrainingRoomSuitability",
                table: "FinalEvaluations");
        }
    }
}
