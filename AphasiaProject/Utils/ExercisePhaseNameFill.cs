using AphasiaProject.Models.Exercises;
using System.Collections.Generic;

namespace AphasiaProject.Utils
{
    public class ExercisePhaseNameFill
    {
        public static List<ExercisePhaseNameModel> GetFilled() => CreateList();

        private static List<ExercisePhaseNameModel> CreateList()
        {
            var temp = new List<ExercisePhaseNameModel>();
            temp.Add(new ExercisePhaseNameModel() { Id = 1, Name = "Nauka", Description = Phase1() });
            temp.Add(new ExercisePhaseNameModel() { Id = 2, Name = "Powtarzanie", Description = Phase2() });
            temp.Add(new ExercisePhaseNameModel() { Id = 3, Name = "Rozumienie", Description = Phase3() });
            temp.Add(new ExercisePhaseNameModel() { Id = 4, Name = "Nazywanie", Description = Phase4() });
            temp.Add(new ExercisePhaseNameModel() { Id = 5, Name = "Zaawansowane", Description = Phase5() });
            return temp;
        }

        private static string Phase1() =>
            "Faza 1 charakteryzuje się umiarkowaną trudnością. W jej trakcie osoba" +
            " rehabilitowana przypomina sobie i aktualizuje nazwy przedmiotów, czynności," +
            " uczuć, nazw języka codziennego. Proces ten ma charakter przekazu polisensorycznego " +
            "poprzez obraz, słowo pisane oraz głos lektora. Podczas tej fazy nie jest wymagana" +
            " interakcja pacjenta z oprogramowaniem.";

        private static string Phase2() =>
            "Faza 2 charakteryzuje się umiarkowaną trudnością." +
            " Podczas tej fazy osoba rehabilitowana proszona jest o" +
            " wykonanie polecenia (np. wskazanie, dopasowanie, powtórzenie)." +
            " Celem tej fazy jest poprawa sprawności narządów artykulacyjnych, " +
            "wyćwiczenie percepcji i pamięci słuchowej oraz przywrócenie umiejętności" +
            " fonacyjnych i artykulacyjnych. W ramach tej fazy na poszczególnych " +
            "ekranach aplikacji umieszczone są podpisy i ułatwienia dla pacjenta.";

        private static string Phase3() =>
            "Faza  charakteryzuje się wysoką trudnością. Podczas tej fazy pacjent " +
            "proszony jest o wykonanie polecenia (np. wskazanie, nazwanie, dopasowanie," +
            " powtórzenie, ułożenie w odpowiedniej kolejności), jednakże nie otrzymuje " +
            "podpowiedzi. Celem tej fazy jest wzmocnienie oraz ćwiczenie wiedzy i " +
            "umiejętności zdobytych podczas fazy 1 oraz 2.";

        private static string Phase4() =>
            "Faza  charakteryzuje się umiarkowaną trudnością. W jej trakcie osoba rehabilitowana " +
            "przypomina sobie i aktualizuje nazwy przedmiotów, czynności, uczuć, nazw języka " +
            "codziennego. Proces ten ma charakter przekazu polisensorycznego poprzez obraz," +
            " słowo pisane oraz głos lektora.";

        private static string Phase5() =>
            "Faza  charakteryzuje się wysoką trudnością.Podczas tej fazy pacjent proszony jest o " +
            "wykonanie polecenia (np.wskazanie, nazwanie, dopasowanie, powtórzenie, ułożenie w odpowiedniej" +
            " kolejności), jednakże nie otrzymuje podpowiedzi.Celem tej fazy jest wzmocnienie oraz ćwiczenie" +
            " wiedzy i umiejętności zdobytych podczas fazy 1 oraz 2.";
    }
}
