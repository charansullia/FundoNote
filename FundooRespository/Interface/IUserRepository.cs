using FundooModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FundooRespository.Interface
{
   public interface IUserRepository
    {
          string Register(RegisterModel user);
          Task<string> Login(LoginModel loginDetails);
          Task<string> Reset(ResetModel reset);
          Task< string> Forget(ForgetModel forget);
          string GenerateToken(string Email);

    }
}
