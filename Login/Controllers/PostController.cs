using Login.Data;
using Login.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Login.Controllers
{
    public class PostController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PostController(ApplicationDbContext _db, IWebHostEnvironment _webHostEnvironment)
        {
            this._db = _db;
            this._webHostEnvironment = _webHostEnvironment;
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
        public async Task<IActionResult> CreateAsync(Post obj)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                foreach (var Image in files)
                {
                    if (Image != null && Image.Length > 0)
                    {

                        var file = Image;
                        var uploads = Path.Combine(_webHostEnvironment.WebRootPath, "img\\post");

                        if (file.Length > 0)
                        {
                            var fileName = ContentDispositionHeaderValue.Parse
                                (file.ContentDisposition).FileName.Trim('"');

                            System.Console.WriteLine(fileName);
                            using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                                obj.Image = file.FileName;
                            }


                        }
                    }
                }
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
            var obj = _db.Post.Include(c => c.Category).Include(c => c.Comments).ThenInclude(c => c.BlogUser).FirstOrDefault(c => c.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            PostViewModal postViewModal = new PostViewModal();
            postViewModal.Post = obj;

            return View(postViewModal);
        }
    }
}
