﻿// <auto-generated />
using System;
using DataBaseProject.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataBaseProject.Migrations
{
    [DbContext(typeof(ExerciseDbContext))]
    [Migration("20220704203236_userExerciseTables")]
    partial class userExerciseTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DataBaseProject.Models.Exercise.AphasiaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AphasiaType")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Aphasia");
                });

            modelBuilder.Entity("DataBaseProject.Models.Exercise.ExerciseKindModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ExerciseKindNameId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseKindNameId");

                    b.ToTable("ExerciseKind");
                });

            modelBuilder.Entity("DataBaseProject.Models.Exercise.ExerciseKindNameModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Kind")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SoundSrc")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ExerciseKindName");
                });

            modelBuilder.Entity("DataBaseProject.Models.Exercise.ExerciseModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("AphasiaId")
                        .HasColumnType("integer");

                    b.Property<int>("ExerciseNameId")
                        .HasColumnType("integer");

                    b.Property<int>("IdUser")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<int>("Order")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AphasiaId");

                    b.HasIndex("ExerciseNameId");

                    b.ToTable("Exercise");
                });

            modelBuilder.Entity("DataBaseProject.Models.Exercise.ExerciseNameModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IdExerciseTask")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageSrc")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ExerciseName");
                });

            modelBuilder.Entity("DataBaseProject.Models.Exercise.ExercisePhaseModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ExerciseId")
                        .HasColumnType("integer");

                    b.Property<int>("ExerciseKindId")
                        .HasColumnType("integer");

                    b.Property<int>("ExerciseTypeId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsHelper")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsSoundEveryStep")
                        .HasColumnType("boolean");

                    b.Property<int>("PhaseNameId")
                        .HasColumnType("integer");

                    b.Property<int>("Repeat")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseKindId");

                    b.HasIndex("ExerciseTypeId");

                    b.HasIndex("PhaseNameId");

                    b.ToTable("ExercisePhase");
                });

            modelBuilder.Entity("DataBaseProject.Models.Exercise.ExercisePhaseNameModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ExercisePhaseName");
                });

            modelBuilder.Entity("DataBaseProject.Models.Exercise.ExerciseTypeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ExerciseTypeNameId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseTypeNameId");

                    b.ToTable("ExerciseType");
                });

            modelBuilder.Entity("DataBaseProject.Models.Exercise.ExerciseTypeNameModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("ExerciseTypeName");
                });

            modelBuilder.Entity("DataBaseProject.Models.ExerciseHistory.ExerciseHistoryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long?>("ExecutionTime")
                        .HasColumnType("bigint");

                    b.Property<int>("ExerciseId")
                        .HasColumnType("integer");

                    b.Property<int>("ExercisePhaseId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("ExerciseHistory");
                });

            modelBuilder.Entity("DataBaseProject.Models.ExerciseHistory.HistoryResultDetailsModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Answers")
                        .HasColumnType("integer");

                    b.Property<int>("CorrectAnswers")
                        .HasColumnType("integer");

                    b.Property<int>("CorrectClicks")
                        .HasColumnType("integer");

                    b.Property<int?>("ExerciseHistoryModelId")
                        .HasColumnType("integer");

                    b.Property<int>("TipClicks")
                        .HasColumnType("integer");

                    b.Property<int>("WrongClicks")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseHistoryModelId");

                    b.ToTable("HistoryResultDetails");
                });

            modelBuilder.Entity("DataBaseProject.Models.UserExercise.UserAphasiaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AphasiaId")
                        .HasColumnType("integer");

                    b.Property<int>("IdUser")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("AphasiaId");

                    b.ToTable("UserAphasia");
                });

            modelBuilder.Entity("DataBaseProject.Models.UserExercise.UserExerciseModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ExerciseId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<int>("UserAphasiaId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("UserAphasiaId");

                    b.ToTable("UserExercise");
                });

            modelBuilder.Entity("DataBaseProject.Models.UserExercise.UserPhaseExerciseModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ExercisePhaseId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<int>("UserExerciseId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ExercisePhaseId");

                    b.HasIndex("UserExerciseId");

                    b.ToTable("UserPhaseExercise");
                });

            modelBuilder.Entity("DataBaseProject.Models.Exercise.ExerciseKindModel", b =>
                {
                    b.HasOne("DataBaseProject.Models.Exercise.ExerciseKindNameModel", "ExerciseKindName")
                        .WithMany()
                        .HasForeignKey("ExerciseKindNameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExerciseKindName");
                });

            modelBuilder.Entity("DataBaseProject.Models.Exercise.ExerciseModel", b =>
                {
                    b.HasOne("DataBaseProject.Models.Exercise.AphasiaModel", "Aphasia")
                        .WithMany()
                        .HasForeignKey("AphasiaId");

                    b.HasOne("DataBaseProject.Models.Exercise.ExerciseNameModel", "ExerciseName")
                        .WithMany()
                        .HasForeignKey("ExerciseNameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aphasia");

                    b.Navigation("ExerciseName");
                });

            modelBuilder.Entity("DataBaseProject.Models.Exercise.ExercisePhaseModel", b =>
                {
                    b.HasOne("DataBaseProject.Models.Exercise.ExerciseKindModel", "ExerciseKind")
                        .WithMany()
                        .HasForeignKey("ExerciseKindId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataBaseProject.Models.Exercise.ExerciseTypeModel", "ExerciseType")
                        .WithMany()
                        .HasForeignKey("ExerciseTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataBaseProject.Models.Exercise.ExercisePhaseNameModel", "PhaseName")
                        .WithMany()
                        .HasForeignKey("PhaseNameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExerciseKind");

                    b.Navigation("ExerciseType");

                    b.Navigation("PhaseName");
                });

            modelBuilder.Entity("DataBaseProject.Models.Exercise.ExerciseTypeModel", b =>
                {
                    b.HasOne("DataBaseProject.Models.Exercise.ExerciseTypeNameModel", "ExerciseTypeName")
                        .WithMany()
                        .HasForeignKey("ExerciseTypeNameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExerciseTypeName");
                });

            modelBuilder.Entity("DataBaseProject.Models.ExerciseHistory.HistoryResultDetailsModel", b =>
                {
                    b.HasOne("DataBaseProject.Models.ExerciseHistory.ExerciseHistoryModel", null)
                        .WithMany("HistoryResultDetails")
                        .HasForeignKey("ExerciseHistoryModelId");
                });

            modelBuilder.Entity("DataBaseProject.Models.UserExercise.UserAphasiaModel", b =>
                {
                    b.HasOne("DataBaseProject.Models.Exercise.AphasiaModel", "Aphasia")
                        .WithMany()
                        .HasForeignKey("AphasiaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aphasia");
                });

            modelBuilder.Entity("DataBaseProject.Models.UserExercise.UserExerciseModel", b =>
                {
                    b.HasOne("DataBaseProject.Models.Exercise.ExerciseModel", "Exercise")
                        .WithMany()
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataBaseProject.Models.UserExercise.UserAphasiaModel", "UserAphasia")
                        .WithMany()
                        .HasForeignKey("UserAphasiaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("UserAphasia");
                });

            modelBuilder.Entity("DataBaseProject.Models.UserExercise.UserPhaseExerciseModel", b =>
                {
                    b.HasOne("DataBaseProject.Models.Exercise.ExercisePhaseModel", "ExercisePhase")
                        .WithMany()
                        .HasForeignKey("ExercisePhaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataBaseProject.Models.UserExercise.UserExerciseModel", "UserExercise")
                        .WithMany()
                        .HasForeignKey("UserExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExercisePhase");

                    b.Navigation("UserExercise");
                });

            modelBuilder.Entity("DataBaseProject.Models.ExerciseHistory.ExerciseHistoryModel", b =>
                {
                    b.Navigation("HistoryResultDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
