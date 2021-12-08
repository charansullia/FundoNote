using FundooModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooRespository.Interface
{
   public interface ILabelRepository
    {
        string AddLabel(LabelModel label);
        string DeleteLabel(LabelModel label);
        string EditLabel(LabelModel label);
        string RemoveLabelFromNote(int LabelId);
    }
}
