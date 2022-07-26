using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBaseProject.Migrations
{
    public partial class addNewColumnHistoryResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ExerciseResultHistory",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "ExerciseResultHistory",
                type: "timestamp with time zone",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ExerciseResultHistory");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "ExerciseResultHistory");
        }
    }
}
