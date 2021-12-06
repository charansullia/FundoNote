using FundooModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooManager.Interface
{
 public interface ICollaboratoryManager
    {
        string AddCollaborator(CollaboratoryModel collaborator);
        string DeleteCollaborator(CollaboratoryModel collaborator);
        IEnumerable<CollaboratoryModel> GetCollaborator(int NoteId);
    }
}
