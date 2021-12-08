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
    }
}
