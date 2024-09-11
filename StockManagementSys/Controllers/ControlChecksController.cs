using DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StockManagementSys.Controllers
{
    [Authorize]
    public class ControlChecksController : Controller
    {

        private IControlCheck _repo;
        public ControlChecksController(IControlCheck repo)
        {

            _repo = repo;
        }

        public IActionResult index()
        {
            var report=_repo.GetAll();



            return View(report);
        }
    }
}
    

