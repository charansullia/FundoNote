using FundooModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FundooRespository.Interface
{
   public interface IUserRepository
    {
          string Register(RegisterModel register);
          string Login(LoginModel logins);
          string Reset(ResetModel reset);
          string Forget(ForgetModel forget);
          string TokenGeneration(string Email);

    }
}
