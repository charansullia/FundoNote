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
        public string DeleteLabel(LabelModel label)
        {
            try
            {
                return this.LabelRepository.DeleteLabel(label);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string EditLabel(LabelModel label)
        {
            try
            {
                return this.LabelRepository.EditLabel(label);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string RemoveLabelFromNote(int LabelId)
        {
            try
            {
                return this.LabelRepository.RemoveLabelFromNote(LabelId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<LabelModel> GetLabelByNoteId(int NoteId)
        {
            try
            {
                return this.LabelRepository.GetLabelByNoteId(NoteId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public IEnumerable<LabelModel> GetLabelByUserId(int UserId)
        {
            try
            {
                return this.LabelRepository.GetLabelByUserId(UserId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
