using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataBaseProject.Migrations
{
    public partial class userExerciseTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserAphasia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdUser = table.Column<int>(type: "integer", nullable: false),
                    AphasiaId = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAphasia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAphasia_Aphasia_AphasiaId",
                        column: x => x.AphasiaId,
                        principalTable: "Aphasia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserExercise",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExerciseId = table.Column<int>(type: "integer", nullable: false),
                    UserAphasiaId = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserExercise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserExercise_Exercise_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserExercise_UserAphasia_UserAphasiaId",
                        column: x => x.UserAphasiaId,
                        principalTable: "UserAphasia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPhaseExercise",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExercisePhaseId = table.Column<int>(type: "integer", nullable: false),
                    UserExerciseId = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPhaseExercise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPhaseExercise_ExercisePhase_ExercisePhaseId",
                        column: x => x.ExercisePhaseId,
                        principalTable: "ExercisePhase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPhaseExercise_UserExercise_UserExerciseId",
                        column: x => x.UserExerciseId,
                        principalTable: "UserExercise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAphasia_AphasiaId",
                table: "UserAphasia",
                column: "AphasiaId");

            migrationBuilder.CreateIndex(
                name: "IX_UserExercise_ExerciseId",
                table: "UserExercise",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserExercise_UserAphasiaId",
                table: "UserExercise",
                column: "UserAphasiaId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPhaseExercise_ExercisePhaseId",
                table: "UserPhaseExercise",
                column: "ExercisePhaseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPhaseExercise_UserExerciseId",
                table: "UserPhaseExercise",
                column: "UserExerciseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserPhaseExercise");

            migrationBuilder.DropTable(
                name: "UserExercise");

            migrationBuilder.DropTable(
                name: "UserAphasia");
        }
    }
}
