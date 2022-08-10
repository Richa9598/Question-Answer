using Microsoft.EntityFrameworkCore.Migrations;

namespace Richa_Que_Ans.Migrations
{
    public partial class Assignment2 : Migration
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
                    { 1, "13/11/2021 012:00:00 PM", "Check the spelling and try again", 1 },
                    { 2, "23/02/2020  09:30:40 AM", "use the URL() to insert the background image", 2 },
                    { 3, "11/03/2021 10:00:25 AM", "Use the menu option to set the title bar", 3 }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "Name" },
                values: new object[,]
                {
                    { 1, "HTML" },
                    { 2, "CSS" },
                    { 3, "JavaScript" }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "QuestionID", "CategoryID", "QuestionDateAndTime", "QuestionName" },
                values: new object[] { 1, 1, "11/03/2021 10:00:25 AM", "document.getElementByID() is not working" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "QuestionID", "CategoryID", "QuestionDateAndTime", "QuestionName" },
                values: new object[] { 2, 2, "23/02/2020  09:30:40 AM", "How to check background image in CSS" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "QuestionID", "CategoryID", "QuestionDateAndTime", "QuestionName" },
                values: new object[] { 3, 3, "13/11/2021 012:00:00 PM", "How to display icon the browser title bar using HTML" });

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
