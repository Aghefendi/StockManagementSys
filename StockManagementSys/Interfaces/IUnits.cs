using Microsoft.Data.SqlClient;
using StockManagementSys.Models;
using CodeByStudent.Tools;
using SortOrder = CodeByStudent.Tools.SortOrder;

namespace StockManagementSys.Interfaces
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
