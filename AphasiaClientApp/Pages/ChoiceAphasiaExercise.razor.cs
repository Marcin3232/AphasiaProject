using AphasiaClientApp.Components.Modals.LoadModals;
using AphasiaClientApp.Extensions;
using AphasiaClientApp.Models.Base;
using AphasiaClientApp.Models.Helpers;
using AphasiaClientApp.Services;
using CommonExercise.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
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


        [Parameter]
        public int Id { get; set; } = 0;

        [Parameter]
        public int Type { get; set; } = 0;

        [Inject]
        public IDbExerciseService dBExerciseService { get; set; }
        [Inject]
        private ISnackbarMessage snackbarMessage { get; set; }
        private int PageIndex { get; set; } = 1;
        private int MaxCountPagination { get; set; } = 5;
        private int CurrentPage { get; set; } = 1;
        private string style = "margin-right:21px;margin-left:21px;";
        private List<PaginationModel> quantityList = new List<PaginationModel>();
        private int PageElements = 4;
        private LoadingDialogModel dialogLoad = new LoadingDialogModel();
        private List<ExerciseName> exerciseNameList;
        private List<int> exIndexes = new List<int>();

        protected override async Task OnInitializedAsync()
        {
            try
            {
                await Task.Delay(10);
                await dialogLoad.Show();
                await ChangeStyleByWidth();


                if((Id !=0 && Type != 0))
                {
                    exerciseNameList = new List<ExerciseName>();
                    var exes = await dBExerciseService.GetExerciseNameFromAphasiaTypePreview(Id, Type);
                    exes.ForEach(x =>
                    {
                        ExerciseName temp = new ExerciseName();
                        temp.Id = x.Id;
                        temp.IdExerciseTask = x.IdExerciseTask;
                        temp.Description = x.Description;
                        temp.Name = x.Name;
                        temp.ImageSrc = x.ImageSrc;
                        exerciseNameList.Add(temp);
                        exIndexes.Add(x.ExerciseId);
                    });
                }
                else
                {
                if (int.TryParse(AphasiaTypeId, out int idType))
                    exerciseNameList = await dBExerciseService.GetExerciseNameFromAphasiaType(idType);
                }

              

                if (exerciseNameList == null)
                {
                    snackbarMessage.ShowErrorMode(new ReportErrorModel()
                    {
                        Date = DateTime.Now,
                        Message = "Nie udało się poprawnie pobrać danych z bazy!",
                    }, true);
                    navigationManager.NavigateTo("/");
                    return;
                }

                exerciseNameList.ForEach(x => x.ImageSrc = x.ImageSrc + ".svg");

                MaxCountPagination = MaxPaginationPage(exerciseNameList);
                quantityList = FillPaginationList(MaxCountPagination);
            }
            catch (Exception ex)
            {
                snackbarMessage.ShowErrorMode(new ReportErrorModel()
                {
                    Message = ex.Message,
                }, true);
                navigationManager.NavigateTo("/");
            }
            finally
            {
                await dialogLoad.Close();
            }
            base.OnInitialized();
        }

        private async Task ChangeStyleByWidth()
        {
            var dimension = await JsRuntime.InvokeAsync<WindowDimension>("getWindowDimensions");

            if (dimension == null)
                return;

            var width = dimension.Width;
            if (width <= 640)
                style = "margin-right:5px;margin-left:5px;";
        }

        private int MaxPaginationPage(List<ExerciseName> list) => (int)Math.Ceiling((double)list.Count() / PageElements);

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
