using FundooModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooManager.Interface
{
   public interface IUserManager
    {
        string Register(RegisterModel register);
        string Login(LoginModel logins);
        string Reset(ResetModel reset);
        string Forget(ForgetModel forget);
        string GenerateToken(string Email);

    }
}
