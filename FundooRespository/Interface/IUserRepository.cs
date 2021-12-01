using FundooModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooRespository.Interface
{
   public interface IUserRepository
    {
          string Register(RegisterModel user);
          string Login(LoginModel loginDetails);
          string Reset(ResetModel reset);
          string Forget(string forget);
          string GenerateToken(string Email);

    }
}
