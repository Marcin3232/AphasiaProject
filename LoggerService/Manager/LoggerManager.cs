using Microsoft.Extensions.Logging;

namespace LoggerService.Manager
{
    internal class LoggerManager<T> : ILoggerManager<T>
    {
        private static ILogger<T> _logger;

        public LoggerManager(ILogger<T> logger) => _logger = logger;
        public void LogDebug(string message) => _logger.LogDebug(message);
        public void LogError(string message) => _logger.LogError(message);
        public void LogInfo(string message) => _logger.LogInformation(message);
        public void LogWarn(string message) => _logger.LogWarning(message);
    }
}
