using FundooModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooManager.Interface
{
   public interface ILabelManager
    {
        string AddLabel(LabelModel label);
        string DeleteLabel(LabelModel label);
        string EditLabel(LabelModel label);
        string RemoveLabelFromNote(int LabelId);
        IEnumerable<LabelModel> GetLabelByNoteId(int NoteId);
        IEnumerable<LabelModel> GetLabelByUserId(int UserId);
    }
}
