using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StockManagementSys.Data;
using StockManagementSys.Interfaces;
using StockManagementSys.Models;

namespace StockManagementSys.Repositories
{
    public class UnitRepository : IUnits
    {
        private readonly InventoryContext _context;
        public UnitRepository(InventoryContext context)
        {
            _context = context;
        }

        

        public Unit Create(Unit unit)
        {
            _context.Units.Add(unit);
            _context.SaveChanges();
            return unit;
        }

        public Unit Delete(Unit unit)
        {
            _context.Units.Attach(unit);
            _context.Entry(unit).State = EntityState.Deleted;
            _context.SaveChanges();
            return unit;
        }

        public Unit Edit(Unit unit)
        {
            _context.Units.Attach(unit);
            _context.Entry(unit).State = EntityState.Modified;
            _context.SaveChanges();
            return unit;
        }

        public List<Unit> GetItems(string SortProperty , SortOrder sortOrder)
        {
            List<Unit> units = _context.Units.ToList();

            if (SortProperty.ToLower() == "name")
            {
                if (sortOrder == SortOrder.Ascending)
                {

                    units=units.OrderBy(x => x.Name).ToList();
                }
                else
                {
                    units=units.OrderByDescending(x=> x.Name).ToList();
                }


            }
            else
            {
                if (sortOrder == SortOrder.Ascending)
                {
                    units = units.OrderBy(d => d.Description).ToList();

                }
                else
                {
                    units = units.OrderByDescending(d => d.Description).ToList();
                }
            }
            return units;
        }

        public Unit GetUnit(int id)
        {
            Unit unit = _context.Units.Where(x => x.Id == id).FirstOrDefault();
            return unit;
        }

        
    }
}
