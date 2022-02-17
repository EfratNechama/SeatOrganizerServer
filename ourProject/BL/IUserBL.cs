using Entities;
using System;
using System.Threading.Tasks;

namespace BL
{
    public interface IUserBL
    {
        Task PostBL(User user);
        Task<User> GetByPassAndEmailBL(string email);
        Task PutBL(int id, User user);
        Task DeleteBL(int id);
    }
}