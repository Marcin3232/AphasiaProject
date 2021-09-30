using AphasiaClientApp.Extensions;
using AphasiaClientApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AphasiaClientApp.Models
{
    public class CardModel
    {
        public AphasiaTypes AphasiaType { get; set; }
        public string ImageUrl { get; set; }
        public string Url { get; set; }
        public string Title
        {
            get
            {
                return AphasiaType.GetAttribute<DisplayAttribute>().Name;
            }
        }
    }
}
