using Entity.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IOutward
    {
        // Tüm Outward işlemlerini listelemek için
        List<Outward> GetAllOutwards();

        // Yeni Outward eklemek için
        void ProcessOutward(int controlCheckId, int quantity);
    }
}
