using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ourProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public ICategoryBL icategorybl;


        public CategoryController(ICategoryBL icategorybl)
        {
            this.icategorybl = icategorybl;

        }
        // GET: api/<CategoryController>
        [HttpGet("{id}")]
        public async Task<List<Category>> GetCategoryForEvent(int id)
        {
            return await icategorybl.GetCategoryForEventBL(id);
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<List<Category>> Get()
        {
            return await icategorybl.GetAllCategoryBL();
        }


        // POST api/<CategoryController>
        [HttpPost]
        
        public async Task Post([FromBody] Category[] c)
        {
            await icategorybl.PostBL(c);

        }


    }
}