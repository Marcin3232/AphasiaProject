using AphasiaClientApp.Models.Helpers;
using AphasiaClientApp.Services;
using CommonExercise.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AphasiaClientApp.Pages
{
    public partial class ChoiceAphasiaExercise
    {
        [Parameter]
        public string AphasiaTypeId { get; set; }
        [Inject]
        public IDbExerciseService dBExerciseService { get; set; }
        private int PageIndex { get; set; } = 1;
        private int MaxCountPagination { get; set; } = 5;
        private int CurrentPage { get; set; } = 1;
        private static readonly string style = "margin-right:21px;margin-left:21px; margin-bottom:100px; margin-top:95px;";
        private List<PaginationModel> quantityList = new List<PaginationModel>();
        private int PageElements = 4;

        private List<ExerciseName> exerciseNameList;

        protected override async Task OnInitializedAsync()
        {
            if (int.TryParse(AphasiaTypeId, out int idType))
                exerciseNameList = await dBExerciseService.GetExerciseNameFromAphasiaType(idType);

            exerciseNameList.ForEach(x => x.ImageSrc = x.ImageSrc+".svg");

            MaxCountPagination = MaxPaginationPage(exerciseNameList);
            quantityList = FillPaginationList(MaxCountPagination);

            base.OnInitialized();
        }

        private int MaxPaginationPage(List<ExerciseName> list)=> (int)Math.Ceiling((double)list.Count()/PageElements);

        private List<PaginationModel> FillPaginationList(int maxCountPagination)
        {
            var list = new List<PaginationModel>();
            for (int i = 1; i <= maxCountPagination; i++)
            {
                list.Add(new PaginationModel()
                {
                    PageIndex = i,
                    IsCurrent = CurrentPage == i ? true : false
                });
            }
            return list;
        }

        private void LeftMove_Click()
        {
            if (PageIndex > 1)
            {
                PageIndex -= 1;

                quantityList[PageIndex - 1] = new PaginationModel(PageIndex, true);
                quantityList[PageIndex] = new PaginationModel(PageIndex + 1, false);
                StateHasChanged();
            }
        }

        private void RightMove_Click()
        {
            if (PageIndex < MaxCountPagination)
            {
                PageIndex += 1;

                quantityList[PageIndex - 1] = new PaginationModel(PageIndex, true);
                quantityList[PageIndex - 2] = new PaginationModel(PageIndex - 1, false);
                StateHasChanged();
            }
        }

        private void Page_Click(PaginationModel paginationModel)
        {
            quantityList[PageIndex - 1] = new PaginationModel(PageIndex, false);
            quantityList[paginationModel.PageIndex - 1] = new PaginationModel(paginationModel.PageIndex, true);
            PageIndex = paginationModel.PageIndex;
            StateHasChanged();
        }
    }
}
