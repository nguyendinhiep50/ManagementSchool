using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School_version1.Migrations
{
    public partial class data_init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicPrograms_Courses_IdCourese",
                table: "AcademicPrograms");

            migrationBuilder.DropForeignKey(
                name: "FK_AcademicPrograms_Semesters_IdSemester",
                table: "AcademicPrograms");

            migrationBuilder.DropForeignKey(
                name: "FK_AcademicPrograms_Subjects_IdSubject",
                table: "AcademicPrograms");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassLearns_AcademicPrograms_IdAcademicProgram",
                table: "ClassLearns");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassLearns_Teachers_IdTeacher",
                table: "ClassLearns");

            migrationBuilder.DropForeignKey(
                name: "FK_ListStudentClassLearns_ClassLearns_IdClassLearn",
                table: "ListStudentClassLearns");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Courses_IdCourse",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "IdCourse",
                table: "Students",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_IdCourse",
                table: "Students",
                newName: "IX_Students_CourseId");

            migrationBuilder.RenameColumn(
                name: "IdClassLearn",
                table: "ListStudentClassLearns",
                newName: "ClassLearnId");

            migrationBuilder.RenameIndex(
                name: "IX_ListStudentClassLearns_IdClassLearn",
                table: "ListStudentClassLearns",
                newName: "IX_ListStudentClassLearns_ClassLearnId");

            migrationBuilder.RenameColumn(
                name: "IdTeacher",
                table: "ClassLearns",
                newName: "TeacherId");

            migrationBuilder.RenameColumn(
                name: "IdAcademicProgram",
                table: "ClassLearns",
                newName: "AcademicProgramId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassLearns_IdTeacher",
                table: "ClassLearns",
                newName: "IX_ClassLearns_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassLearns_IdAcademicProgram",
                table: "ClassLearns",
                newName: "IX_ClassLearns_AcademicProgramId");

            migrationBuilder.RenameColumn(
                name: "IdSubject",
                table: "AcademicPrograms",
                newName: "SubjectId");

            migrationBuilder.RenameColumn(
                name: "IdSemester",
                table: "AcademicPrograms",
                newName: "SemesterId");

            migrationBuilder.RenameColumn(
                name: "IdCourese",
                table: "AcademicPrograms",
                newName: "CoureseId");

            migrationBuilder.RenameIndex(
                name: "IX_AcademicPrograms_IdSubject",
                table: "AcademicPrograms",
                newName: "IX_AcademicPrograms_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_AcademicPrograms_IdSemester",
                table: "AcademicPrograms",
                newName: "IX_AcademicPrograms_SemesterId");

            migrationBuilder.RenameIndex(
                name: "IX_AcademicPrograms_IdCourese",
                table: "AcademicPrograms",
                newName: "IX_AcademicPrograms_CoureseId");

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicPrograms_Courses_CoureseId",
                table: "AcademicPrograms",
                column: "CoureseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicPrograms_Semesters_SemesterId",
                table: "AcademicPrograms",
                column: "SemesterId",
                principalTable: "Semesters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicPrograms_Subjects_SubjectId",
                table: "AcademicPrograms",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassLearns_AcademicPrograms_AcademicProgramId",
                table: "ClassLearns",
                column: "AcademicProgramId",
                principalTable: "AcademicPrograms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassLearns_Teachers_TeacherId",
                table: "ClassLearns",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ListStudentClassLearns_ClassLearns_ClassLearnId",
                table: "ListStudentClassLearns",
                column: "ClassLearnId",
                principalTable: "ClassLearns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Courses_CourseId",
                table: "Students",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicPrograms_Courses_CoureseId",
                table: "AcademicPrograms");

            migrationBuilder.DropForeignKey(
                name: "FK_AcademicPrograms_Semesters_SemesterId",
                table: "AcademicPrograms");

            migrationBuilder.DropForeignKey(
                name: "FK_AcademicPrograms_Subjects_SubjectId",
                table: "AcademicPrograms");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassLearns_AcademicPrograms_AcademicProgramId",
                table: "ClassLearns");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassLearns_Teachers_TeacherId",
                table: "ClassLearns");

            migrationBuilder.DropForeignKey(
                name: "FK_ListStudentClassLearns_ClassLearns_ClassLearnId",
                table: "ListStudentClassLearns");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Courses_CourseId",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Students",
                newName: "IdCourse");

            migrationBuilder.RenameIndex(
                name: "IX_Students_CourseId",
                table: "Students",
                newName: "IX_Students_IdCourse");

            migrationBuilder.RenameColumn(
                name: "ClassLearnId",
                table: "ListStudentClassLearns",
                newName: "IdClassLearn");

            migrationBuilder.RenameIndex(
                name: "IX_ListStudentClassLearns_ClassLearnId",
                table: "ListStudentClassLearns",
                newName: "IX_ListStudentClassLearns_IdClassLearn");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "ClassLearns",
                newName: "IdTeacher");

            migrationBuilder.RenameColumn(
                name: "AcademicProgramId",
                table: "ClassLearns",
                newName: "IdAcademicProgram");

            migrationBuilder.RenameIndex(
                name: "IX_ClassLearns_TeacherId",
                table: "ClassLearns",
                newName: "IX_ClassLearns_IdTeacher");

            migrationBuilder.RenameIndex(
                name: "IX_ClassLearns_AcademicProgramId",
                table: "ClassLearns",
                newName: "IX_ClassLearns_IdAcademicProgram");

            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "AcademicPrograms",
                newName: "IdSubject");

            migrationBuilder.RenameColumn(
                name: "SemesterId",
                table: "AcademicPrograms",
                newName: "IdSemester");

            migrationBuilder.RenameColumn(
                name: "CoureseId",
                table: "AcademicPrograms",
                newName: "IdCourese");

            migrationBuilder.RenameIndex(
                name: "IX_AcademicPrograms_SubjectId",
                table: "AcademicPrograms",
                newName: "IX_AcademicPrograms_IdSubject");

            migrationBuilder.RenameIndex(
                name: "IX_AcademicPrograms_SemesterId",
                table: "AcademicPrograms",
                newName: "IX_AcademicPrograms_IdSemester");

            migrationBuilder.RenameIndex(
                name: "IX_AcademicPrograms_CoureseId",
                table: "AcademicPrograms",
                newName: "IX_AcademicPrograms_IdCourese");

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicPrograms_Courses_IdCourese",
                table: "AcademicPrograms",
                column: "IdCourese",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicPrograms_Semesters_IdSemester",
                table: "AcademicPrograms",
                column: "IdSemester",
                principalTable: "Semesters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicPrograms_Subjects_IdSubject",
                table: "AcademicPrograms",
                column: "IdSubject",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassLearns_AcademicPrograms_IdAcademicProgram",
                table: "ClassLearns",
                column: "IdAcademicProgram",
                principalTable: "AcademicPrograms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassLearns_Teachers_IdTeacher",
                table: "ClassLearns",
                column: "IdTeacher",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ListStudentClassLearns_ClassLearns_IdClassLearn",
                table: "ListStudentClassLearns",
                column: "IdClassLearn",
                principalTable: "ClassLearns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Courses_IdCourse",
                table: "Students",
                column: "IdCourse",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
