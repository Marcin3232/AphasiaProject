using AphasiaProject.Services.Exercise;
using CommonExercise.Models;
using LoggerService.Manager;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AphasiaProject.Controllers.Exercises;

[Route("api/[controller]")]
[ApiController]
public class ExerciseResultHistoryController : ControllerBase
{
    private readonly ILoggerManager<ExerciseResultHistoryController> _logger;
    private readonly IExerciseResultHistoryService _resultHistoryService;

    public ExerciseResultHistoryController(ILoggerManager<ExerciseResultHistoryController> logger,
        IExerciseResultHistoryService resultHistoryService)
    {
        _logger = logger;
        _resultHistoryService = resultHistoryService;
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        try
        {
            var result = _resultHistoryService.GetAll();
            return !result.Any() ? NotFound() : Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.ToString());
            return Problem(ex.ToString());
        }
    }

    [HttpGet("{key}")]
    public async Task<ActionResult> GetLast(string key)
    {
        try
        {
            var result = _resultHistoryService.GetLast(key);
            return result == null ? NotFound() : Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.ToString());
            return Problem(ex.ToString());
        }
    }

    [HttpPost]
    public async Task<ActionResult> InsertOrUpdate(ExerciseResultHistory model)
    {
        try
        {
            var exist = _resultHistoryService.GetLast(model.Key);
            int result;

            if (exist == null)
            {
                _logger.LogInfo($"[INSERT][EXERCISE_HISTORY_RESULT][VALUE][${model.Key}|{model.CreateTime}");
                result = _resultHistoryService.Insert(model).Result;
            }
            else
            {
                _logger.LogInfo($"[UPDATE][EXERCISE_HISTORY_RESULT][VALUE][${model.Key}|{model.CreateTime}");
                model.UpdateTime = DateTime.Now;
                result = _resultHistoryService.Update(model).Result;
            }
            return result == 0 ? NotFound() : Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.ToString());
            return Problem(ex.ToString());
        }
    }

    [HttpPost("delete/{key}")]
    public async Task<ActionResult> Delete(string key)
    {
        try
        {
            var result = _resultHistoryService.Delete(key).Result;
            _logger.LogInfo($"[DELETE][EXERCISE_HISTORY_RESULT][VALUE][${key}");
            return result == null ? NotFound() : Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.ToString());
            return Problem(ex.ToString());
        }
    }
}
