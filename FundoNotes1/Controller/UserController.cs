using FundooManager.Interface;
using FundooModel;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Register([FromBody] RegisterModel user)
        {
            try
            {
                string message = this.manager.Register(user);
                if (message.Equals("Register Successfull"))
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
        [Route("api/Login")]
        public IActionResult Login([FromBody] LoginModel loginDetails)
        {
            try
            {
                string message = this.manager.Login(loginDetails);
                if (message.Equals("Login Successful"))
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
        //[HttpPost]
        //[Route("api/Encrypt")]
        //public IActionResult Encrypt([FromBody] EncryptModel encryptDetails)
        //{
        //    try
        //    {
        //        string message = this.manager.Encrypt(encryptDetails);
        //        if (message.Equals("Encrypted"))
        //        {
        //            return this.Ok(new { status = true, Message = message });
        //        }
        //        else
        //        {
        //            return this.BadRequest(new { status = false, Message = message });
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        return this.NotFound(new { status = false, ex.Message });
        //    }
        //}


    }
}



