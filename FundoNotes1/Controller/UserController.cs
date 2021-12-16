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
        public IActionResult Register([FromBody] RegisterModel register)
        {
            try
            {
                this.logger.LogInformation(register.FirstName + " " + register.LastName + " is trying to Register");
                string message = this.manager.Register(register);
                if (message.Equals("Registration Successfully"))
                {
                    this.logger.LogInformation(register.FirstName + " " + register.LastName + message);
                    return this.Ok(new { Status = true, Message = message });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = message });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, ex.Message });
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
                if (message.Equals("Login Successful"))
                {
                    this.logger.LogInformation(logins.Email + " " + logins.Password + message);
                    ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379");
                    IDatabase database = connectionMultiplexer.GetDatabase();
                    string firstName = database.StringGet("First Name");
                    string lastName = database.StringGet("Last Name");
                    string email = database.StringGet("Email");
                    int userId = Convert.ToInt32(database.StringGet("UserId"));

                    RegisterModel data = new RegisterModel
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        UserId = userId,
                        Email = email
                    };
                    string tokenString = this.manager.GenerateToken(logins.Email);
                    return this.Ok(new { Status = true, Message = message, Data = data, Token = tokenString });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = message });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, ex.Message });
            }
        }
        [HttpPut]
        [Route("api/Reset")]
        public IActionResult Reset([FromBody] ResetModel reset)
        {
            try
            {
                this.logger.LogInformation(reset.Email + " " + reset.Password + " is trying to Reset");
                string message = this.manager.Reset(reset);
                if (message.Equals("Password Reset Successful"))
                {
                    this.logger.LogInformation(reset.Email + " " + reset.Password + message);
                    return this.Ok(new { Status = true, Message = message });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = message });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, ex.Message });
            }
        }
        [HttpPost]
        [Route("api/forget")]
        public IActionResult Forget([FromBody] ForgetModel forget)

        {
            try
            {
                this.logger.LogInformation(forget.Email + " is trying to forget");
                string message = this.manager.Forget(forget);
                if (message.Equals("Reset Link send to Your Email"))
                {
                    return this.Ok(new { Status = true, Message = message });

                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = message });
                }

            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, ex.Message });
            }
        }

    }
}
