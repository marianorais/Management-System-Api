using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using global::ManagementSystemAPI.Core.Models.Domain;

namespace ManagementSystemAPI.Data.Interfaces
{

    namespace ManagementSystemAPI.Data.Repositories
    {
        public interface IBookRepository
        {
            Task<List<Book>> GetAll();
            Task<Book?> GetById(int id);
            Task<Book> Create(Book book);
            Task<Book?> Update(Book book);
            Task<bool> Delete(int id);
        }
    }
}
