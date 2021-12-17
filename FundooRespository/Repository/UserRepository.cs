using Experimental.System.Messaging;
using FundooModel;
using FundooRespository.Context;
using FundooRespository.Interface;
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
        public string Register(RegisterModel register)
        {
            try
            {
<<<<<<< HEAD
                register.Password = EncodePassword(register.Password);
=======
                register.Password = EncodingPasswordToBase64(register.Password);
>>>>>>> a205e25dd7e512f6c693be4de064219cbb14cd9d
                var Registration = this.context.Users.Where(x => x.FirstName == register.FirstName).SingleOrDefault();
                if (Registration == null)
                {
                    this.context.Users.Add(register);
                    this.context.SaveChanges();
                    return "Registration Successfully";
                }
                    return "FirstName already exist";
                

            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
       
        public string Login(LoginModel logins)
        {
<<<<<<< HEAD
                logins.Password = EncodePassword(logins.Password);
                try
                {
                    var Email = this.context.Users.Where(x => x.Email == logins.Email).SingleOrDefault();
                    if (Email != null)
                    {
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
                            return "Login Successfuly";
                        }
                        return "Incorrect Password";
                    }
                    return "Email Does not exist";
                }
                catch (ArgumentNullException ex)
                {
                    throw new Exception(ex.Message);
=======
            logins.Password = EncodingPasswordToBase64(logins.Password);
            try
            {
                var Email = this.context.Users.Where(x => x.Email == logins.Email).SingleOrDefault();
                if (Email != null)
                {
                    var Password = this.context.Users.Where(x => x.Password == logins.Password).SingleOrDefault();
                    if(Password !=null)
                    {
                        ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect("127.0.0.1:6379");
                        IDatabase database = connectionMultiplexer.GetDatabase();
                        database.StringSet(key: "First Name",Email.FirstName);
                        database.StringSet(key: "Last Name",Email.LastName);
                        database.StringSet(key: "Email",Email.Email);
                        database.StringSet(key: "UserId",Email.UserId.ToString());
                        //return user != null ? "Login Successful" : "Login failed!! Email or password wrong";
                        return "Login Successfully";
                    }
                    return "Password doesnt exist";
                   
>>>>>>> a205e25dd7e512f6c693be4de064219cbb14cd9d
                }
            }
        public string Reset(ResetModel reset)
        {
            try
            {
                var Email = this.context.Users.Where(x => x.Email == reset.Email).SingleOrDefault();
                if(Email!=null)
                {
<<<<<<< HEAD
                    ifEmailExist.Password = EncodePassword(reset.Password);
                    this.context.Update(ifEmailExist);
=======
                    Email.Password = EncodingPasswordToBase64(reset.Password);
                    this.context.Update(Email);
>>>>>>> a205e25dd7e512f6c693be4de064219cbb14cd9d
                    this.context.SaveChanges();
                    return "Reset of Password successfull";
                }
                return "Email not exist";
            }
            catch(ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
<<<<<<< HEAD
        public static string EncodePassword(string Password)
=======
        public static string EncodingPasswordToBase64(string Password)
>>>>>>> a205e25dd7e512f6c693be4de064219cbb14cd9d
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
<<<<<<< HEAD
        public string TokenGeneration(string Email)
=======
        public string GenerationofToken(string Email)
>>>>>>> a205e25dd7e512f6c693be4de064219cbb14cd9d
        {
            byte[] key = Convert.FromBase64String(this.configuration["Credentials:Secret"]);
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
        public string Forget(ForgetModel forget)
        {
            try
            {
                var RegisteredEmail = this.context.Users.Where(x => x.Email ==forget.Email).SingleOrDefault();
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


                    return "Reset of PasswordLink send successfully";
                }
                return "Email not exist";
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
    