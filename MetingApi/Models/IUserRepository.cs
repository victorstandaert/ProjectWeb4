using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public interface IUserRepository
    {
        User GetBy(string Email);
        void Add(User user);
        void SaveChanges();
    }
}
