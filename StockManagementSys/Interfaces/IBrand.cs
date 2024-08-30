using CodeByStudent.Tools;
using StockManagementSys.Models;

namespace StockManagementSys.Interfaces
{
    public interface IBrand
    {
        PaginatedList<Brand> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5); //read all
        Brand GetItem(int id);
        Brand Create(Brand brand);
        Brand Edit(Brand brand);
        Brand Delete(Brand brand);
    }
}
