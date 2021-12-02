using FundooModel;
using FundooRespository.Context;
using FundooRespository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooRespository.Repository
{
  public class NoteRepository:INoteRepository
    {
        private readonly UserContext context;

        public NoteRepository(UserContext context)
        {
            this.context = context;
        }

        public string AddNote(NoteModel note)
        {
            try
            {
                this.context.Note.Add(note);
                this.context.SaveChanges();
                return "Note Added Successfully";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
