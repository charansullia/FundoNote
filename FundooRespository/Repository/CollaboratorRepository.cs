using FundooModel;
using FundooRespository.Context;
using FundooRespository.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooRespository.Repository
{
    public class CollaboratorRepository : ICollaboratoryRepository
    {
        private readonly UserContext context;
        private readonly IConfiguration configuration;
        public CollaboratorRepository(UserContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }
       public string AddCollaborator(CollaboratoryModel collaborator)
        {
            try
            {
                this.context.Collaborator.Add(collaborator);
                this.context.SaveChanges();
                return "Collaborator Added Successfully";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
   
