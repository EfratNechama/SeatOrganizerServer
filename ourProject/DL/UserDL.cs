//using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DL
{
   public  class UserDL: IUserDL
    {
        SeatOrganizerContext _myDB;
        public UserDL(SeatOrganizerContext SeatOrgenizerContext)
        {
           _myDB = SeatOrgenizerContext;
        }

        public async Task PostDL(User user)
        {
            await _myDB.Users.AddAsync(user); 
            await _myDB.SaveChangesAsync();
        }

        public async Task<User> GetByPassAndEmailDL(string email, string password)
        {

            User u = await _myDB.Users.Where(u => u.Password.Equals(password) && u.Email.Equals(email)).FirstOrDefaultAsync();
            if (u != null)
            {
                return u;
            }
            else
            {
                return null;
            }
           
            //User u = await _myDB.Users.FindAsync(email);
            //if (u != null && u.Password == password)
            //    return u;
            //return null;
        }
        public async Task PutDL(int id, User user)
        {
            User userToUpdate = await _myDB.Users.FindAsync(id);
            if (userToUpdate == null)
            {
                return;
            }
            _myDB.Entry(userToUpdate).CurrentValues.SetValues(user);
            await _myDB.SaveChangesAsync();
        }
        public async Task DeleteDL(int id)
        {
            User u = await _myDB.Users.FindAsync(id);
            _myDB.Users.Remove(u);
            await _myDB.SaveChangesAsync();
        }
    }
}
