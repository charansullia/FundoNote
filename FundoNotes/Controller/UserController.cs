using FundooManager.Interface;
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
                bool message =await this.manager.Register(register);
                if (message==true)
                {
                    this.logger.LogInformation(register.FirstName + " " + register.LastName + message);
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "RegistrationSuccessfull" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message ="RegistrationUnSuccessful" });
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
                bool message = this.manager.Login(logins);
                if (message==true)
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
                    return this.Ok(new { Status = true, Message = "LoginSucessfull", Data = data, Token = tokenString });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message ="LoginUnSuccessful" });
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
                bool message =await this.manager.ResetPassword(reset);
                if (message.Equals(true))
                {
                    this.logger.LogInformation(reset.Email + " " + reset.Password + message);
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Password Reset Successfull" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Password Reset Unsucessfull" });
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
                bool message = this.manager.ForgotPassword(forget);
                if (message.Equals(true))
                {
                    this.logger.LogInformation(forget.Email + " " + message);
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = " Password Link Send Sucessfully" });

                }
                else
                {
                    return this.BadRequest(new ResponseModel<bool>() { Status = false, Message = "Password Link send Unsuccessfully " });
                }

            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<bool>() { Status = false, Message = ex.Message });
            }
        }

    }
}
