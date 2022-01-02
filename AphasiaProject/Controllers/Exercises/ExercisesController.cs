using AphasiaProject.Models.DB.Exercises;
using AphasiaProject.Models.Exercises;
using AphasiaProject.Utils;
using CommonExercise.Enums;
using LoggerService.Manager;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AphasiaProject.Controllers.Exercises
{
    [Route("api/exercises")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        private readonly ExerciseDbContext _context;
        private readonly ILoggerManager<ExercisesController> _logger;

        public ExercisesController(ExerciseDbContext context, ILoggerManager<ExercisesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [Route("exerciseNames")]
        [HttpGet]
        public async Task<List<ExerciseNameModel>> GetExerciseNames()
        {
            _logger.LogInfo("Get all exercise names correct");
            return _context.ExerciseNames.ToList();
        }

        [Route("avaibleExerciseFromTypes/{type}")]
        [HttpGet]
        public async Task<List<ExerciseNameModel>> GetAvaibleExerciseNamesFromType(int type)
        {
            var avaibleTask = BaseAvaibleAphasiaTaskList.AvaibleExerciseTaskIdList((AphasiaTypes)type);

            if (avaibleTask == null)
            {
                _logger.LogWarn($"no tasks available for the type with id: {type}");
                return null;
            }

            var allTask = _context.ExerciseNames.ToList();
            _logger.LogInfo("Get all avaible exercise names correct");
            return allTask.Where(x => avaibleTask.Any(y => y.IdExerciseTask == x.IdExerciseTask)).ToList();
        }
    }
}
