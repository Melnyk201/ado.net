using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleApp1.Migrations
{
    public partial class six : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeachersId",
                table: "TeacherSubjects",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSubjects_SubjectId",
                table: "TeacherSubjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSubjects_TeachersId",
                table: "TeacherSubjects",
                column: "TeachersId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjectRate_StudentId",
                table: "StudentSubjectRate",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjectRate_SubjectId",
                table: "StudentSubjectRate",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubjectRate_Student_StudentId",
                table: "StudentSubjectRate",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubjectRate_Subjects_SubjectId",
                table: "StudentSubjectRate",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherSubjects_Subjects_SubjectId",
                table: "TeacherSubjects",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherSubjects_Teachers_TeachersId",
                table: "TeacherSubjects",
                column: "TeachersId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubjectRate_Student_StudentId",
                table: "StudentSubjectRate");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubjectRate_Subjects_SubjectId",
                table: "StudentSubjectRate");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherSubjects_Subjects_SubjectId",
                table: "TeacherSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherSubjects_Teachers_TeachersId",
                table: "TeacherSubjects");

            migrationBuilder.DropIndex(
                name: "IX_TeacherSubjects_SubjectId",
                table: "TeacherSubjects");

            migrationBuilder.DropIndex(
                name: "IX_TeacherSubjects_TeachersId",
                table: "TeacherSubjects");

            migrationBuilder.DropIndex(
                name: "IX_StudentSubjectRate_StudentId",
                table: "StudentSubjectRate");

            migrationBuilder.DropIndex(
                name: "IX_StudentSubjectRate_SubjectId",
                table: "StudentSubjectRate");

            migrationBuilder.DropColumn(
                name: "TeachersId",
                table: "TeacherSubjects");
        }
    }
}
