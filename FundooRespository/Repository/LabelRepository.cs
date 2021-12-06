using FundooModel;
using FundooRespository.Context;
using FundooRespository.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooRespository.Repository
{
   public class LabelRepository:ILabelRepository
    {
        private readonly UserContext context;
        private readonly IConfiguration configuration;
        public LabelRepository(UserContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }
        public string AddLabel(LabelModel label)
        {
            try
            {
                this.context.Label.Add(label);
                this.context.SaveChanges();
                return "Label Created Successfully";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
