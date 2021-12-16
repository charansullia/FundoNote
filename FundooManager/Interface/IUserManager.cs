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
        string Login(LoginModel loginDetail);
        Task<string> Reset(ResetModel reset);
        string Forget(ForgetModel forget);
        string GenerateToken(string Email);

    }
}
