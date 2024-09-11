using Microsoft.EntityFrameworkCore;
using StockManagementSys.Data;
using SortOrder = CodeByStudent.Tools.SortOrder;
using Entity.Concreate;
using DataAccessLayer.Abstract;

namespace DataAccessLayer.Concreate.Repositories
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

        private List<Unit> DoSort(List<Unit> units,string SortProperty, SortOrder sortOrder)
        {
           

            if (SortProperty.ToLower() == "name")
            {
                if (sortOrder == SortOrder.Ascending)
                {

                    units = units.OrderBy(x => x.Name).ToList();
                }
                else
                {
                    units = units.OrderByDescending(x => x.Name).ToList();
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

        public PaginatedList<Unit> GetItems(string SortProperty , SortOrder sortOrder , string SearchText="",int pageIndex=1 , int pageSize=5)
        {
            List<Unit> units=_context.Units.ToList();
            if(SearchText!="" && SearchText!=null)
            {
                units=_context.Units.Where(n=>n.Name.Contains(SearchText)||n.Description.Contains(SearchText)).ToList();

            }
            else
            {
                units = _context.Units.ToList();

            }
            units=DoSort(units,SortProperty, sortOrder);

            PaginatedList<Unit> reUnits = new PaginatedList<Unit>(units, pageIndex, pageSize);
            return reUnits;
        }

        public Unit GetUnit(int id)
        {
            Unit unit = _context.Units.Where(x => x.Id == id).FirstOrDefault();
            return unit;
        }

        
    }
}
