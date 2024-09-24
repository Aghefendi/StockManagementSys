using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate.Repositories;
using Entity.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace StockManagementSys.Controllers
{
    [Authorize]
    public class OutwardController:Controller
    {
        private readonly IOutward _outwardRepository;

        public OutwardController(IOutward outwardRepository)
        {
            _outwardRepository = outwardRepository;
        }

        // Tüm outward işlemlerini listele
        public IActionResult Index()
        {
            var outwards = _outwardRepository.GetAllOutwards();
            return View(outwards);
        }

        public IActionResult Create()
        {
            Outward item = new Outward();

            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Outward item)
        {


            try
            {
                item = _outwardRepository.Create(item);

            }
            catch
            {


            }

            return RedirectToAction(nameof(Index));
        }



    }
}
