using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ourProject.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {
        
        public IUserBL iuserbl;
        public IPasswordHashHelper ipasswordHashHelper;

        public UserController(IUserBL Iuserbl, IMapper imapper, IPasswordHashHelper ipasswordHashHelper)
        {
            iuserbl = Iuserbl;
            this.ipasswordHashHelper = ipasswordHashHelper;
        }

       
        //// GET api/<UserController>/5
        public static User WithoutPassword(User user)
        {
            user.Password = null;
            return user;
        }

        [HttpGet("{email}/{password}")]
        [AllowAnonymous]
        public async Task<User> Get(string email, string password)
        {
           
            User u=    await iuserbl.GetByPassAndEmailBL(email);
            string Hashedpassword = ipasswordHashHelper.HashPassword(password, u.Salt, 1000, 8);
            if (Hashedpassword.Equals(u.Password.TrimEnd()))
                return WithoutPassword(u);
            else
                return null;


        }



        // POST api/<UserController>
        [HttpPost]
        [AllowAnonymous]
        public async Task Post([FromBody] User user)
        {
            await iuserbl.PostBL(user);

        }



        //// PUT api/<UserController>/5
        [HttpPut("{id}")]
        [AllowAnonymous]
        public async Task Put(int id,[FromBody] User user)
        {
            await iuserbl.PutBL(id, user);

        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        [AllowAnonymous]
        public async Task Delete(int id)
        {
            await iuserbl.DeleteBL(id);
        }



    }
}
