using CodeByStudent.Tools;
using StockManagementSys.Models;

namespace StockManagementSys.Interfaces
{
    public interface IProductProfile
    {

        PaginatedList<ProductProfile> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5); //read all
        ProductProfile GetItem(int id);
        ProductProfile Create(ProductProfile item);
        ProductProfile Edit(ProductProfile item);
        ProductProfile Delete(ProductProfile item);
    }
}
