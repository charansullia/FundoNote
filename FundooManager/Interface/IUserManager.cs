using FundooModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooManager.Interface
{
   public interface IUserManager
    {
        string Register(RegisterModel user);
        string Login(LoginModel loginDetail);
        string Reset(ResetModel reset);
        string Forget(string Email);
        string GenerateToken(string Email);

    }
}
