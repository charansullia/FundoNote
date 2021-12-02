using FundooModel;
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
        public string UpdateReminder(NoteModel note)
        {
            try
            {
                var noteExist = this.context.Note.Where(x => x.NoteId == note.NoteId).SingleOrDefault();
                if (noteExist != null)
                {
                    noteExist.Reminder = note.Reminder;
                    this.context.Note.Update(noteExist);
                    this.context.SaveChanges();
                    return "Reminder Updated Successfully";
                }
                return "Reminder Not Updated";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string UpdateColour(NoteModel note)
        {
            try
            {
                var noteExist = this.context.Note.Where(x => x.NoteId == note.NoteId).SingleOrDefault();
                if (noteExist != null)
                {
                    noteExist.Colour = note.Colour;
                    this.context.Note.Update(noteExist);
                    this.context.SaveChanges();
                    return "Colour Updated Successfully";
                }
                return "Colour Not Updated";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string UpdatePin(NoteModel note)
        {
            try
            {
                var noteExist = this.context.Note.Where(x => x.NoteId == note.NoteId).SingleOrDefault();
                if (noteExist != null)
                {
                    noteExist.Pin = note.Pin;
                    this.context.Note.Update(noteExist);
                    this.context.SaveChanges();
                    return "Pin Updated Successfully";
                }
                return "Pin Not Updated";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string UpdateArchive(NoteModel note)
        {
            try
            {
                var noteExist = this.context.Note.Where(x => x.NoteId == note.NoteId).SingleOrDefault();
                if (noteExist != null)
                {
                    noteExist.Archive = note.Archive;
                    this.context.Note.Update(noteExist);
                    this.context.SaveChanges();
                    return "Archive Updated Successfully";
                }
                return "Archive Not Updated";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string UpdateTrash(NoteModel note)
        {
            try
            {
                var noteExist = this.context.Note.Where(x => x.NoteId == note.NoteId).SingleOrDefault();
                if (noteExist != null)
                {
                    noteExist.Trash = note.Trash;
                    this.context.Note.Update(noteExist);
                    this.context.SaveChanges();
                    return "Note Trashed Successfully";
                }
                return "Note Not Trashed";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
