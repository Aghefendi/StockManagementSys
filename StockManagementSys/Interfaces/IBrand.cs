using CodeByStudent.Tools;
using StockManagementSys.Models;

namespace StockManagementSys.Interfaces
{
    public interface IBrand
    {
        List<Brand> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = ""); //read all
        Brand GetItem(int id);
        Brand Create(Brand brand);
        Brand Edit(Brand brand);
        Brand Delete(Brand brand);
    }
}
