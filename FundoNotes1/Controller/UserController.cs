﻿using FundooManager.Interface;
using FundooModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Contollers
{
    public class UserController : ControllerBase
    {
        private readonly IUserManager manager;
        private readonly ILogger<UserController> logger;
        public UserController(IUserManager manager, ILogger<UserController> logger)
        {
            this.manager = manager;
            this.logger = logger;
        }

        [HttpPost]
        [Route("api/register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel register)
        {
            try
            {
                this.logger.LogInformation(register.FirstName + " " + register.LastName + " is trying to Register");
                string message =await this.manager.Register(register);
                if (message.Equals("Registration Successfully"))
                {
                    this.logger.LogInformation(register.FirstName + " " + register.LastName + message);
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = message });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = message });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
        [HttpPut]
        [Route("api/Login")]
        public IActionResult Login([FromBody] LoginModel logins)
        {
            try
            {
                this.logger.LogInformation(logins.Email + " " + logins.Password + " is trying to Login");
                string message = this.manager.Login(logins);
                if (message.Equals("Login Successfuly"))
                {
                    this.logger.LogInformation(logins.Email + " " + logins.Password + message);
                    ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379");
                    IDatabase database = connectionMultiplexer.GetDatabase();
                    string FirstName = database.StringGet("First Name");
                    string LastName = database.StringGet("Last Name");
                    string Email = database.StringGet("Email");
                    int UserId = Convert.ToInt32(database.StringGet("UserId"));

                    RegisterModel data = new RegisterModel
                    {
                        FirstName = FirstName,
                        LastName = LastName,
                        UserId = UserId,
                        Email = Email
                    };
                    string tokenString = this.manager.TokenGeneration(logins.Email);
                    return this.Ok(new { Status = true, Message = message, Data = data, Token = tokenString });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = message });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
        [HttpPut]
        [Route("api/Reset")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetModel reset)
        {
            try
            {
                this.logger.LogInformation(reset.Email + " " + reset.Password + " is trying to Reset");
                string message =await this.manager.ResetPassword(reset);
                if (message.Equals("Reset of Password successfull"))
                {
                    this.logger.LogInformation(reset.Email + " " + reset.Password + message);
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = message });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = message });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
        [HttpPost]
        [Route("api/forgetPassword")]
        public IActionResult Forget([FromBody] ForgetModel forget)

        {
            try
            {
                this.logger.LogInformation(forget.Email + " is trying to forgetPassword");
                string message = this.manager.ForgotPassword(forget);
                if (message.Equals("Reset of PasswordLink send successfully"))
                {
                    this.logger.LogInformation(forget.Email + " " + message);
                    return this.Ok(new ResponseModel<bool>() { Status = true, Message = message });

                }
                else
                {
                    return this.BadRequest(new ResponseModel<bool>() { Status = false, Message = message });
                }

            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<bool>() { Status = false, Message = ex.Message });
            }
        }

    }
}
