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
         Task<string> Reset(ResetModel reset);
          string Forget(ForgetModel forget);
<<<<<<< HEAD
          string TokenGeneration(string Email);
=======
          string GenerationofToken(string Email);
>>>>>>> a205e25dd7e512f6c693be4de064219cbb14cd9d

    }
}
