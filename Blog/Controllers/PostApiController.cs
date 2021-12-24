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
    public class PostApiController : ControllerBase
    {

        private readonly ApplicationDbContext _db;

        public PostApiController(ApplicationDbContext _db)
        {
            this._db = _db;
        }
        // GET: api/<PostApiController>
        [HttpGet]
        public List<Post> Get()
        {

            return _db.Post.ToList();
        }

        // GET api/<PostApiController>/5
        [HttpGet("{id}")]
        public Post Get(int id)
        {
            return _db.Post.Find(id);
        }

        // POST api/<PostApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PostApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PostApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
