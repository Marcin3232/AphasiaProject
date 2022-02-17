using Microsoft.EntityFrameworkCore.Migrations;

namespace AphasiaProject.Migrations.ExerciseDb
{
    public partial class Ver3fillkindname2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ExerciseKindName",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "...");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ExerciseKindName",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "");
        }
    }
}
