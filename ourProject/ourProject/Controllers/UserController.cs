using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using Entities;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ourProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        
        public IUserBL iuserbl;
        

        public UserController(IUserBL Iuserbl, IMapper imapper)
        {
            iuserbl = Iuserbl;
           
        }

        //// GET: api/<UserController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<UserController>/5
        [HttpGet("{email}/{password}")]
        public async Task<User> Get(string email, string password)
        {
           
            User u=    await iuserbl.GetByPassAndEmailBL(email, password);
            return u;


        }



        // POST api/<UserController>
        [HttpPost]
        public async Task Post([FromBody] User user)
        {
            await iuserbl.PostBL(user);

        }



        //// PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task Put(int id,[FromBody] User user)
        {
            await iuserbl.PutBL(id, user);

        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await iuserbl.DeleteBL(id);
        }



    }
}
