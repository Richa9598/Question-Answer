using Microsoft.EntityFrameworkCore.Migrations;

namespace Richa_Que_Ans.Migrations
{
    public partial class Richa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    AnswerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionID = table.Column<int>(nullable: false),
                    AnswerText = table.Column<string>(nullable: false),
                    AnswerDateAndTime = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.AnswerID);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionName = table.Column<string>(nullable: false),
                    QuestionDateAndTime = table.Column<string>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionID);
                    table.ForeignKey(
                        name: "FK_Questions_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "AnswerID", "AnswerDateAndTime", "AnswerText", "QuestionID" },
                values: new object[,]
                {
                    { 1, "11/24/2021 10:30:25 PM", "wake up early and do atleat 30 min exercise", 1 },
                    { 2, "11/22/2021 10:30:25 AM", "Eat healthy food in the mornings", 2 },
                    { 3, "05/10/2021 08:00:40 AM", "I learned dancing as an extra activity", 3 }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "Name" },
                values: new object[,]
                {
                    { 1, "Health" },
                    { 2, "Diet" },
                    { 3, "Arts" }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "QuestionID", "CategoryID", "QuestionDateAndTime", "QuestionName" },
                values: new object[] { 1, 1, "11/04/2022 01:30:25 PM", "What is the best Time to do exercise in morning ?" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "QuestionID", "CategoryID", "QuestionDateAndTime", "QuestionName" },
                values: new object[] { 2, 2, "10/04/2022 16:50:25 AM", "What type of food is best ?" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "QuestionID", "CategoryID", "QuestionDateAndTime", "QuestionName" },
                values: new object[] { 3, 3, "03/04/2021 05:00:40 PM", "You do any external activities?" });

            migrationBuilder.CreateIndex(
                name: "IX_Questions_CategoryID",
                table: "Questions",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
