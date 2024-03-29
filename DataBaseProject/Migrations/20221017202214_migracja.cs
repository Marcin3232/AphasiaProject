﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataBaseProject.Migrations
{
    public partial class migracja : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aphasia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    AphasiaType = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aphasia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExercisePhaseId = table.Column<int>(type: "integer", nullable: false),
                    ExerciseId = table.Column<int>(type: "integer", nullable: false),
                    ExecutionTime = table.Column<long>(type: "bigint", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseKindName",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Kind = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    SoundSrc = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseKindName", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseName",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ImageSrc = table.Column<string>(type: "text", nullable: false),
                    IdExerciseTask = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseName", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExercisePhaseName",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExercisePhaseName", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseResultHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Key = table.Column<string>(type: "text", nullable: false),
                    JsonValue = table.Column<string>(type: "text", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseResultHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseTypeName",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseTypeName", x => x.Id);
                });

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
                name: "HistoryResultDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Answers = table.Column<int>(type: "integer", nullable: false),
                    CorrectAnswers = table.Column<int>(type: "integer", nullable: false),
                    CorrectClicks = table.Column<int>(type: "integer", nullable: false),
                    WrongClicks = table.Column<int>(type: "integer", nullable: false),
                    TipClicks = table.Column<int>(type: "integer", nullable: false),
                    ExerciseHistoryModelId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryResultDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoryResultDetails_ExerciseHistory_ExerciseHistoryModelId",
                        column: x => x.ExerciseHistoryModelId,
                        principalTable: "ExerciseHistory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ExerciseKind",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExerciseKindNameId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseKind", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseKind_ExerciseKindName_ExerciseKindNameId",
                        column: x => x.ExerciseKindNameId,
                        principalTable: "ExerciseKindName",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExerciseNameId = table.Column<int>(type: "integer", nullable: false),
                    IdUser = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    AphasiaId = table.Column<int>(type: "integer", nullable: true),
                    Order = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercise_Aphasia_AphasiaId",
                        column: x => x.AphasiaId,
                        principalTable: "Aphasia",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Exercise_ExerciseName_ExerciseNameId",
                        column: x => x.ExerciseNameId,
                        principalTable: "ExerciseName",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExerciseTypeNameId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseType_ExerciseTypeName_ExerciseTypeNameId",
                        column: x => x.ExerciseTypeNameId,
                        principalTable: "ExerciseTypeName",
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
                name: "ExercisePhase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PhaseNameId = table.Column<int>(type: "integer", nullable: false),
                    ExerciseId = table.Column<int>(type: "integer", nullable: false),
                    ExerciseKindId = table.Column<int>(type: "integer", nullable: false),
                    ExerciseTypeId = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Repeat = table.Column<int>(type: "integer", nullable: false),
                    IsSoundEveryStep = table.Column<bool>(type: "boolean", nullable: false),
                    IsHelper = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExercisePhase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExercisePhase_ExerciseKind_ExerciseKindId",
                        column: x => x.ExerciseKindId,
                        principalTable: "ExerciseKind",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExercisePhase_ExercisePhaseName_PhaseNameId",
                        column: x => x.PhaseNameId,
                        principalTable: "ExercisePhaseName",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExercisePhase_ExerciseType_ExerciseTypeId",
                        column: x => x.ExerciseTypeId,
                        principalTable: "ExerciseType",
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
                name: "IX_Exercise_AphasiaId",
                table: "Exercise",
                column: "AphasiaId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_ExerciseNameId",
                table: "Exercise",
                column: "ExerciseNameId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseKind_ExerciseKindNameId",
                table: "ExerciseKind",
                column: "ExerciseKindNameId");

            migrationBuilder.CreateIndex(
                name: "IX_ExercisePhase_ExerciseKindId",
                table: "ExercisePhase",
                column: "ExerciseKindId");

            migrationBuilder.CreateIndex(
                name: "IX_ExercisePhase_ExerciseTypeId",
                table: "ExercisePhase",
                column: "ExerciseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExercisePhase_PhaseNameId",
                table: "ExercisePhase",
                column: "PhaseNameId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseType_ExerciseTypeNameId",
                table: "ExerciseType",
                column: "ExerciseTypeNameId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryResultDetails_ExerciseHistoryModelId",
                table: "HistoryResultDetails",
                column: "ExerciseHistoryModelId");

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
                name: "ExerciseResultHistory");

            migrationBuilder.DropTable(
                name: "HistoryResultDetails");

            migrationBuilder.DropTable(
                name: "UserPhaseExercise");

            migrationBuilder.DropTable(
                name: "ExerciseHistory");

            migrationBuilder.DropTable(
                name: "ExercisePhase");

            migrationBuilder.DropTable(
                name: "UserExercise");

            migrationBuilder.DropTable(
                name: "ExerciseKind");

            migrationBuilder.DropTable(
                name: "ExercisePhaseName");

            migrationBuilder.DropTable(
                name: "ExerciseType");

            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "UserAphasia");

            migrationBuilder.DropTable(
                name: "ExerciseKindName");

            migrationBuilder.DropTable(
                name: "ExerciseTypeName");

            migrationBuilder.DropTable(
                name: "ExerciseName");

            migrationBuilder.DropTable(
                name: "Aphasia");
        }
    }
}
