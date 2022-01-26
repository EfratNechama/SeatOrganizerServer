using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL;
using Entities;

namespace BL
{
    public class UserBL : IUserBL
    {
        IUserDL iuserdl;

        public UserBL(IUserDL iuserdl)
        {
            this.iuserdl = iuserdl;
        }

        public async Task PostBL(User user)
        {
            await iuserdl.PostDL(user);
        }

        public async Task<User> GetByPassAndEmailBL(string email, string password)
        {
            return await iuserdl.GetByPassAndEmailDL(email, password);
        }

        public async Task PutBL(int id, User user)
        {
            await iuserdl.PutDL(id, user);
        }
        public async Task DeleteBL(int id)
        {
            await iuserdl.DeleteDL(id);
        }

    }

}
