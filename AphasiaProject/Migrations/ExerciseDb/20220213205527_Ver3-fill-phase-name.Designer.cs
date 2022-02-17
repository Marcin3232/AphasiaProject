﻿// <auto-generated />
using System;
using AphasiaProject.Models.DB.Exercises;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AphasiaProject.Migrations.ExerciseDb
{
    [DbContext(typeof(ExerciseDbContext))]
    [Migration("20220213205527_Ver3-fill-phase-name")]
    partial class Ver3fillphasename
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("AphasiaProject.Models.Exercises.ExerciseKindModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("ExerciseKindNameId")
                        .HasColumnType("integer");

                    b.Property<int?>("ExerciseTypeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseKindNameId");

                    b.HasIndex("ExerciseTypeId");

                    b.ToTable("ExerciseKind");
                });

            modelBuilder.Entity("AphasiaProject.Models.Exercises.ExerciseKindNameModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ExerciseKindName");
                });

            modelBuilder.Entity("AphasiaProject.Models.Exercises.ExerciseModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("ExerciseNameId")
                        .HasColumnType("integer");

                    b.Property<int>("IdUser")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseNameId");

                    b.ToTable("Exercise");
                });

            modelBuilder.Entity("AphasiaProject.Models.Exercises.ExerciseNameModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("IdExerciseTask")
                        .HasColumnType("text");

                    b.Property<string>("ImageSrc")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ExerciseName");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "\"Exercise01\", // Gesty: tak nie",
                            IdExerciseTask = "01",
                            ImageSrc = "exercises/exercise-icons/exercise01",
                            Name = " Gesty: tak nie"
                        },
                        new
                        {
                            Id = 2,
                            Description = "\"Exercise02\", // Zestaw ćwiczeń narządów mowy",
                            IdExerciseTask = "02",
                            ImageSrc = "exercises/exercise-icons/exercise02",
                            Name = " Zestaw ćwiczeń narządów mowy"
                        },
                        new
                        {
                            Id = 3,
                            Description = "\"Exercise05\", // Cyfry",
                            IdExerciseTask = "05",
                            ImageSrc = "exercises/exercise-icons/exercise05",
                            Name = " Cyfry"
                        },
                        new
                        {
                            Id = 4,
                            Description = "\"Exercise07\", // Rzeczowniki",
                            IdExerciseTask = "07",
                            ImageSrc = "exercises/exercise-icons/exercise07",
                            Name = " Rzeczowniki"
                        },
                        new
                        {
                            Id = 5,
                            Description = "\"Exercise08\", // Czynności",
                            IdExerciseTask = "08",
                            ImageSrc = "exercises/exercise-icons/exercise08",
                            Name = " Czynności"
                        },
                        new
                        {
                            Id = 6,
                            Description = "\"Exercise09\", // Co robi? Malarz maluje",
                            IdExerciseTask = "09",
                            ImageSrc = "exercises/exercise-icons/exercise09",
                            Name = " Co robi? Malarz maluje"
                        },
                        new
                        {
                            Id = 7,
                            Description = "\"Exercise10\", // Przeciwieństwa",
                            IdExerciseTask = "10",
                            ImageSrc = "exercises/exercise-icons/exercise10",
                            Name = " Przeciwieństwa"
                        },
                        new
                        {
                            Id = 8,
                            Description = "\"Exercise12\", // Kolory",
                            IdExerciseTask = "12",
                            ImageSrc = "exercises/exercise-icons/exercise12",
                            Name = " Kolory"
                        },
                        new
                        {
                            Id = 9,
                            Description = "\"Exercise13\", // Czas: Pory roku",
                            IdExerciseTask = "13",
                            ImageSrc = "exercises/exercise-icons/exercise13",
                            Name = " Czas: Pory roku"
                        },
                        new
                        {
                            Id = 10,
                            Description = "\"Exercise14\", // Odnajdywanie Słów: dobór czasownika",
                            IdExerciseTask = "14",
                            ImageSrc = "exercises/exercise-icons/exercise14",
                            Name = " Odnajdywanie Słów: dobór czasownika"
                        },
                        new
                        {
                            Id = 11,
                            Description = "\"Exercise15\", // Określanie czynności",
                            IdExerciseTask = "15",
                            ImageSrc = "exercises/exercise-icons/exercise15",
                            Name = " Określanie czynności"
                        },
                        new
                        {
                            Id = 12,
                            Description = "\"Exercise16\", // Określenia dla przedmiotów/ osób",
                            IdExerciseTask = "16",
                            ImageSrc = "exercises/exercise-icons/exercise16",
                            Name = " Określenia dla przedmiotów/ osób"
                        },
                        new
                        {
                            Id = 13,
                            Description = "\"Exercise17\", // Jaka? Jaki? Jakie?",
                            IdExerciseTask = "17",
                            ImageSrc = "exercises/exercise-icons/exercise17",
                            Name = " Jaka? Jaki? Jakie?"
                        },
                        new
                        {
                            Id = 14,
                            Description = "\"Exercise18\", // Odmiana wyrazów",
                            IdExerciseTask = "18",
                            ImageSrc = "exercises/exercise-icons/exercise18",
                            Name = " Odmiana wyrazów"
                        },
                        new
                        {
                            Id = 15,
                            Description = "\"Exercise19\", // Sylaby i słowa",
                            IdExerciseTask = "19",
                            ImageSrc = "exercises/exercise-icons/exercise19",
                            Name = " Sylaby i słowa"
                        },
                        new
                        {
                            Id = 16,
                            Description = "\"Exercise20\", // Rozumienie wypowiedzi",
                            IdExerciseTask = "20",
                            ImageSrc = "exercises/exercise-icons/exercise20",
                            Name = " Rozumienie wypowiedzi"
                        },
                        new
                        {
                            Id = 17,
                            Description = "\"Exercise21\", // Grupowanie",
                            IdExerciseTask = "21",
                            ImageSrc = "exercises/exercise-icons/exercise21",
                            Name = " Grupowanie"
                        },
                        new
                        {
                            Id = 18,
                            Description = "\"Exercise22\", // Dźwięki otoczenia",
                            IdExerciseTask = "22",
                            ImageSrc = "exercises/exercise-icons/exercise22",
                            Name = " Dźwięki otoczenia"
                        },
                        new
                        {
                            Id = 19,
                            Description = "\"Exercise23\", // Przestrzeń: gdzie jest?",
                            IdExerciseTask = "23",
                            ImageSrc = "exercises/exercise-icons/exercise23",
                            Name = " Przestrzeń: gdzie jest?"
                        },
                        new
                        {
                            Id = 20,
                            Description = "\"Exercise24\", // Szukanie i układanie",
                            IdExerciseTask = "24",
                            ImageSrc = "exercises/exercise-icons/exercise24",
                            Name = " Szukanie i układanie"
                        },
                        new
                        {
                            Id = 21,
                            Description = "\"Exercise25\", // Rozbudowa zdań i czytanie",
                            IdExerciseTask = "25",
                            ImageSrc = "exercises/exercise-icons/exercise25",
                            Name = " Rozbudowa zdań i czytanie"
                        },
                        new
                        {
                            Id = 22,
                            Description = "\"Exercise26\", // Budowa zdań",
                            IdExerciseTask = "26",
                            ImageSrc = "exercises/exercise-icons/exercise26",
                            Name = " Budowa zdań"
                        },
                        new
                        {
                            Id = 23,
                            Description = "\"Exercise27\", // Odnajdywanie słów: dobór rzeczownika",
                            IdExerciseTask = "27",
                            ImageSrc = "exercises/exercise-icons/exercise27",
                            Name = " Odnajdywanie słów: dobór rzeczownika"
                        },
                        new
                        {
                            Id = 24,
                            Description = "\"Exercise28\", // Przysłowia",
                            IdExerciseTask = "28",
                            ImageSrc = "exercises/exercise-icons/exercise28",
                            Name = " Przysłowia"
                        },
                        new
                        {
                            Id = 25,
                            Description = "\"Exercise29\", // Opis sytuacji",
                            IdExerciseTask = "29",
                            ImageSrc = "exercises/exercise-icons/exercise29",
                            Name = " Opis sytuacji"
                        },
                        new
                        {
                            Id = 26,
                            Description = "\"Exercise30\", // Łączenie zdań",
                            IdExerciseTask = "30",
                            ImageSrc = "exercises/exercise-icons/exercise30",
                            Name = " Łączenie zdań"
                        },
                        new
                        {
                            Id = 27,
                            Description = "\"Exercise31\", // Czas: Kiedy? O której?",
                            IdExerciseTask = "31",
                            ImageSrc = "exercises/exercise-icons/exercise31",
                            Name = " Czas: Kiedy? O której?"
                        },
                        new
                        {
                            Id = 28,
                            Description = "\"Exercise32\", // Co słyszysz? Głoski, sylaby, słowa",
                            IdExerciseTask = "32",
                            ImageSrc = "exercises/exercise-icons/exercise32",
                            Name = " Co słyszysz? Głoski, sylaby, słowa"
                        },
                        new
                        {
                            Id = 29,
                            Description = "\"Exercise33\", // Dni Tygodnia",
                            IdExerciseTask = "33",
                            ImageSrc = "exercises/exercise-icons/exercise33",
                            Name = " Dni Tygodnia"
                        },
                        new
                        {
                            Id = 30,
                            Description = "\"Exercise34\", // Miesiące",
                            IdExerciseTask = "34",
                            ImageSrc = "exercises/exercise-icons/exercise34",
                            Name = " Miesiące"
                        },
                        new
                        {
                            Id = 31,
                            Description = "\"Exercise41\", // Powiedzenia",
                            IdExerciseTask = "41",
                            ImageSrc = "exercises/exercise-icons/exercise41",
                            Name = " Powiedzenia"
                        },
                        new
                        {
                            Id = 32,
                            Description = "\"Exercise42\", // Muzykoterapia",
                            IdExerciseTask = "42",
                            ImageSrc = "exercises/exercise-icons/exercise42",
                            Name = " Muzykoterapia"
                        },
                        new
                        {
                            Id = 33,
                            Description = "\"Exercise50\", // Ćwiczenia obsługi myszy",
                            IdExerciseTask = "50",
                            ImageSrc = "exercises/exercise-icons/exercise50",
                            Name = " Ćwiczenia obsługi myszy"
                        });
                });

            modelBuilder.Entity("AphasiaProject.Models.Exercises.ExercisePhaseModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ExerciseId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<int>("KindId")
                        .HasColumnType("integer");

                    b.Property<int?>("PhaseNameId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PhaseNameId");

                    b.ToTable("ExercisePhase");
                });

            modelBuilder.Entity("AphasiaProject.Models.Exercises.ExercisePhaseNameModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ExercisePhaseName");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Faza 1 charakteryzuje się umiarkowaną trudnością. W jej trakcie osoba rehabilitowana przypomina sobie i aktualizuje nazwy przedmiotów, czynności, uczuć, nazw języka codziennego. Proces ten ma charakter przekazu polisensorycznego poprzez obraz, słowo pisane oraz głos lektora. Podczas tej fazy nie jest wymagana interakcja pacjenta z oprogramowaniem.",
                            Name = "Nauka"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Faza 2 charakteryzuje się umiarkowaną trudnością. Podczas tej fazy osoba rehabilitowana proszona jest o wykonanie polecenia (np. wskazanie, dopasowanie, powtórzenie). Celem tej fazy jest poprawa sprawności narządów artykulacyjnych, wyćwiczenie percepcji i pamięci słuchowej oraz przywrócenie umiejętności fonacyjnych i artykulacyjnych. W ramach tej fazy na poszczególnych ekranach aplikacji umieszczone są podpisy i ułatwienia dla pacjenta.",
                            Name = "Powtarzanie"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Faza  charakteryzuje się wysoką trudnością. Podczas tej fazy pacjent proszony jest o wykonanie polecenia (np. wskazanie, nazwanie, dopasowanie, powtórzenie, ułożenie w odpowiedniej kolejności), jednakże nie otrzymuje podpowiedzi. Celem tej fazy jest wzmocnienie oraz ćwiczenie wiedzy i umiejętności zdobytych podczas fazy 1 oraz 2.",
                            Name = "Rozumienie"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Faza  charakteryzuje się umiarkowaną trudnością. W jej trakcie osoba rehabilitowana przypomina sobie i aktualizuje nazwy przedmiotów, czynności, uczuć, nazw języka codziennego. Proces ten ma charakter przekazu polisensorycznego poprzez obraz, słowo pisane oraz głos lektora.",
                            Name = "Nazywanie"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Faza  charakteryzuje się wysoką trudnością.Podczas tej fazy pacjent proszony jest o wykonanie polecenia (np.wskazanie, nazwanie, dopasowanie, powtórzenie, ułożenie w odpowiedniej kolejności), jednakże nie otrzymuje podpowiedzi.Celem tej fazy jest wzmocnienie oraz ćwiczenie wiedzy i umiejętności zdobytych podczas fazy 1 oraz 2.",
                            Name = "Zaawansowane"
                        });
                });

            modelBuilder.Entity("AphasiaProject.Models.Exercises.ExerciseTypeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("ExerciseTypeNameId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseTypeNameId");

                    b.ToTable("ExerciseType");
                });

            modelBuilder.Entity("AphasiaProject.Models.Exercises.ExerciseTypeNameModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ExerciseTypeName");
                });

            modelBuilder.Entity("AphasiaProject.Models.Exercises.ExerciseKindModel", b =>
                {
                    b.HasOne("AphasiaProject.Models.Exercises.ExerciseKindNameModel", "ExerciseKindName")
                        .WithMany()
                        .HasForeignKey("ExerciseKindNameId");

                    b.HasOne("AphasiaProject.Models.Exercises.ExerciseTypeModel", "ExerciseType")
                        .WithMany()
                        .HasForeignKey("ExerciseTypeId");

                    b.Navigation("ExerciseKindName");

                    b.Navigation("ExerciseType");
                });

            modelBuilder.Entity("AphasiaProject.Models.Exercises.ExerciseModel", b =>
                {
                    b.HasOne("AphasiaProject.Models.Exercises.ExerciseNameModel", "ExerciseName")
                        .WithMany()
                        .HasForeignKey("ExerciseNameId");

                    b.Navigation("ExerciseName");
                });

            modelBuilder.Entity("AphasiaProject.Models.Exercises.ExercisePhaseModel", b =>
                {
                    b.HasOne("AphasiaProject.Models.Exercises.ExercisePhaseNameModel", "PhaseName")
                        .WithMany()
                        .HasForeignKey("PhaseNameId");

                    b.Navigation("PhaseName");
                });

            modelBuilder.Entity("AphasiaProject.Models.Exercises.ExerciseTypeModel", b =>
                {
                    b.HasOne("AphasiaProject.Models.Exercises.ExerciseTypeNameModel", "ExerciseTypeName")
                        .WithMany()
                        .HasForeignKey("ExerciseTypeNameId");

                    b.Navigation("ExerciseTypeName");
                });
#pragma warning restore 612, 618
        }
    }
}
