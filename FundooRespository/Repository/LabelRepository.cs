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
   public class LabelRepository:ILabelRepository
    {
        private readonly UserContext context;
        private readonly IConfiguration configuration;
        public LabelRepository(UserContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        public string AddLabel(LabelModel label)
        {
            try
            {
                this.context.Label.Add(label);
                this.context.SaveChanges();
                return "Label Created Successfully";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string DeleteLabel(LabelModel label)
        {
            try
            {
                var LabelExist = this.context.Label.Where(x => x.LabelId ==label.LabelId).FirstOrDefault();
                if (LabelExist != null)
                {
                    this.context.Label.Remove(LabelExist);
                    this.context.SaveChanges();
                    return "Label Deleted Forever";
                }
                return "Note Not Exist";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string EditLabel(LabelModel label)
        {
            try
            {
                var labelExist = this.context.Label.Where(x => x.LabelId == label.LabelId).FirstOrDefault();
                if (labelExist != null)
                {
                    labelExist.Label = label.Label;
                    this.context.Label.Update(labelExist);
                    this.context.SaveChanges();
                    return "Label Edited Successfully";
                }
                return "Label not Found";
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
                var labelExist =this.context.Label.Where(x => x.LabelId == LabelId).FirstOrDefault();
                if (labelExist != null)
                {
                    labelExist.NoteId = null;
                    this.context.SaveChanges();
                    return "Label Removed Successfully";
                }
                return "Note not Found";
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
                IEnumerable<LabelModel> LabelList = this.context.Label.Where(x => x.NoteId == NoteId).ToList();
                if (LabelList.Count() != 0)
                {
                    return LabelList;
                }
                return null;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<LabelModel> GetLabelByUserId(int UserId)
        {
            try
            {
                IEnumerable<LabelModel> LabelList = this.context.Label.Where(x => x.UserId == UserId).ToList();
                if (LabelList.Count() != 0)
                {
                    return LabelList;
                }
                return null;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
