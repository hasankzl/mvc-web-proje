using Login.Data;
using Login.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Login.Controllers
{
    public class HomeController : Controller
    {
      
        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext _db)
        {
            this._db = _db;
        }
        public IActionResult Index()
        {

            ViewData["categoryList"] = _db.Category.Include(c => c.Posts).ToList();

            return View();
        }

        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
