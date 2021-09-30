using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AphasiaClientApp.Models;
using AphasiaClientApp.Models.Constant;

namespace AphasiaClientApp.Pages
{
    public partial class ChoiceTypeAphasia
    {
        private List<CardModel> aphasiaTypes;

        protected override void OnInitialized()
        {
            aphasiaTypes = AphasiaTypeListConst.AphasiaTypeCards();
        }

    }
}
