using CodeByStudent.Tools;
using StockManagementSys.Models;

namespace StockManagementSys.Interfaces
{
    public interface IProductGroup
    {

        PaginatedList<ProductGroup> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5); //read all
        ProductGroup GetItem(int id);
        ProductGroup Create(ProductGroup item);
        ProductGroup Edit(ProductGroup item);
        ProductGroup Delete(ProductGroup item);
    }
}
