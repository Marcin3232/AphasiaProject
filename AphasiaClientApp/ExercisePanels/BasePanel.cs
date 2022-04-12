using System.Threading.Tasks;

namespace AphasiaClientApp.ExercisePanels
{
    public abstract  class BasePanel
    {
        public abstract Task Show();
        public abstract Task Close();
    }
}
