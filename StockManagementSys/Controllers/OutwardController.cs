using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace StockManagementSys.Controllers
{
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

        // Yeni outward işlemi (mal çıkışı) oluşturma
        [HttpPost]
        public IActionResult ProcessOutward(int controlCheckId, int quantity)
        {
            try
            {
                _outwardRepository.ProcessOutward(controlCheckId, quantity);
                ViewBag.Message = "Mal çıkışı başarıyla gerçekleştirildi.";
            }
            catch (InvalidOperationException ex)
            {
                ViewBag.Error = ex.Message;
            }

            return RedirectToAction(nameof(Index)); // İşlem tamamlandığında Index'e dön
        }
    }
}
