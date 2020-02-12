using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAcquisitionTermProject.Models
{
    public interface IUserRepository
    {
        IEnumerable<User> Users { get; }
        User GetUser(long key);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
        void AddUserRange(IEnumerable<User> users);
    }
}
