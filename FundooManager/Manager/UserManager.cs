using FundooManager.Interface;
using FundooModel;
using FundooRespository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooManager.Manager
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository repository;

        public UserManager(IUserRepository repository)
        {
            this.repository = repository;
        }

        public string Register(RegisterModel register)
        {
            try
            {
                register.Password = EncodePassword(register.Password);
                return this.repository.Register(register);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static string EncodePassword(string Password)
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
        public string Login(LoginModel logins)
        {
            try
            {
                return this.repository.Login(logins);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
      
  
        public string Reset(ResetModel reset)
        {
            try
            {
                return this.repository.Reset(reset);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string Forget(ForgetModel forget)
        {
            try
            {
                return this.repository.Forget(forget);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string GenerateToken(string Email)
        {
            try
            {
                return this.repository.TokenGeneration(Email);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }

}
