using Experimental.System.Messaging;
using FundooModel;
using FundooRespository.Context;
using FundooRespository.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;

namespace FundooRespository.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext context;
        private readonly IConfiguration configuration;
        public UserRepository(UserContext context,IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
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
            loginDetails.Password = EncodePasswordToBase64(loginDetails.Password);
            try
            {
                var ifEmailExist = this.context.Users.Where(x => x.Email == loginDetails.Email && x.Password == loginDetails.Password).SingleOrDefault();
                if (ifEmailExist != null)
                {
                    return "Login Successful";
                }
                    return "Incorrect Password";
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
        public string GenerateToken(string Email)
        {
            byte[] key = Encoding.UTF8.GetBytes(this.configuration["Credentials:Secret"]);
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                      new Claim(ClaimTypes.Name, Email)}),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(securityKey,
                SecurityAlgorithms.HmacSha256Signature)
            };

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = handler.CreateJwtSecurityToken(descriptor);
            return handler.WriteToken(token);
        }
        public string Forget(string Email)
        {
            try
            {
                var ifEmailExist = this.context.Users.Where(x => x.Email ==Email).SingleOrDefault();
                if (ifEmailExist != null)
                {
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                    mail.From = new MailAddress(this.configuration["Credentials:Email"]);
                    mail.To.Add(Email);
                    SendMSMQ();
                    mail.Body = RecieveMSMQ();

                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential(this.configuration["Credentials:Email"], this.configuration["Credentials:Password"]);
                    SmtpServer.EnableSsl = true;
                    SmtpServer.Send(mail);


                    return "Reset Link send to Your Email";
                }
                return "Email does not exist";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void SendMSMQ()
        {
            MessageQueue msgqueue;
            if (MessageQueue.Exists(@".\Private$\Fundoo"))
            {
                msgqueue = new MessageQueue(@".\Private$\Fundoo");
            }
            else
            {
                msgqueue = MessageQueue.Create(@".\Private$\Fundoo");
            }
            msgqueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
            string body = "This is Password reset link.ResetLink=>";
            msgqueue.Label = "Mail Body";
            msgqueue.Send(body);
        }
        public string RecieveMSMQ()
        {
            MessageQueue messagequeue = new MessageQueue(@".\Private$\Fundo");
            var recievemsg = messagequeue.Receive();
            recievemsg.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
            return recievemsg.ToString();
        }

    }
}
    