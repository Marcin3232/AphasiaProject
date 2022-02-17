using Microsoft.EntityFrameworkCore.Migrations;

namespace AphasiaProject.Migrations.ExerciseDb
{
    public partial class Changekindandtyperelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseKind_ExerciseType_ExerciseTypeId",
                table: "ExerciseKind");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseKind_ExerciseTypeId",
                table: "ExerciseKind");

            migrationBuilder.DropColumn(
                name: "KindId",
                table: "ExercisePhase");

            migrationBuilder.DropColumn(
                name: "ExerciseTypeId",
                table: "ExerciseKind");

            migrationBuilder.AddColumn<int>(
                name: "ExerciseKindId",
                table: "ExercisePhase",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExerciseTypeId",
                table: "ExercisePhase",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExercisePhase_ExerciseKindId",
                table: "ExercisePhase",
                column: "ExerciseKindId");

            migrationBuilder.CreateIndex(
                name: "IX_ExercisePhase_ExerciseTypeId",
                table: "ExercisePhase",
                column: "ExerciseTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExercisePhase_ExerciseKind_ExerciseKindId",
                table: "ExercisePhase",
                column: "ExerciseKindId",
                principalTable: "ExerciseKind",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExercisePhase_ExerciseType_ExerciseTypeId",
                table: "ExercisePhase",
                column: "ExerciseTypeId",
                principalTable: "ExerciseType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExercisePhase_ExerciseKind_ExerciseKindId",
                table: "ExercisePhase");

            migrationBuilder.DropForeignKey(
                name: "FK_ExercisePhase_ExerciseType_ExerciseTypeId",
                table: "ExercisePhase");

            migrationBuilder.DropIndex(
                name: "IX_ExercisePhase_ExerciseKindId",
                table: "ExercisePhase");

            migrationBuilder.DropIndex(
                name: "IX_ExercisePhase_ExerciseTypeId",
                table: "ExercisePhase");

            migrationBuilder.DropColumn(
                name: "ExerciseKindId",
                table: "ExercisePhase");

            migrationBuilder.DropColumn(
                name: "ExerciseTypeId",
                table: "ExercisePhase");

            migrationBuilder.AddColumn<int>(
                name: "KindId",
                table: "ExercisePhase",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExerciseTypeId",
                table: "ExerciseKind",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseKind_ExerciseTypeId",
                table: "ExerciseKind",
                column: "ExerciseTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseKind_ExerciseType_ExerciseTypeId",
                table: "ExerciseKind",
                column: "ExerciseTypeId",
                principalTable: "ExerciseType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
