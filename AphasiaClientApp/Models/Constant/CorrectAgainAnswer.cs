using System.Collections.Generic;

namespace AphasiaClientApp.Models.Constant
{
    public class CorrectAgainAnswer
    {
        public static Dictionary<bool, string> Result() => new Dictionary<bool, string>()
        {
            { true, BaseInstruction.CorrectSrc() },
            { false, BaseInstruction.TryAgainSrc() }
        };
    }
}
