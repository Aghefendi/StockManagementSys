using Microsoft.Data.SqlClient;

using CodeByStudent.Tools;
using SortOrder = CodeByStudent.Tools.SortOrder;
using Entity.Concreate;

namespace DataAccessLayer.Abstract
{
    public interface IUnits
    {
        PaginatedList<Unit> GetItems(string SortProperty , SortOrder sortOrder , string SearchText="", int pageIndex = 1, int pageSize = 5); //read all
        Unit GetUnit(int id);
        Unit Create(Unit unit);
        Unit Edit(Unit unit);   
        Unit Delete(Unit unit);
    }
}
