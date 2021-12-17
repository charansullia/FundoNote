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
                return "Adding of Note Successfully";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string TitleUpdate(NoteModel note)

        {
            try
            {
                var Note = this.context.Note.Where(x => x.NoteId == note.NoteId).FirstOrDefault();
                if (Note != null)
                {
                    Note.title = note.title;
                    this.context.Note.Update(Note);
                    this.context.SaveChanges();
                    return "Note Title Updated Successfully";
                }
                return "Note Title not Updated";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string DescriptionUpdate(NoteModel note)
        {
            try
            {
                var Note = this.context.Note.Where(x => x.NoteId == note.NoteId).SingleOrDefault();
                if (Note != null)
                {
                    Note.Description = note.Description;
                    this.context.Note.Update(Note);
                    this.context.SaveChanges();
                    return "Note Description Sucessfully Updated";
                }
                return "Note Description not updated";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string AddReminder(NoteModel note)
        {
            try
            {
                var Note = this.context.Note.Where(x => x.NoteId == note.NoteId).SingleOrDefault();
                if (Note != null)
                {
                    Note.Reminder = note.Reminder;
                    this.context.Note.Update(Note);
                    this.context.SaveChanges();
                    return "Reminder Sucessfully Added";
                }
                return "Reminder Not Added Sucessfully";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string RemoveReminder(NoteModel note)
        {
            try
            {
                var noteExist = this.context.Note.Where(x => x.NoteId == note.NoteId).FirstOrDefault();
                if (noteExist != null)
                {
                    noteExist.Reminder = null;
                    this.context.Note.Update(noteExist);
                    this.context.SaveChanges();
                    return "Reminder Sucessfully Removed";
                }
                return "Reminder Not Removed";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public string ColourUpdate(NoteModel note)
        {
            try
            {
                var Note = this.context.Note.Where(x => x.NoteId == note.NoteId).SingleOrDefault();
                if (Note != null)
                {
                    Note.Colour = note.Colour;
                    this.context.Note.Update(Note);
                    this.context.SaveChanges();
                    return "Colour Sucessfully Added";
                }
                return "Colour Not Added Sucessfully";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string PinNote(NoteModel note)
        {
            try
            {
                var Note = this.context.Note.Where(x => x.NoteId == note.NoteId).SingleOrDefault();
                if (Note != null)
                {
                    if (Note.Pin != true)
                    {
                        Note.Pin = note.Pin;
                        this.context.Note.Update(Note);
                        this.context.SaveChanges();
                        return "Note Successfully Pinned";
                    }
                }
                return "Note pin Unsuccessfully";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string UnPinNote(NoteModel note)
        {
            try
            {
                var Note = this.context.Note.Where(x => x.NoteId == note.NoteId).SingleOrDefault();
                if (Note != null)
                {
                    if (Note.Pin != false)
                    {
                        Note.Pin = note.Pin;
                        this.context.Note.Update(Note);
                        this.context.SaveChanges();
                        return "Note Sucessfully Unpinned";
                    }
                }
                return "Pin Not Removed";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string Archive(NoteModel note)
        {
            try
            {
                var Note = this.context.Note.Where(x => x.NoteId == note.NoteId).SingleOrDefault();
                if (Note != null)
                {
                    if (Note.Archive != true)
                    {
                        Note.Archive = note.Archive;
                        this.context.Note.Update(Note);
                        this.context.SaveChanges();
                        return "Note Successfully Archived";
                    }
                }
                return "Not Added to Archive";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string UnArchive(NoteModel note)
        {
            try
            {
                var Note = this.context.Note.Where(x => x.NoteId == note.NoteId).SingleOrDefault();
                if (Note != null)
                {
                    if (Note.Archive != false)
                    {
                        Note.Archive = note.Archive;
                        this.context.Note.Update(Note);
                        this.context.SaveChanges();
                        return "Note UnArchived Successfully";
                    }
                }
                return "Not Removed from Archive";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string Trash(NoteModel note)
        {
            try
            {
                var Note = this.context.Note.Where(x => x.NoteId == note.NoteId).SingleOrDefault();
                if (Note != null)
                {
                    if (Note.Trash != true)
                    {
                        Note.Trash = note.Trash;
                        this.context.Note.Update(Note);
                        this.context.SaveChanges();
                        return "Note Successfully Trashed ";
                    }
                }
                return "Note Not Trashed";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string Restore(NoteModel note)
        {
            try
            {
                var Note = this.context.Note.Where(x => x.NoteId == note.NoteId).SingleOrDefault();
                if (Note != null)
                {
                    if (Note.Trash != true)
                    {
                        Note.Trash = note.Trash;
                        this.context.Note.Update(Note);
                        this.context.SaveChanges();
                        return "Note Sucessfully Restored";
                    }
                }
                return "Note Not Restored";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
       
        public string DeleteForever(NoteModel note)
        {
            try
            {
                var Note = this.context.Note.Where(x => x.NoteId == note.NoteId).SingleOrDefault();
                if (Note != null)
                {
                    if (Note.Trash != false)
                    {
                        this.context.Note.Remove(Note);
                        this.context.SaveChanges();
                        return "Note Successfully Deleted";
                    }
                }
                return "Note not Deleted";
            }

            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}
