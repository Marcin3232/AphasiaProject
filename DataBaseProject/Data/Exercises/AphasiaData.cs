using DataBaseProject.Models.Exercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseProject.Data.Exercises
{
    public class AphasiaData
    {
        public List<AphasiaModel> GetFilled() => CreateList();

        private List<AphasiaModel> CreateList()
        {
            var temp = new List<AphasiaModel>();
            temp.Add(Create(1, "Czuciowa", "...",true,1,0));
            temp.Add(Create(2, "Motoryczna", "...", true, 2, 0));
            temp.Add(Create(3, "Mieszana", "...", true, 3, 0));
            return temp;
        }

        private AphasiaModel Create(int id, string name, string desc, bool isActive, int aphasiaType, int userId) =>
            new AphasiaModel()
            {
                Id = id,
                Name = name,
                Description = desc,
                IsActive = isActive,
                AphasiaType = aphasiaType,
                UserId = userId,
            };
    }
}
