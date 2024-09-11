using DataAccessLayer.Abstract;
using Entity.Concreate;
using Microsoft.EntityFrameworkCore;
using StockManagementSys.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concreate.Repositories
{
    public class OutwardRepository : IOutward
    {
        private readonly InventoryContext _repo;
        public OutwardRepository(InventoryContext repo)
        {
            _repo = repo;
        }
        public List<Outward> GetAllOutwards()
        {
            return _repo.Outwards
                 .Include(o => o.ControlCheck)
                 .Include(o => o.ControlCheck.InwardDetail).ToList();
        }

        public void ProcessOutward(int controlCheckId, int quantity)
        {
            var controlCheck = _repo.ControlChecks.FirstOrDefault(x => x.id == controlCheckId);

            if (controlCheck != null)
            {
                controlCheck.DecreaseStock(quantity);

                var outward = new Outward
                {
                    ControlCheckId = controlCheckId,
                    Quantity = quantity,
                    OutwardDate = DateTime.Now
                };

                _repo.Outwards.Add(outward);
                _repo.SaveChanges();
            }
        }
    }
}
