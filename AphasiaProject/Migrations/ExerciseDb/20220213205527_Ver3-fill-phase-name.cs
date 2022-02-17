using Microsoft.EntityFrameworkCore.Migrations;

namespace AphasiaProject.Migrations.ExerciseDb
{
    public partial class Ver3fillphasename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ExercisePhaseName",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Faza 1 charakteryzuje się umiarkowaną trudnością. W jej trakcie osoba rehabilitowana przypomina sobie i aktualizuje nazwy przedmiotów, czynności, uczuć, nazw języka codziennego. Proces ten ma charakter przekazu polisensorycznego poprzez obraz, słowo pisane oraz głos lektora. Podczas tej fazy nie jest wymagana interakcja pacjenta z oprogramowaniem.", "Nauka" },
                    { 2, "Faza 2 charakteryzuje się umiarkowaną trudnością. Podczas tej fazy osoba rehabilitowana proszona jest o wykonanie polecenia (np. wskazanie, dopasowanie, powtórzenie). Celem tej fazy jest poprawa sprawności narządów artykulacyjnych, wyćwiczenie percepcji i pamięci słuchowej oraz przywrócenie umiejętności fonacyjnych i artykulacyjnych. W ramach tej fazy na poszczególnych ekranach aplikacji umieszczone są podpisy i ułatwienia dla pacjenta.", "Powtarzanie" },
                    { 3, "Faza  charakteryzuje się wysoką trudnością. Podczas tej fazy pacjent proszony jest o wykonanie polecenia (np. wskazanie, nazwanie, dopasowanie, powtórzenie, ułożenie w odpowiedniej kolejności), jednakże nie otrzymuje podpowiedzi. Celem tej fazy jest wzmocnienie oraz ćwiczenie wiedzy i umiejętności zdobytych podczas fazy 1 oraz 2.", "Rozumienie" },
                    { 4, "Faza  charakteryzuje się umiarkowaną trudnością. W jej trakcie osoba rehabilitowana przypomina sobie i aktualizuje nazwy przedmiotów, czynności, uczuć, nazw języka codziennego. Proces ten ma charakter przekazu polisensorycznego poprzez obraz, słowo pisane oraz głos lektora.", "Nazywanie" },
                    { 5, "Faza  charakteryzuje się wysoką trudnością.Podczas tej fazy pacjent proszony jest o wykonanie polecenia (np.wskazanie, nazwanie, dopasowanie, powtórzenie, ułożenie w odpowiedniej kolejności), jednakże nie otrzymuje podpowiedzi.Celem tej fazy jest wzmocnienie oraz ćwiczenie wiedzy i umiejętności zdobytych podczas fazy 1 oraz 2.", "Zaawansowane" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExercisePhaseName",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ExercisePhaseName",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ExercisePhaseName",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ExercisePhaseName",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ExercisePhaseName",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
