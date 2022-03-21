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
    public class FillExercisePhaseDbService
    {
        public void Fill()
        {
            using (var context = new ExerciseDbContext())
            {
                var phaseData = new ExercisePhaseData();
                phaseData.GetFilled().ForEach(x =>
                {
                    InsertOrUpdatePhaseName(context, x);
                    InsertOrUpdateKindName(context, x);
                    InsertOrUpdateTypeName(context, x);
                    InsertOrUpdateKindName(context, x);
                    InsertOrUpdateType(context, x);
                    InsertOrUpdateKind(context, x);
                    context.SaveChanges();
                    InsertOrUpdatePhase(context, x).GetAwaiter().GetResult();
                });
                Console.WriteLine($"{DateTime.Now} || INFO: Finish exercise phase.");
            }
        }

        private void InsertOrUpdatePhaseName(ExerciseDbContext context, ExercisePhaseModel phase)
        {
            if (!context.ExercisePhaseNames.Any(y => y.Id == phase.PhaseName.Id))
                context.Add(phase.PhaseName);
        }

        private void InsertOrUpdateKindName(ExerciseDbContext context, ExercisePhaseModel phase)
        {
            if (!context.ExerciseKindNames.Any(y => y.Id == phase.ExerciseKind.ExerciseKindName.Id))
                context.Add(phase.ExerciseKind.ExerciseKindName);
        }

        private void InsertOrUpdateTypeName(ExerciseDbContext context, ExercisePhaseModel phase)
        {
            if (!context.ExerciseTypeNames.Any(y => y.Id == phase.ExerciseType.ExerciseTypeName.Id))
                context.Add(phase.ExerciseType.ExerciseTypeName);
        }

        private void InsertOrUpdateType(ExerciseDbContext context, ExercisePhaseModel phase)
        {
            if (!context.ExerciseType.Any(y => y.Id == phase.ExerciseType.Id))
                context.Add(phase.ExerciseType);
        }

        private void InsertOrUpdateKind(ExerciseDbContext context, ExercisePhaseModel phase)
        {
            if (!context.ExerciseKind.Any(y => y.Id == phase.ExerciseKind.Id))
                context.Add(phase.ExerciseKind);
        }

        private async Task InsertOrUpdatePhase(ExerciseDbContext context, ExercisePhaseModel phase)
        {
            var helper = CreatePhase(phase);

            using (IDbConnection conn = new NpgsqlConnection(ConnectionString.Get(DbConnectionsString.DbAphasia)))
            {
                DbConnection.Open(conn);
                using var transaction = conn.BeginTransaction();
                try
                {
                    if (context.ExercisePhase.Any(y => y.Id == phase.Id))
                    {
                        var result = await conn.ExecuteAsync(
                            ExercisePhaseAddOrUpdateQuery.UpdateExercisePhase(),
                            helper, transaction, commandType: CommandType.Text);

                        if (result == 0)
                        {
                            Console.WriteLine($"{DateTime.Now} || ERROR: Cant update phase. Phase id: {phase.Id}");
                            transaction.Rollback();
                        }
                        else
                        {
                            Console.WriteLine($"{DateTime.Now} || INFO: Finish update phase. Id:{phase.Id}");
                            transaction.Commit();
                        }
                    }
                    else
                    {
                        var result = await conn.ExecuteScalarAsync<int>(ExercisePhaseAddOrUpdateQuery.InsertExercisePhase(),
                            helper, transaction, commandType: CommandType.Text);
                        if (result == 0)
                        {
                            Console.WriteLine($"{DateTime.Now} || ERROR: Cant insert phase. Phase id: {phase.Id}");
                            transaction.Commit();
                        }
                        else
                        {
                            Console.WriteLine($"{DateTime.Now} || INFO: Finish insert phase. Id:{phase.Id}");
                            transaction.Commit();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{DateTime.Now} || ERROR: cant insert or update phase.");
                    Console.WriteLine($"{DateTime.Now} || ERROR DESC: {ex}");
                    transaction.Rollback();
                }
            }
        }

        private ExercisePhaseModelHelper CreatePhase(ExercisePhaseModel phase) => new ExercisePhaseModelHelper()
        {
            Id = phase.Id,
            PhaseNameId = phase.PhaseName.Id,
            ExerciseId = phase.ExerciseId,
            ExerciseKindId = phase.ExerciseKind.Id,
            ExerciseTypeId = phase.ExerciseType.Id,
            IsActive = phase.IsActive,
            Repeat = phase.Repeat,
            IsSoundEveryStep = phase.IsSoundEveryStep,
            IsHelper = phase.IsHelper,
        };
    }
}
