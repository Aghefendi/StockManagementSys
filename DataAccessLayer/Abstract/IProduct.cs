using CodeByStudent.Tools;
using Entity.Concreate;


namespace DataAccessLayer.Abstract
{
    public interface IProduct
    {

        PaginatedList<Product> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5); //read all
        Product GetItem(string Code);
        Product Create(Product item);
        Product Edit(Product item);
        Product Delete(Product item);
    }
}
