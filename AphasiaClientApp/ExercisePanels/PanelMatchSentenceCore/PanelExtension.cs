using AphasiaClientApp.Models.Enums;
using CommonExercise.ExerciseResourceProjection;

namespace AphasiaClientApp.ExercisePanels.PanelMatchSentenceCore
{
    public class PanelExtension
    {
        public static ColorType SetAnswerColor(PanelMatchSentenceModel.Expression model) => model.IsCorrect switch
        {
            true => ColorType.Green,
            false => ColorType.Red,
            null => ColorType.NormalEmpty
        };

        public static string ShowText(PanelMatchSentenceModel.Expression model)
        {
            if (model.IsShow)
                return model.Text;
            else
                return new string('.',model.Text.Length);
        }

        public static bool IsClickableMark(PanelMatchSentenceModel.Expression model)
        {
            if (model.IsCorrect is null)
                return true;

            return (bool)!model.IsCorrect;
        }

        public static bool IsClickableSelected(PanelMatchSentenceModel.Expression model) =>
            model.IsShow;
    }
}
