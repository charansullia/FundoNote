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

        public string Register(RegisterModel user)
        {
            try
            {
               // user.Password = EncodePasswordToBase64(user.Password);
                return this.repository.Register(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //public static string EncodePasswordToBase64(string Password)
        //{
        //    try
        //    {
        //        byte[] encData_byte = new byte[Password.Length];
        //        encData_byte = System.Text.Encoding.UTF8.GetBytes(Password);
        //        string encodedData = Convert.ToBase64String(encData_byte);
        //        return encodedData;
        //    }
        //    catch(Exception ex)
        //    {
        //        throw new Exception("error in Base64Encode" + ex.Message);
        //    }
        //}
        public string Login(LoginModel loginDetails)
        {
            try
            {
                return this.repository.Login(loginDetails);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
      
  
    }

}
