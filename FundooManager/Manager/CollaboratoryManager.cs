using FundooManager.Interface;
using FundooModel;
using FundooRespository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooManager.Manager
{
  public class CollaboratoryManager:ICollaboratoryManager
    {
        private readonly ICollaboratoryRepository CollaboratoyRepository;
        public CollaboratoryManager(ICollaboratoryRepository CollaboratoryRepository)
        {
            this.CollaboratoyRepository = CollaboratoryRepository;
        }
        public string AddCollaborator(CollaboratoryModel collaborator)
        {
            try
            {
                return this.CollaboratoyRepository.AddCollaborator(collaborator);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string DeleteCollaborator(CollaboratoryModel collaborator)
        {
            try
            {
                return this.CollaboratoyRepository.DeleteCollaborator(collaborator);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
