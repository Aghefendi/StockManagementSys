using CodeByStudent.Tools;
using StockManagementSys.Models;

namespace StockManagementSys.Interfaces
{
    public interface ICategory
    {

        List<Category> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = ""); //read all
        Category GetItem(int id);
        Category Create(Category category);
        Category Edit(Category category);
        Category Delete(Category category);
    }
}
