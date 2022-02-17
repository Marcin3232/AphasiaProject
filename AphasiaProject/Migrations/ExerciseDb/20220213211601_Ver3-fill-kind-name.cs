using Microsoft.EntityFrameworkCore.Migrations;

namespace AphasiaProject.Migrations.ExerciseDb
{
    public partial class Ver3fillkindname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ExerciseKindName",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "", "Posłuchaj i Zapamiętaj" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExerciseKindName",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
