using Hw_Week12.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw_Week12.Contract
{
    public interface IAuthentication
    {
        public Result Login(string username, string password);
        public Result Register(User user, string pass);
        public Result CheckUsername(string userName);
        public void LogOut();
    }
}
