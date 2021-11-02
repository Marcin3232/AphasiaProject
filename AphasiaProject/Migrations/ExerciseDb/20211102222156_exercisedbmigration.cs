using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AphasiaProject.Migrations.ExerciseDb
{
    public partial class exercisedbmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExerciseName",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ImageSrc = table.Column<string>(type: "text", nullable: true),
                    IdExerciseTask = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseName", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ExerciseName",
                columns: new[] { "Id", "Description", "IdExerciseTask", "ImageSrc", "Name" },
                values: new object[,]
                {
                    { 1, "\"Exercise01\", // Gesty: tak nie", "01", "exercises/exercise-icons/exercise01", " Gesty: tak nie" },
                    { 31, "\"Exercise41\", // Powiedzenia", "41", "exercises/exercise-icons/exercise41", " Powiedzenia" },
                    { 30, "\"Exercise34\", // Miesiące", "34", "exercises/exercise-icons/exercise34", " Miesiące" },
                    { 29, "\"Exercise33\", // Dni Tygodnia", "33", "exercises/exercise-icons/exercise33", " Dni Tygodnia" },
                    { 28, "\"Exercise32\", // Co słyszysz? Głoski, sylaby, słowa", "32", "exercises/exercise-icons/exercise32", " Co słyszysz? Głoski, sylaby, słowa" },
                    { 27, "\"Exercise31\", // Czas: Kiedy? O której?", "31", "exercises/exercise-icons/exercise31", " Czas: Kiedy? O której?" },
                    { 26, "\"Exercise30\", // Łączenie zdań", "30", "exercises/exercise-icons/exercise30", " Łączenie zdań" },
                    { 25, "\"Exercise29\", // Opis sytuacji", "29", "exercises/exercise-icons/exercise29", " Opis sytuacji" },
                    { 24, "\"Exercise28\", // Przysłowia", "28", "exercises/exercise-icons/exercise28", " Przysłowia" },
                    { 23, "\"Exercise27\", // Odnajdywanie słów: dobór rzeczownika", "27", "exercises/exercise-icons/exercise27", " Odnajdywanie słów: dobór rzeczownika" },
                    { 22, "\"Exercise26\", // Budowa zdań", "26", "exercises/exercise-icons/exercise26", " Budowa zdań" },
                    { 21, "\"Exercise25\", // Rozbudowa zdań i czytanie", "25", "exercises/exercise-icons/exercise25", " Rozbudowa zdań i czytanie" },
                    { 20, "\"Exercise24\", // Szukanie i układanie", "24", "exercises/exercise-icons/exercise24", " Szukanie i układanie" },
                    { 19, "\"Exercise23\", // Przestrzeń: gdzie jest?", "23", "exercises/exercise-icons/exercise23", " Przestrzeń: gdzie jest?" },
                    { 18, "\"Exercise22\", // Dźwięki otoczenia", "22", "exercises/exercise-icons/exercise22", " Dźwięki otoczenia" },
                    { 32, "\"Exercise42\", // Muzykoterapia", "42", "exercises/exercise-icons/exercise42", " Muzykoterapia" },
                    { 17, "\"Exercise21\", // Grupowanie", "21", "exercises/exercise-icons/exercise21", " Grupowanie" },
                    { 15, "\"Exercise19\", // Sylaby i słowa", "19", "exercises/exercise-icons/exercise19", " Sylaby i słowa" },
                    { 14, "\"Exercise18\", // Odmiana wyrazów", "18", "exercises/exercise-icons/exercise18", " Odmiana wyrazów" },
                    { 13, "\"Exercise17\", // Jaka? Jaki? Jakie?", "17", "exercises/exercise-icons/exercise17", " Jaka? Jaki? Jakie?" },
                    { 12, "\"Exercise16\", // Określenia dla przedmiotów/ osób", "16", "exercises/exercise-icons/exercise16", " Określenia dla przedmiotów/ osób" },
                    { 11, "\"Exercise15\", // Określanie czynności", "15", "exercises/exercise-icons/exercise15", " Określanie czynności" },
                    { 10, "\"Exercise14\", // Odnajdywanie Słów: dobór", "14", "exercises/exercise-icons/exercise14", " Odnajdywanie Słów: dobór" },
                    { 9, "\"Exercise13\", // Czas: Pory roku", "13", "exercises/exercise-icons/exercise13", " Czas: Pory roku" },
                    { 8, "\"Exercise12\", // Kolory", "12", "exercises/exercise-icons/exercise12", " Kolory" },
                    { 7, "\"Exercise10\", // Przeciwieństwa", "10", "exercises/exercise-icons/exercise10", " Przeciwieństwa" },
                    { 6, "\"Exercise09\", // Co robi? Malarz maluje", "09", "exercises/exercise-icons/exercise09", " Co robi? Malarz maluje" },
                    { 5, "\"Exercise08\", // Czynności", "08", "exercises/exercise-icons/exercise08", " Czynności" },
                    { 4, "\"Exercise07\", // Rzeczowniki", "07", "exercises/exercise-icons/exercise07", " Rzeczowniki" },
                    { 3, "\"Exercise05\", // Cyfry", "05", "exercises/exercise-icons/exercise05", " Cyfry" },
                    { 2, "\"Exercise02\", // Zestaw ćwiczeń narządów mowy", "02", "exercises/exercise-icons/exercise02", " Zestaw ćwiczeń narządów mowy" },
                    { 16, "\"Exercise20\", // Rozumienie wypowiedzi", "20", "exercises/exercise-icons/exercise20", " Rozumienie wypowiedzi" },
                    { 33, "\"Exercise50\", // Ćwiczenia obsługi myszy", "50", "exercises/exercise-icons/exercise50", " Ćwiczenia obsługi myszy" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseName");
        }
    }
}
