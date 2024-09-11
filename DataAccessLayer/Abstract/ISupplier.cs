using CodeByStudent.Tools;
using Entity.Concreate;

namespace DataAccessLayer.Abstract
{
    public interface ISupplier
    {
        PaginatedList<Supplier> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5); //read all
        Supplier GetItem(int id);
        Supplier Create(Supplier items);
        Supplier Edit(Supplier items);
        Supplier Delete(Supplier items);
    }
}
