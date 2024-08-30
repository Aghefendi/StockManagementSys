using CodeByStudent.Tools;
using StockManagementSys.Models;

namespace StockManagementSys.Interfaces
{
    public interface IProductGroup
    {

        List<ProductGroup> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = ""); //read all
        ProductGroup GetItem(int id);
        ProductGroup Create(ProductGroup item);
        ProductGroup Edit(ProductGroup item);
        ProductGroup Delete(ProductGroup item);
    }
}
