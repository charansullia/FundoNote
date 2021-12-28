using Experimental.System.Messaging;
using FundooModel;
using FundooRespository.Context;
using FundooRespository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<bool> Register(RegisterModel register)
        {
            try
            {
                var Registration = this.context.Users.Where(x => x.Email == register.Email).SingleOrDefault();
                if (Registration == null)
                {
                    register.Password = EncodePassword(register.Password);
                    this.context.Users.Add(register);
                    await this.context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Login(LoginModel logins)
        {
            try
            {
                var Email = this.context.Users.Where(x => x.Email == logins.Email).SingleOrDefault();
                if (Email != null)
                {
                    logins.Password = EncodePassword(logins.Password);
                    var Password = this.context.Users.Where(x => x.Password == logins.Password).SingleOrDefault();
                    if (Password != null)
                    {
                        ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379");
                        IDatabase database = connectionMultiplexer.GetDatabase();
                        database.StringSet(key: "First Name", Email.FirstName);
                        database.StringSet(key: "Last Name", Email.LastName);
                        database.StringSet(key: "Email", Email.Email);
                        database.StringSet(key: "UserId", Email.UserId.ToString());
                        //return user != null ? "Login Successful" : "Login failed!! Email or password wrong";
                        return true;
                    }
                    return false;
                }
                return false;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);

            }
        }
        public async Task<bool> ResetPassword(ResetModel reset)
        {
            try
            {
                var Email = this.context.Users.Where(x => x.Email == reset.Email).SingleOrDefault();
                if (Email != null)
                {
                    Email.Password = EncodePassword(reset.Password);
                    this.context.Update(Email);
                    await this.context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (ArgumentNullException ex)
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
        public string TokenGeneration(string Email)
        {
            byte[] key = Convert.FromBase64String(this.configuration["SecretKey"]);
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
        public bool ForgotPassword(ForgetModel forget)
        {
            try
            {
                var RegisteredEmail = this.context.Users.Where(x => x.Email == forget.Email).SingleOrDefault();
                if (RegisteredEmail != null)
                {
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                    mail.From = new MailAddress(this.configuration["Credentials:Email"]);
                    mail.To.Add(forget.Email);
                    SendMSMQ();
                    mail.Body = RecieveMSMQ();

                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential(this.configuration["Credentials:Email"], this.configuration["Credentials:Password"]);
                    SmtpServer.EnableSsl = true;
                    SmtpServer.Send(mail);
                    return true;
                }
                return false;
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
            string body = "This is Password reset link.";
            msgqueue.Label = "Mail Body";
            msgqueue.Send(body);
        }
        public string RecieveMSMQ()
        {
            MessageQueue Messagequeue = new MessageQueue(@".\Private$\Fundoo");
            var recievemsg = Messagequeue.Receive();
            recievemsg.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
            return recievemsg.Body.ToString();
        }

    }
}
    