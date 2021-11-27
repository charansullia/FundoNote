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
                user.Password = EncodePasswordToBase64(user.Password);
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
        public string Reset(ResetModel reset)
        {
            try
            {
                var ifEmailExist = this.context.Users.Where(x => x.Email == reset.Email).SingleOrDefault();
                if(ifEmailExist!=null)
                {
                    ifEmailExist.Password = EncodePasswordToBase64(reset.Password);
                    this.context.Update(ifEmailExist);
                    this.context.SaveChanges();
                    return "Password Reset Successful";
                }
                return "Email does not exist";
            }
            catch(ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static string EncodePasswordToBase64(string Password)
        {
            try
            {
                byte[] encData_byte = new byte[Password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(Password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("error in Base64Encode" + ex.Message);
            }
        }
    }
}
    