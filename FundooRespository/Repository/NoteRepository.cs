﻿using FundooModel;
using FundooRespository.Context;
using FundooRespository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public string Update(NoteModel note)

        {
            try
            {
                var noteExist = this.context.Note.Where(x => x.NoteId == note.NoteId).FirstOrDefault();
                if (noteExist != null)
                {
                    noteExist.Title = note.Title;
                    this.context.Note.Update(noteExist);
                    this.context.SaveChanges();
                    return "Title Updated Successfully";
                }
                return "Title Not Updated";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string UpdateDescription(NoteModel note)
        {
            try
            {
                var noteExist = this.context.Note.Where(x => x.NoteId == note.NoteId).SingleOrDefault();
                if (noteExist != null)
                {
                    noteExist.Description = note.Description;
                    this.context.Note.Update(noteExist);
                    this.context.SaveChanges();
                    return "Description Updated Successfully";
                }
                return "Description Not Updated";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
