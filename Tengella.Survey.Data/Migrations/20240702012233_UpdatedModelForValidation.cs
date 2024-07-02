using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tengella.Survey.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedModelForValidation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Submissions_SubmissionId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Choices_Questions_QuestionId",
                table: "Choices");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_SurveyObjects_SurveyObjectId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Submissions_SurveyObjects_SurveyObjectId",
                table: "Submissions");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyObjects_Users_UserId",
                table: "SurveyObjects");

            migrationBuilder.DropForeignKey(
                name: "FK_TemplateChoices_TemplateQuestions_TemplateQuestionId",
                table: "TemplateChoices");

            migrationBuilder.DropForeignKey(
                name: "FK_TemplateQuestions_SurveyTemplates_SurveyTemplateId",
                table: "TemplateQuestions");

            migrationBuilder.DeleteData(
                table: "TemplateChoices",
                keyColumn: "TemplateChoiceId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TemplateChoices",
                keyColumn: "TemplateChoiceId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TemplateChoices",
                keyColumn: "TemplateChoiceId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TemplateChoices",
                keyColumn: "TemplateChoiceId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TemplateChoices",
                keyColumn: "TemplateChoiceId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TemplateChoices",
                keyColumn: "TemplateChoiceId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TemplateChoices",
                keyColumn: "TemplateChoiceId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TemplateChoices",
                keyColumn: "TemplateChoiceId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TemplateChoices",
                keyColumn: "TemplateChoiceId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TemplateChoices",
                keyColumn: "TemplateChoiceId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TemplateQuestions",
                keyColumn: "TemplateQuestionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TemplateQuestions",
                keyColumn: "TemplateQuestionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TemplateQuestions",
                keyColumn: "TemplateQuestionId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TemplateQuestions",
                keyColumn: "TemplateQuestionId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SurveyTemplates",
                keyColumn: "SurveyTemplateId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SurveyTemplates",
                keyColumn: "SurveyTemplateId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TemplateQuestions",
                keyColumn: "TemplateQuestionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TemplateQuestions",
                keyColumn: "TemplateQuestionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SurveyTemplates",
                keyColumn: "SurveyTemplateId",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "SurveyTemplateId",
                table: "TemplateQuestions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "QuestionType",
                table: "TemplateQuestions",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "QuestionText",
                table: "TemplateQuestions",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "QuestionPosition",
                table: "TemplateQuestions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TemplateQuestionId",
                table: "TemplateChoices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ChoiceText",
                table: "TemplateChoices",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ChoicePosition",
                table: "TemplateChoices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TemplateName",
                table: "SurveyTemplates",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "SurveyTemplates",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SurveyType",
                table: "SurveyObjects",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SurveyTitle",
                table: "SurveyObjects",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SurveyDescription",
                table: "SurveyObjects",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SurveyObjectId",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "QuestionType",
                table: "Questions",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "QuestionPosition",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "QuestionName",
                table: "Questions",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ChoiceText",
                table: "Choices",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ChoicePosition",
                table: "Choices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "QuestionId",
                table: "Answers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AnswerValue",
                table: "Answers",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Submissions_SubmissionId",
                table: "Answers",
                column: "SubmissionId",
                principalTable: "Submissions",
                principalColumn: "SubmissionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Choices_Questions_QuestionId",
                table: "Choices",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_SurveyObjects_SurveyObjectId",
                table: "Questions",
                column: "SurveyObjectId",
                principalTable: "SurveyObjects",
                principalColumn: "SurveyObjectId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Submissions_SurveyObjects_SurveyObjectId",
                table: "Submissions",
                column: "SurveyObjectId",
                principalTable: "SurveyObjects",
                principalColumn: "SurveyObjectId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyObjects_Users_UserId",
                table: "SurveyObjects",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TemplateChoices_TemplateQuestions_TemplateQuestionId",
                table: "TemplateChoices",
                column: "TemplateQuestionId",
                principalTable: "TemplateQuestions",
                principalColumn: "TemplateQuestionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TemplateQuestions_SurveyTemplates_SurveyTemplateId",
                table: "TemplateQuestions",
                column: "SurveyTemplateId",
                principalTable: "SurveyTemplates",
                principalColumn: "SurveyTemplateId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Submissions_SubmissionId",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Choices_Questions_QuestionId",
                table: "Choices");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_SurveyObjects_SurveyObjectId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Submissions_SurveyObjects_SurveyObjectId",
                table: "Submissions");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyObjects_Users_UserId",
                table: "SurveyObjects");

            migrationBuilder.DropForeignKey(
                name: "FK_TemplateChoices_TemplateQuestions_TemplateQuestionId",
                table: "TemplateChoices");

            migrationBuilder.DropForeignKey(
                name: "FK_TemplateQuestions_SurveyTemplates_SurveyTemplateId",
                table: "TemplateQuestions");

            migrationBuilder.AlterColumn<int>(
                name: "SurveyTemplateId",
                table: "TemplateQuestions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "QuestionType",
                table: "TemplateQuestions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "QuestionText",
                table: "TemplateQuestions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<int>(
                name: "QuestionPosition",
                table: "TemplateQuestions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TemplateQuestionId",
                table: "TemplateChoices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ChoiceText",
                table: "TemplateChoices",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<int>(
                name: "ChoicePosition",
                table: "TemplateChoices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "TemplateName",
                table: "SurveyTemplates",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "SurveyTemplates",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "SurveyType",
                table: "SurveyObjects",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "SurveyTitle",
                table: "SurveyObjects",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "SurveyDescription",
                table: "SurveyObjects",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<int>(
                name: "SurveyObjectId",
                table: "Questions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "QuestionType",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "QuestionPosition",
                table: "Questions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "QuestionName",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "ChoiceText",
                table: "Choices",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<int>(
                name: "ChoicePosition",
                table: "Choices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionId",
                table: "Answers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "AnswerValue",
                table: "Answers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.InsertData(
                table: "SurveyTemplates",
                columns: new[] { "SurveyTemplateId", "Description", "TemplateName" },
                values: new object[,]
                {
                    { 1, "Gauge customer satisfaction with our cleaning services.", "Customer Satisfaction Survey" },
                    { 2, "Gather feedback from employees on the cleanliness of the workplace.", "Employee Feedback Survey" },
                    { 3, "Understand market needs and preferences for cleaning services.", "Market Research Survey" }
                });

            migrationBuilder.InsertData(
                table: "TemplateQuestions",
                columns: new[] { "TemplateQuestionId", "QuestionPosition", "QuestionText", "QuestionType", "SurveyTemplateId" },
                values: new object[,]
                {
                    { 1, null, "How satisfied are you with our cleaning services?", "single_choice", 1 },
                    { 2, null, "How likely are you to recommend our services to others?", "single_choice", 1 },
                    { 3, null, "How would you rate the cleanliness of your workspace?", "single_choice", 2 },
                    { 4, null, "Do you have any suggestions for improving our cleaning services?", "free_text", 2 },
                    { 5, null, "How often do you use professional cleaning services?", "single_choice", 3 },
                    { 6, null, "What factors influence your decision to hire a cleaning service?", "multiple_choice", 3 }
                });

            migrationBuilder.InsertData(
                table: "TemplateChoices",
                columns: new[] { "TemplateChoiceId", "ChoicePosition", "ChoiceText", "TemplateQuestionId" },
                values: new object[,]
                {
                    { 1, null, "Very Satisfied", 1 },
                    { 2, null, "Satisfied", 1 },
                    { 3, null, "Neutral", 1 },
                    { 4, null, "Dissatisfied", 1 },
                    { 5, null, "Very Dissatisfied", 1 },
                    { 6, null, "Very Likely", 2 },
                    { 7, null, "Likely", 2 },
                    { 8, null, "Neutral", 2 },
                    { 9, null, "Unlikely", 2 },
                    { 10, null, "Very Unlikely", 2 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Submissions_SubmissionId",
                table: "Answers",
                column: "SubmissionId",
                principalTable: "Submissions",
                principalColumn: "SubmissionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Choices_Questions_QuestionId",
                table: "Choices",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_SurveyObjects_SurveyObjectId",
                table: "Questions",
                column: "SurveyObjectId",
                principalTable: "SurveyObjects",
                principalColumn: "SurveyObjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Submissions_SurveyObjects_SurveyObjectId",
                table: "Submissions",
                column: "SurveyObjectId",
                principalTable: "SurveyObjects",
                principalColumn: "SurveyObjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyObjects_Users_UserId",
                table: "SurveyObjects",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TemplateChoices_TemplateQuestions_TemplateQuestionId",
                table: "TemplateChoices",
                column: "TemplateQuestionId",
                principalTable: "TemplateQuestions",
                principalColumn: "TemplateQuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_TemplateQuestions_SurveyTemplates_SurveyTemplateId",
                table: "TemplateQuestions",
                column: "SurveyTemplateId",
                principalTable: "SurveyTemplates",
                principalColumn: "SurveyTemplateId");
        }
    }
}
