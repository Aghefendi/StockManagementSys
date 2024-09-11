using System;

namespace Entity.Concreate
{
    public class PagerModel
    {

        public PagerModel()
        {
            
        }

        public int TotalItem { get; private set; }
        public int CurrentPage { get; private set; }
        public int PageSize { get; private set; }
        public int TotalPages { get; private set; }
        public int StartPages { get; private set; }
        public int EndPage { get; private set; }
        public int StartRecord { get; private set; }
        public int EndRecord { get; private set; }

        public string Action { get; set; } = "";
        public string SearchText { get; set; }
        public string SortExpression { get; set; }

        public PagerModel(int totalItem, int currentPage , int pageSize=5)
        {
            this.TotalItem = totalItem;
            this.CurrentPage = currentPage;
            this.PageSize = pageSize;

            int totalPages = (int)Math.Ceiling((decimal)totalItem / (decimal)pageSize);
            TotalPages = totalPages;
            int startPage = currentPage-5;
            int endPage = currentPage+4;
            if (startPage <= 0)
            {
                endPage=endPage-(startPage-1);
                startPage = 1;
            }
            if(endPage>totalPages)
            {

                endPage = totalPages;
                if (endPage > 10)
                {
                    startPage=endPage-9;
                }
            }
            StartRecord=(CurrentPage-1)*pageSize+1;
            EndRecord = StartPages - 1 + PageSize;

            if (EndRecord>TotalItem) {
                EndRecord = TotalItem;
            }
            if (TotalItem == 0)
            {
                StartPages = 0;
                StartRecord = 0;
                CurrentPage = 0;
                EndRecord= 0;
            }
            else
            {
                StartPages = startPage;
                EndPage = endPage;
            }
        }
    }
}
