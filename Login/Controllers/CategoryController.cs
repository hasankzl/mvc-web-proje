using Login.Data;
using Login.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext _db)
        {
            this._db = _db;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {

            IEnumerable<Category> objList = _db.Category;
            return View(objList);
        }

        // get for
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // post for
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        // get for
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {   
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Category.Find(id);
            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        // get for
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Category.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult DeletePost(int id)
        {
            var obj = _db.Category.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
                _db.Category.Remove(obj);
                _db.SaveChanges();
         
            return RedirectToAction("Index");
        }
        public IActionResult List(int id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Category.Include(c => c.Posts).FirstOrDefault(c => c.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
    }
}
