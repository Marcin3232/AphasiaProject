using Dapper;
using DataBaseProject.Context;
using DataBaseProject.Data.Exercises;
using DataBaseProject.Enums.Db;
using DataBaseProject.Models.Exercise;
using DataBaseProject.Utils;
using DataBaseQuery.Exercise;
using DataBaseQuery.ModelHelper;
using Npgsql;
using System.Data;

namespace DataBaseProject.Services
{
    internal class FillExerciseDbService
    {
        public void Fill()
        {
            var exerciseData = new ExerciseData();
            var exerciseNames = ExerciseNameData.ExerciseNameList();
            var exercises = exerciseData.GetFilled();
            var aphasiaData = new AphasiaData().GetFilled();
            
            using (var context = new ExerciseDbContext())
            {
                context.AddRange(aphasiaData);
                context.SaveChanges();
                exerciseNames.ForEach(x =>
                {
                    InsertOrUpdateExerciseName(context, x).GetAwaiter().GetResult();
                });

                Console.WriteLine($"{DateTime.Now} || INFO: Finish exercise name.");


                exercises.ForEach(x =>
                {
                    InsertOrUpdateExercise(context, x).GetAwaiter().GetResult();
                });

                Console.WriteLine($"{DateTime.Now} || INFO: Finish exercises.");
            }
        }

        private async Task InsertOrUpdateExerciseName(ExerciseDbContext context, ExerciseNameModel name)
        {
            var helper = CreateName(name);

            using (IDbConnection conn = new NpgsqlConnection(ConnectionString.Get(DbConnectionsString.DbAphasia)))
            {
                DbConnection.Open(conn);
                using var transaction = conn.BeginTransaction();
                try
                {
                    if (context.ExerciseNames.Any(y => y.Id == name.Id))
                    {
                        var result = await conn.ExecuteAsync(
                            ExerciseNameAddOrUpdateQuery.UpdateExerciseName(),
                            helper, transaction, commandType: CommandType.Text);

                        if (result == 0)
                        {
                            Console.WriteLine($"{DateTime.Now} || ERROR: Cant update exercise name. Name id: {name.Id}");
                            transaction.Rollback();
                        }
                        else
                        {
                            Console.WriteLine($"{DateTime.Now} || INFO: Finish update exercise name. Id:{name.Id}");
                            transaction.Commit();
                        }
                    }
                    else
                    {
                        var result = await conn.ExecuteScalarAsync<int>(ExerciseNameAddOrUpdateQuery.InsertExerciseName(),
                            helper, transaction, commandType: CommandType.Text);
                        if (result == 0)
                        {
                            Console.WriteLine($"{DateTime.Now} || ERROR: Cant insert exercise name. Name id: {name.Id}");
                            transaction.Commit();
                        }
                        else
                        {
                            Console.WriteLine($"{DateTime.Now} || INFO: Finish insert exercise name. Id:{name.Id}");
                            transaction.Commit();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{DateTime.Now} || ERROR: cant insert or update exercise name.");
                    Console.WriteLine($"{DateTime.Now} || ERROR DESC: {ex}");
                    transaction.Rollback();
                }
            }
        }

        private async Task InsertOrUpdateExercise(ExerciseDbContext context, ExerciseModel exercise)
        {
            var helper = CreateExercise(exercise);

            using (IDbConnection conn = new NpgsqlConnection(ConnectionString.Get(DbConnectionsString.DbAphasia)))
            {
                DbConnection.Open(conn);
                using var transaction = conn.BeginTransaction();
                try
                {
                    if (context.Exercises.Any(y => y.Id == exercise.Id))
                    {
                        var result = await conn.ExecuteAsync(
                            ExerciseAddOrUpdateQuery.InsertExercise(),
                            helper, transaction, commandType: CommandType.Text);

                        if (result == 0)
                        {
                            Console.WriteLine($"{DateTime.Now} || ERROR: Cant update exercise. Id: {exercise.Id}");
                            transaction.Rollback();
                        }
                        else
                        {
                            Console.WriteLine($"{DateTime.Now} || INFO: Finish update exercise. Id:{exercise.Id}");
                            transaction.Commit();
                        }
                    }
                    else
                    {
                        var result = await conn.ExecuteScalarAsync<int>(ExerciseAddOrUpdateQuery.InsertExercise(),
                            helper, transaction, commandType: CommandType.Text);
                        if (result == 0)
                        {
                            Console.WriteLine($"{DateTime.Now} || ERROR: Cant insert exercise. Id: {exercise.Id}");
                            transaction.Commit();
                        }
                        else
                        {
                            Console.WriteLine($"{DateTime.Now} || INFO: Finish insert exercise. Id:{exercise.Id}");
                            transaction.Commit();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{DateTime.Now} || ERROR: cant insert or update exercise.");
                    Console.WriteLine($"{DateTime.Now} || ERROR DESC: {ex}");
                    transaction.Rollback();
                }
            }
        }

        private ExerciseNameModelHelper CreateName(ExerciseNameModel name) => new ExerciseNameModelHelper()
        {
            Id = name.Id,
            Name = name.Name,
            Description = name.Description,
            ImageSrc = name.ImageSrc,
            IdExerciseTask = name.IdExerciseTask,
        };

        private ExerciseModelHelper CreateExercise(ExerciseModel exercise) => new ExerciseModelHelper()
        {
            Id = exercise.Id,
            ExerciseNameId = exercise.ExerciseName.Id,
            IdUser = exercise.IdUser,
            IsActive = exercise.IsActive,
            Order = exercise.Order,
            AphasiaId = exercise.Aphasia ==null ? null : exercise.Aphasia.Id,
        };
    }
}
