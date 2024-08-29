using Microsoft.Data.SqlClient;
using StockManagementSys.Models;
using CodeByStudent.Tools;
using SortOrder = CodeByStudent.Tools.SortOrder;

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
