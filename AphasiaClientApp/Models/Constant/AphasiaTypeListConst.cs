using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AphasiaClientApp.Models.Constant
{
    public class AphasiaTypeListConst
    {
        public static List<CardModel> AphasiaTypeCards()
        {
            return new List<CardModel>
            {              
               new CardModel{AphasiaType=Enums.AphasiaTypes.SensoryAphasia, ImageUrl=ImageUrlConst.SensoryAphasiaUrl,Url=""},
               new CardModel{AphasiaType=Enums.AphasiaTypes.MovementAphasia, ImageUrl=ImageUrlConst.MovementAphasiaUrl, Url=""},
               new CardModel{AphasiaType=Enums.AphasiaTypes.MixedAphasia, ImageUrl=ImageUrlConst.MixedAphasiaUrl,Url=""},
            };

        }
    }
}
