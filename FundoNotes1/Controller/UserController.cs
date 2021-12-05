using FundooManager.Interface;
using FundooModel;
using Microsoft.AspNetCore.Mvc;
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

        public UserController(IUserManager manager)
        {
            this.manager = manager;
        }

        [HttpPost]
        [Route("api/register")]
        public async Task<IActionResult>Register([FromBody] RegisterModel user)
        {
            try
            {
                string message =await this.manager.Register(user);
                if (message.Equals("Register Successfull"))
                {
                    return  this.Ok(new { Status = true, Message = message });
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
        public async Task<IActionResult> Login([FromBody] LoginModel loginDetails)
        {
            try
            {
                string message =await this.manager.Login(loginDetails);
                if (message.Equals("Login Successful"))
                {
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
                    string tokenString = this.manager.GenerateToken(loginDetails.Email);
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
        public async Task<IActionResult> Reset([FromBody] ResetModel reset)
        {
            try
            {
                string message =await this.manager.Reset(reset);
                if (message.Equals("Password Reset Successful"))
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
        [HttpPost]
        [Route("api/forget")]
        public async Task<IActionResult> Forget([FromBody] ForgetModel forget)

        {
            try
            {
                string message = await this.manager.Forget(forget);
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



