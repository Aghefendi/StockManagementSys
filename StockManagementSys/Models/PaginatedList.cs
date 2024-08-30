namespace StockManagementSys.Models
{
    public class PaginatedList<T> : List<T>
    {
        

            public int TotalRecords {  get; private set; }
        public PaginatedList(List<T> source, int pageIndex, int pagesize) { 
        
        
        TotalRecords = source.Count;
            var items=source.Skip((pageIndex-1)*pagesize).Take(pagesize).ToList();
            this.AddRange(items);
        }
    }
}
