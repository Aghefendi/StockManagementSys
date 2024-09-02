using CodeByStudent.Tools;
using StockManagementSys.Models;

namespace StockManagementSys.Interfaces
{
    public interface IPurchaseOrder
    {
        PaginatedList<PoHeader> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5); //read all
        PoHeader GetItem(int id);
        bool Create(PoHeader items);
        bool Edit(PoHeader items);
        bool Delete(PoHeader items);
    }
}
