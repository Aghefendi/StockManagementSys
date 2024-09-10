using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeByStudent.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StockManagementSys.Data;
using StockManagementSys.Interfaces;
using StockManagementSys.Models;
using StockManagementSys.Repositories;

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
    

