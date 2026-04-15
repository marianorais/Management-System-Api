using ManagementSystemAPI.Core.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystemAPI.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();
        Task<User?> GetById(int id);
        Task<User> Create(User user);
        Task<User?> Update(User user);
        Task<bool> Delete(int id);
    }
}
