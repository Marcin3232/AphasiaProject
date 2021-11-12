using AphasiaClientApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AphasiaClientApp.Models.Constant
{
    public class AphasiaTypeListConst
    {
        private static string uriPage="/choiceAphasiaExercise/";

        public static List<CardModel> AphasiaTypeCards()
        {
            return new List<CardModel>
            {              
               new CardModel{AphasiaType=AphasiaTypes.SensoryAphasia, ImageUrl=ImageUrlConst.SensoryAphasiaUrl,Url=$"{uriPage}{(int)AphasiaTypes.SensoryAphasia}"},
               new CardModel{AphasiaType=AphasiaTypes.MovementAphasia, ImageUrl=ImageUrlConst.MovementAphasiaUrl, Url=$"{uriPage}{(int)AphasiaTypes.MovementAphasia}"},
               new CardModel{AphasiaType=AphasiaTypes.MixedAphasia, ImageUrl=ImageUrlConst.MixedAphasiaUrl,Url=$"{uriPage}{(int)AphasiaTypes.MixedAphasia}"},
            };

        }
    }
}
