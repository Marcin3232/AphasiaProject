using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace AphasiaClientApp.Pages.Management
{

   
    public partial class ExerciseResults
    {
        [Parameter]
        public string Id { get; set; }

        public List<PersonalResults> PersonalResults = new List<PersonalResults>
    {
        new PersonalResults { Data = "Nauka", Czas = 35 },
        new PersonalResults { Data = "Powtarzanie", Czas = 35 },
        new PersonalResults { Data = "Rozumienie", Czas = 28 },
        new PersonalResults { Data = "Nazywanie", Czas = 34 }
    };
    }
    public class PersonalResults
    {
        public string Data { get; set;}
        public double Czas { get; set;}
    }
    


}
