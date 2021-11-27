using FundooModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooRespository.Context
{
   public class UserContext:DbContext
    {
        public UserContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<RegisterModel> Users { get; set; }
       // public DbSet<LoginModel> loginDetails { get; set; }
        //public DbSet<ResetModel> reset { get; set; }
    }
}
