using CodeByStudent.Tools;
using StockManagementSys.Models;

namespace StockManagementSys.Interfaces
{
    public interface IProduct
    {

        List<Product> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = ""); //read all
        Product GetItem(string Code);
        Product Create(Product item);
        Product Edit(Product item);
        Product Delete(Product item);
    }
}
