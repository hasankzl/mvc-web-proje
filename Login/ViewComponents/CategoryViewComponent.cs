using Blog.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.ViewComponents
{
    public class CategoryViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _db;

        public CategoryViewComponent(ApplicationDbContext _db)
        {
            this._db = _db;
        }

        public async  Task<IViewComponentResult> InvokeAsync()
        {
            var item = await _db.Category.ToListAsync();
            return View(item);
        }
    }
}
