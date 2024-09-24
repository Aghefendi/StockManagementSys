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

        public Outward Create(Outward item)
        {
            _repo.Outwards.Add(item);
            _repo.SaveChanges();
            return item;
        }

        public List<Outward> GetAllOutwards()
        {
            return _repo.Outwards.ToList();
        }

        
        }
    }
