namespace AphasiaClientApp.Models.Helpers
{
    public class PaginationModel
    {
        public int PageIndex { get; set; }
        public bool IsCurrent { get; set; }

        public PaginationModel()
        {

        }

        public PaginationModel(int pageIndex, bool isCurrent)
        {
            PageIndex = pageIndex;
            IsCurrent = isCurrent;
        }
    }
}
