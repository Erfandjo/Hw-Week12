using Hw_Week12.Contract;
using Hw_Week12.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hw_Week12;
using System.Threading.Tasks;

namespace Hw_Week12.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public  UserRepository()
        {
            _appDbContext = new AppDbContext();
        }

        public User GetForUserName(string userName)
        {
            return _appDbContext.Users.FirstOrDefault(u => u.UserName == userName);
        }

        public bool Login(string userName , string pass)
        {
            return _appDbContext.Users.Any(t => t.UserName == userName && t.Password == pass);
            
        }

      

        public void Register(User user)
        {
            _appDbContext.Users.Add(user);
            _appDbContext.SaveChanges();
        }
    }
}
