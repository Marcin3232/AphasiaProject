using LoggerService.Manager;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerService.ConfigureService
{
    public static class LoggerService
    {
        public static void ConfigureLoggerService(this IServiceCollection service) =>
            service.AddScoped(typeof(ILoggerManager<>), typeof(LoggerManager<>));

        public static void SetLogManager() =>
             LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/Nlog.config"));
    }
}
