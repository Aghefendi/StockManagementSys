using CodeByStudent.Tools;
using StockManagementSys.Models;

namespace StockManagementSys.Interfaces
{
    public interface IProductProfile
    {

        List<ProductProfile> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = ""); //read all
        ProductProfile GetItem(int id);
        ProductProfile Create(ProductProfile item);
        ProductProfile Edit(ProductProfile item);
        ProductProfile Delete(ProductProfile item);
    }
}
