﻿using FundooManager.Interface;
using FundooModel;
using FundooRespository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FundooManager.Manager
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository repository;

        public UserManager(IUserRepository repository)
        {
            this.repository = repository;
        }

        public async Task<string> Register(RegisterModel register)
        {
            try
            {
                register.Password = EncodePassword(register.Password);
                return await this.repository.Register(register);
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
      
  
        public async Task<string> ResetPassword(ResetModel reset)
        {
            try
            {
                return await this.repository.ResetPassword(reset);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string ForgotPassword(ForgetModel forget)
        {
            try
            {
                return this.repository.ForgotPassword(forget);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string TokenGeneration(string Email)
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
