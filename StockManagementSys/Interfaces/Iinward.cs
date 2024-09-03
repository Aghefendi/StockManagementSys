using CodeByStudent.Tools;
using StockManagementSys.Models;
using StockManagementSys.Models.StockManagementSys.Models;

namespace StockManagementSys.Interfaces
{
    public interface Iinward
    {
        PaginatedList<Inward> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5); //read all
        Inward GetItem(int id);
        bool Create(Inward items);
        bool Edit(Inward items);
        bool Delete(Inward items);
    }
}
