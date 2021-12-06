using FundooModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FundooManager.Interface
{
   public interface IUserManager
    {
        string Register(RegisterModel user);
        Task<string> Login(LoginModel loginDetail);
        Task<string> Reset(ResetModel reset);
        Task<string> Forget(ForgetModel Email);
        string GenerateToken(string Email);

    }
}
