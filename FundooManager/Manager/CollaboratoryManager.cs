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
        private readonly ICollaboratoryRepository CollaboratoryRepository;
        public CollaboratoryManager(ICollaboratoryRepository CollaboratoryRepository)
        {
            this.CollaboratoryRepository = CollaboratoryRepository;
        }
        public string AddCollaborator(CollaboratoryModel collaborator)
        {
            try
            {
                return this.CollaboratoryRepository.AddCollaborator(collaborator);
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
                return this.CollaboratoryRepository.DeleteCollaborator(collaborator);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<CollaboratoryModel> GetCollaborator(int NoteId)
        {
            try
            {
                return this.CollaboratoryRepository.GetCollaborator(NoteId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
