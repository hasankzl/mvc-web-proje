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
    public class PostController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PostController(ApplicationDbContext _db)
        {
            this._db = _db;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {

            IEnumerable<Post> objList = _db.Post.Include(c => c.Category);
            return View(objList);
        }


        // get for
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {

            ViewData["categoryList"] = _db.Category.ToList();
            return View();
        }

        // post for
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(Post obj)
        {
            if (ModelState.IsValid)
            {
                _db.Post.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // get for
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {

            ViewData["categoryList"] = _db.Category.ToList();
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Post.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(Post obj)
        {
            if (ModelState.IsValid)
            {
                _db.Post.Update(obj);
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
            var obj = _db.Post.Include(c => c.Category).FirstOrDefault(c => c.Id ==id);
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
            var obj = _db.Post.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Post.Remove(obj);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Read(int id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Post.Include(c => c.Category).FirstOrDefault(c => c.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
    }
}
