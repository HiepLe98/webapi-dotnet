using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebCoreApp.Data;
using WebCoreApp.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebCoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly MyDbContext _context;

        public CategoryController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public IActionResult GetAll()
        {
            var categorys = _context.Categories.ToList();
            return Ok(categorys);
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var category = _context.Categories.SingleOrDefault(ca => ca.Id == id);
            if (category != null)
                return Ok(category);
            else
                return NotFound();
        }

        // POST api/<CategoryController>
        [HttpPost]
        public IActionResult CreateNew(CategoryVM model)
        {
            try
            {
                var category = new Category
                {
                    Name = model.Name
                };
                _context.Add(category);
                _context.SaveChanges();
                return Ok(category);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
