using FundooModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FundooManager.Interface
{
   public interface IUserManager
    {
        string Register(RegisterModel register);
        string Login(LoginModel logins);
        string Reset(ResetModel reset);
        string Forget(ForgetModel forget);
        string GenerationofToken(string Email);

    }
}
