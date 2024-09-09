using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeByStudent.Tools;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StockManagementSys.Data;
using StockManagementSys.Interfaces;
using StockManagementSys.Models;
using StockManagementSys.Repositories;

namespace StockManagementSys.Controllers
{
    public class ControlChecksController : Controller
    {

        private IControlCheck _repo;
        public ControlChecksController(IControlCheck repo)
        {

            _repo = repo;
        }

        public IActionResult Index()
        {


            var cont = _repo.GetAll();



            return View(cont);







        }
    }
}
    

