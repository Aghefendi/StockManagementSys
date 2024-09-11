using Entity.Concreate;

namespace DataAccessLayer.Abstract
{
    public interface IControlCheck
    {
       // PaginatedList<ControlCheck> GetItems(string SortProperty, SortOrder sortOrder, string SearchText = "", int pageIndex = 1, int pageSize = 5); //read all
       List<ControlCheck> GetAll();

    }
}
