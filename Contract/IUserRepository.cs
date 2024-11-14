using Hw_Week12.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw_Week12.Contract
{
    public interface IUserRepository
    {
        public bool Login(string userName, string pass);
        public void Register(User user);
        
        public User GetForUserName(string userName);
    }
}
