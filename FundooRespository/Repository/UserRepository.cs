using FundooModel;
using FundooRespository.Context;
using FundooRespository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FundooRespository.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext context;
        public UserRepository(UserContext context)
        {
            this.context = context;
        }
        public string Register(RegisterModel user)
        {
            try
            {
                var ifExist = this.context.Users.Where(x => x.Email == user.Email).SingleOrDefault();
                if (ifExist == null)
                {
                    this.context.Users.Add(user);
                    this.context.SaveChanges();
                    return "Register Successfull";
                }
                    return "Email already exists";
                

            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string Login(LoginModel loginDetails)
        {
            try
            {
                var ifEmailExist = this.context.Users.Where(x => x.Email == loginDetails.Email && x.Password == loginDetails.Password).SingleOrDefault();
                if (ifEmailExist != null)
                {
                    return "Login Successful";
                }
                    return "Email not exist";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
    