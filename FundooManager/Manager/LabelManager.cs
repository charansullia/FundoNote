using FundooManager.Interface;
using FundooModel;
using FundooRespository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooManager.Manager
{
  public class LabelManager:ILabelManager
    {
        private readonly ILabelRepository LabelRepository;
        public LabelManager(ILabelRepository labelRepository)
        {
            this.LabelRepository = labelRepository;
        }
        public string AddLabel(LabelModel label)
        {
            try
            {
                return this.LabelRepository.AddLabel(label);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
