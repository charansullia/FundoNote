using FundooModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FundooManager.Interface
{
   public interface IUserManager
    {
        Task<bool> Register(RegisterModel register);
        bool Login(LoginModel logins);
        Task<bool> ResetPassword(ResetModel reset);
        bool ForgotPassword(ForgetModel forget);
        string TokenGeneration(string Email);

    }
}
