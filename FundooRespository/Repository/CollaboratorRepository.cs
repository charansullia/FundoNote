using FundooModel;
using FundooRespository.Context;
using FundooRespository.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public string DeleteCollaborator(CollaboratoryModel collaborator)
        {
            try
            {
                var collaboratorExist = this.context.Collaborator.Where(x => x.CollaboratorId == collaborator.CollaboratorId).SingleOrDefault();
                if (collaboratorExist != null)
                {
                    this.context.Collaborator.Remove(collaboratorExist);
                    this.context.SaveChanges();
                    return "Collaborator Deleted Successfully";
                }
                return "Collaborator Not Exist";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
   
