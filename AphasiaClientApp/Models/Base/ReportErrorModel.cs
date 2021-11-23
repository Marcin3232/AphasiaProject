using System;

namespace AphasiaClientApp.Models.Base
{
    public class ReportErrorModel
    {
        public string Message { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

        public static string Error => "Błąd Aplikacji";
        public static string BaseMessage => "Wystąpił nieoczekiwany błąd aplikacji. Zostaniesz przeniesiony do strony głównej.";
        public static string ReportError => "zgłoś błąd";
    }
}
