using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;
using BL;
using Entities;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ourProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LogInController : ControllerBase
    {
        public IUserBL iuserbl;
         
        public LogInController(IUserBL iuserbl)
        {
            this.iuserbl = iuserbl;
        }
        //// GET: api/<LogIn>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<LogIn>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<LogIn>
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<User>> Post([FromBody] LoginUserDTO user)
        {
          User u = await iuserbl.GetByPassAndEmailBL(user.Email, user.Password);

            if (u == null)
                return NoContent();
            else
                return Ok(u);
        }

       
    }
}
