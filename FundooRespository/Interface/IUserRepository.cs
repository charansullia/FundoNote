using FundooModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FundooRespository.Interface
{
   public interface IUserRepository
    {
          Task<bool> Register(RegisterModel register);
          bool Login (LoginModel logins);
          Task<bool> ResetPassword(ResetModel reset);
          bool ForgotPassword(ForgetModel forget);
          string TokenGeneration(string Email);

    }
}
