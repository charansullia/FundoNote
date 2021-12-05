using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using FundooModel;
using FundooRespository.Context;
using FundooRespository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FundooRespository.Repository
{
  public class NoteRepository:INoteRepository
    {
        private readonly UserContext context;
        private readonly IConfiguration configuration;
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
        public string AddReminder(NoteModel note)
        {
            try
            {
                var noteExist = this.context.Note.Where(x => x.NoteId == note.NoteId).SingleOrDefault();
                if (noteExist != null)
                {
                    noteExist.Reminder = note.Reminder;
                    this.context.Note.Update(noteExist);
                    this.context.SaveChanges();
                    return "Reminder Added Successfully";
                }
                return "Reminder Not Added";
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
                    return "Reminder Removed Successfully";
                }
                return "Reminder Not Added";
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
        public string PinNote(NoteModel note)
        {
            try
            {
                var noteExist = this.context.Note.Where(x => x.NoteId == note.NoteId).SingleOrDefault();
                if (noteExist != null)
                {
                    if (noteExist.Pin == false)
                    {
                        noteExist.Pin = note.Pin;
                        this.context.Note.Update(noteExist);
                        this.context.SaveChanges();
                        return "Note Pinned Successfully";
                    }
                }
                return "Pin Not Added";
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
                var noteExist = this.context.Note.Where(x => x.NoteId == note.NoteId).SingleOrDefault();
                if (noteExist != null)
                {
                    if (noteExist.Pin == true)
                    {
                        noteExist.Pin = note.Pin;
                        this.context.Note.Update(noteExist);
                        this.context.SaveChanges();
                        return "Note UnPinned Successfully";
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
                var noteExist = this.context.Note.Where(x => x.NoteId == note.NoteId).SingleOrDefault();
                if (noteExist != null)
                {
                    if (noteExist.Archive == false)
                    {
                        noteExist.Archive = note.Archive;
                        this.context.Note.Update(noteExist);
                        this.context.SaveChanges();
                        return "Note Archived";
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
                var noteExist = this.context.Note.Where(x => x.NoteId == note.NoteId).SingleOrDefault();
                if (noteExist != null)
                {
                    if (noteExist.Archive == true)
                    {
                        noteExist.Archive = note.Archive;
                        this.context.Note.Update(noteExist);
                        this.context.SaveChanges();
                        return "Un Archived";
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
                var noteExist = this.context.Note.Where(x => x.NoteId == note.NoteId).SingleOrDefault();
                if (noteExist != null)
                {
                    if (noteExist.Trash == false)
                    {
                        noteExist.Trash = note.Trash;
                        this.context.Note.Update(noteExist);
                        this.context.SaveChanges();
                        return "Note Trashed Successfully";
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
                var noteExist = this.context.Note.Where(x => x.NoteId == note.NoteId).SingleOrDefault();
                if (noteExist != null)
                {
                    if (noteExist.Trash == true)
                    {
                        noteExist.Trash = note.Trash;
                        this.context.Note.Update(noteExist);
                        this.context.SaveChanges();
                        return "Note Restored Successfully";
                    }
                }
                return "Note Not Restored";
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string UploadImage(int noteId, IFormFile image)
        {
            try
            {
                Account account = new Account(this.configuration.GetValue<string>("CloudinaryAccount:CloudName"), this.configuration.GetValue<string>("CloudinaryAccount:Apikey"), this.configuration.GetValue<string>("CloudinaryAccount:Apisecret"));
                var cloudinary = new Cloudinary(account);
                var uploadparams = new ImageUploadParams()
                {
                    File = new FileDescription(image.FileName, image.OpenReadStream()),
                };
                var uploadResult = cloudinary.Upload(uploadparams);
                string imagePath = uploadResult.Url.ToString();
                var findNote = this.context.Note.Where(x => x.NoteId == noteId).SingleOrDefault();
                if (findNote != null)
                {
                    findNote.Image = imagePath;
                    this.context.Note.Update(findNote);
                    this.context.SaveChanges();
                    return "Image Uploaded Successfully";
                }
                return "noteID not Exist";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string DeleteForever(NoteModel note)
        {
            try
            {
                var noteExist = this.context.Note.Where(x => x.NoteId == note.NoteId).SingleOrDefault();
                if (noteExist != null)
                {
                    if (noteExist.Trash == true)
                    {
                        this.context.Note.Remove(noteExist);
                        this.context.SaveChanges();
                        return "Note Deleted Successfully";
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
