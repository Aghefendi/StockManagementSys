using Microsoft.Data.SqlClient;
using StockManagementSys.Models;

namespace StockManagementSys.Interfaces
{
    public interface IUnits
    {
        List<Unit> GetItems(string SortProperty , SortOrder sortOrder); //read all
        Unit GetUnit(int id);
        Unit Create(Unit unit);
        Unit Edit(Unit unit);   
        Unit Delete(Unit unit);
    }
}
