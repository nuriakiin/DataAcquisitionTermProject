using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAcquisitionTermProject.Models
{
    public class UserRepository : IUserRepository
    {
        private DataContext context;

        public UserRepository(DataContext dataContext) => context = dataContext;

        public IEnumerable<User> Users => context.Users.ToArray();

        public void AddUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public void AddUserRange(IEnumerable<User> users)
        {
            context.Users.AddRange(users);
            context.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            context.Users.Remove(user);
            context.SaveChanges();

        }

        public User GetUser(long key)
        {
            return (context.Users.First(s => s.UserId == key));
        }

        public void UpdateUser(User user)
        {
           context.Users.Update(context.Users.Find(user.UserId));
            context.SaveChanges();
        }
    }
}
