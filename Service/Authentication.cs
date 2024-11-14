using Hw_Week12.Contract;
using Hw_Week12.Entities;
using Hw_Week12.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw_Week12.Service
{
    public class Authentication : IAuthentication
    {
        IUserRepository Repo;
        public Authentication()
        {
            Repo = new UserRepository();
        }

        public Result CheckUsername(string userName)
        {
            if (Repo.GetForUserName(userName) is not null)
            {

                return new Result(true, "User Name Exist");

            }

            return new Result(false);
        }

        public Result Login(string userName, string password)
        {
            var user = Repo.GetForUserName(userName);
            if (Repo.Login(userName , password))
            {
                OnlineUser.CurrentUser = user;
                return new Result(true , "Success");
            }
            return new Result(false, "UserName or Password Incorrect.");
        }

        public Result Register(User user, string pass)
        {
            var Result = user.SetPassword(pass);
            if (!CheckUsername(user.UserName).IsSucces)
            {
                if (Result.IsSucces)
                {
                    Repo.Register(user);
                    return new Result(true , "Success");
                }
                else
                {
                    return new Result(false, Result.Message);
                }
            }
            else
            {
                return CheckUsername(user.UserName);
            }

        }

        public void LogOut()
        {
            OnlineUser.CurrentUser = null;
        }
    }
}
