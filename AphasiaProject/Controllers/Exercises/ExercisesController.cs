using AphasiaProject.Models.DB.Exercises;
using AphasiaProject.Models.Exercises;
using AphasiaProject.Utils;
using CommonExercise.Enums;
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

        public ExercisesController(ExerciseDbContext context)
        {
            _context = context;
        }

        [Route("exerciseNames")]
        [HttpGet]
        public async Task<List<ExerciseNameModel>> GetExerciseNames() => _context.ExerciseNames.ToList();

        [Route("avaibleExerciseFromTypes/{type}")]
        [HttpGet]
        public async Task<List<ExerciseNameModel>> GetAvaibleExerciseNamesFromType(int type)
        {
            var avaibleTask = BaseAvaibleAphasiaTaskList.AvaibleExerciseTaskIdList((AphasiaTypes)type);

            if(avaibleTask == null)
                return null;

            var allTask = _context.ExerciseNames.ToList();
            return allTask.Where(x => avaibleTask.Any(y => y.IdExerciseTask == x.IdExerciseTask)).ToList();
        }
    }
}
