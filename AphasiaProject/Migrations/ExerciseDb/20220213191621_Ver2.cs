using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AphasiaProject.Migrations.ExerciseDb
{
    public partial class Ver2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ExerciseName",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExerciseNameId = table.Column<int>(type: "integer", nullable: true),
                    IdUser = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercise_ExerciseName_ExerciseNameId",
                        column: x => x.ExerciseNameId,
                        principalTable: "ExerciseName",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseKindName",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseKindName", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExercisePhaseName",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExercisePhaseName", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseTypeName",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseTypeName", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExercisePhase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PhaseNameId = table.Column<int>(type: "integer", nullable: true),
                    ExerciseId = table.Column<int>(type: "integer", nullable: false),
                    KindId = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExercisePhase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExercisePhase_ExercisePhaseName_PhaseNameId",
                        column: x => x.PhaseNameId,
                        principalTable: "ExercisePhaseName",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExerciseTypeNameId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseType_ExerciseTypeName_ExerciseTypeNameId",
                        column: x => x.ExerciseTypeNameId,
                        principalTable: "ExerciseTypeName",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseKind",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExerciseKindNameId = table.Column<int>(type: "integer", nullable: true),
                    ExerciseTypeId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseKind", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseKind_ExerciseKindName_ExerciseKindNameId",
                        column: x => x.ExerciseKindNameId,
                        principalTable: "ExerciseKindName",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExerciseKind_ExerciseType_ExerciseTypeId",
                        column: x => x.ExerciseTypeId,
                        principalTable: "ExerciseType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "ExerciseName",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Description", "Name" },
                values: new object[] { "\"Exercise14\", // Odnajdywanie Słów: dobór czasownika", " Odnajdywanie Słów: dobór czasownika" });

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_ExerciseNameId",
                table: "Exercise",
                column: "ExerciseNameId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseKind_ExerciseKindNameId",
                table: "ExerciseKind",
                column: "ExerciseKindNameId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseKind_ExerciseTypeId",
                table: "ExerciseKind",
                column: "ExerciseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExercisePhase_PhaseNameId",
                table: "ExercisePhase",
                column: "PhaseNameId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseType_ExerciseTypeNameId",
                table: "ExerciseType",
                column: "ExerciseTypeNameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "ExerciseKind");

            migrationBuilder.DropTable(
                name: "ExercisePhase");

            migrationBuilder.DropTable(
                name: "ExerciseKindName");

            migrationBuilder.DropTable(
                name: "ExerciseType");

            migrationBuilder.DropTable(
                name: "ExercisePhaseName");

            migrationBuilder.DropTable(
                name: "ExerciseTypeName");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ExerciseName",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "ExerciseName",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Description", "Name" },
                values: new object[] { "\"Exercise14\", // Odnajdywanie Słów: dobór", " Odnajdywanie Słów: dobór" });
        }
    }
}
