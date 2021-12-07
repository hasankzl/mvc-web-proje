using Login.Data;
using Login.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login.Controllers
{
    public class CommentController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CommentController(ApplicationDbContext _db)
        {
            this._db = _db;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "User")]
        public IActionResult Create(String message, int postId)
        {

            Comment c = new Comment();
            c.Message = message;
            c.PostId = postId;
            if (ModelState.IsValid)
            {
                _db.Comment.Add(c);
                _db.SaveChanges();
            
            }
            return Redirect( "/Post/Read/" + postId.ToString());
        }


    }
}
