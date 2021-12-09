using Blog.Data;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryApiController : ControllerBase
    {

        private readonly ApplicationDbContext _db;

        public CategoryApiController(ApplicationDbContext _db)
        {
            this._db = _db;
        }

        // GET: api/<CategoryApiController>
        [HttpGet]
        public List<Category> Get()
        {
            return _db.Category.ToList();
        }

        // GET api/<CategoryApiController>/5
        [HttpGet("{id}")]
        public Category Get(int id)
        {
            return _db.Category.Find(id);
        }

        // POST api/<CategoryApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CategoryApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoryApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
