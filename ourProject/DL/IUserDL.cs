using Entities;
using System;
using System.Threading.Tasks;

namespace DL
{
    public interface IUserDL
    {
        Task PostDL(User user);
        Task PutDL(int id,User user);
        Task<User> GetByPassAndEmailDL(string email, string password);
        Task DeleteDL(int id);


    }

}