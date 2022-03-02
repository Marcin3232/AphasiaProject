using AphasiaProject.Models.DB.Exercises;
using AphasiaProject.Models.Exercises;
using AphasiaProject.Services.Dapper;
using AphasiaProject.Services.Exercise;
using AphasiaProject.Utils;
using CommonExercise.Enums;
using ExerciseResource.Factory;
using ExerciseResource.Models.Exercise02;
using LoggerService.Manager;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AphasiaProject.Controllers.Exercises
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        private readonly IExerciseDbContext _context;
        private readonly ILoggerManager<ExercisesController> _logger;
        private readonly IExerciseService _exerciseService;

        public ExercisesController(IExerciseDbContext context, ILoggerManager<ExercisesController> logger, IExerciseService exerciseService)
        {
            _context = context;
            _logger = logger;
            _exerciseService = exerciseService;
        }

        [HttpGet("exerciseNames")]
        public async Task<List<ExerciseNameModel>> GetExerciseNames()
        {
            _logger.LogInfo("Get all exercise names correct");
            return _context.ExerciseNames.ToList();
        }

        [HttpGet("avaibleExerciseFromTypes/{type}")]
        public List<ExerciseNameModel> GetAvaibleExerciseNamesFromType(int type)
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

        [HttpGet("{id}")]
        public async Task<ActionResult> GetExercise(int id)
        {
            try
            {
                var result = _exerciseService.GetById(id).Result;
                return result == null ? NotFound() : Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return Problem(ex.ToString());
            }
        }
    }
}
