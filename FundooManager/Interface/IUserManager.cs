using FundooModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FundooManager.Interface
{
   public interface IUserManager
    {
        Task<string> Register(RegisterModel register);
        string Login(LoginModel logins);
        Task<string> ResetPassword(ResetModel reset);
        string ForgotPassword(ForgetModel forget);
        string TokenGeneration(string Email);

    }
}
