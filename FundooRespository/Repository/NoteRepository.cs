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
using System.Threading.Tasks;

namespace FundooRespository.Repository
{
  public class NoteRepository:INoteRepository
    {
        private readonly UserContext context;
        private readonly IConfiguration configuration;
        public NoteRepository(UserContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }
        public async Task<bool> AddNote(NoteModel note)
        {
            try
            {
                this.context.Note.Add(note);
                await this.context.SaveChangesAsync();
                return true;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> TitleUpdate(NoteModel note)

        {
            try
            {
                var Note = this.context.Note.Where(x => x.NoteId == note.NoteId).SingleOrDefault();
                if (Note != null)
                {
                    Note.title = note.title;
                    this.context.Note.Update(Note);
                    await this.context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool>DescriptionUpdate(NoteModel note)
        {
            try
            {
                var Note = this.context.Note.Where(x => x.NoteId == note.NoteId).SingleOrDefault();
                if (Note != null)
                {
                    Note.Description = note.Description;
                    this.context.Note.Update(Note);
                    await this.context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> AddReminder(NoteModel note)
        {
            try
            {
                var Note = this.context.Note.Where(x => x.NoteId == note.NoteId).SingleOrDefault();
                if (Note != null)
                {
                    Note.Reminder = note.Reminder;
                    this.context.Note.Update(Note);
                    await this.context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool>RemoveReminder(NoteModel note)
        {
            try
            {
                var Note = this.context.Note.Where(x => x.NoteId == note.NoteId).SingleOrDefault();
                if (Note != null)
                {
                     Note.Reminder = null;
                    this.context.Note.Update(Note);
                    await this.context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public async Task<bool> ColourUpdate(NoteModel note)
        {
            try
            {
                var Note = this.context.Note.Where(x => x.NoteId == note.NoteId).SingleOrDefault();
                if (Note != null)
                {
                    Note.Colour = note.Colour;
                    this.context.Note.Update(Note);
                    await this.context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> PinNote(NoteModel note)
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
                        await this.context.SaveChangesAsync();
                        return true;
                    }
                }
                return false;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> UnPinNote(NoteModel note)
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
                        await this.context.SaveChangesAsync();
                        return true;
                    }
                }
                return false;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> Archive(NoteModel note)
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
                        await this.context.SaveChangesAsync();
                        return true;
                    }
                }
                return false;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> UnArchive(NoteModel note)
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
                        await this.context.SaveChangesAsync();
                        return true;
                    }
                }
                return false;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> Trash(NoteModel note)
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
                        await this.context.SaveChangesAsync();
                        return true;
                    }
                }
                return false;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> Restore(NoteModel note)
        {
            try
            {
                var Note = this.context.Note.Where(x => x.NoteId == note.NoteId).SingleOrDefault();
                if (Note != null)
                {
                    if (Note.Trash != false)
                    {
                        Note.Trash = note.Trash;
                        this.context.Note.Update(Note);
                       await this.context.SaveChangesAsync();
                        return true;
                    }
                }
                return false;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteForever(NoteModel note)
        {
            try
            {
                var Note = this.context.Note.Where(x => x.NoteId == note.NoteId).SingleOrDefault();
                if (Note != null)
                {
                    if (Note.Trash != false)
                    {
                        this.context.Note.Remove(Note);
                        await this.context.SaveChangesAsync();
                        return true;
                    }
                }
                return false;
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
        public IEnumerable<NoteModel> GetNotes(int UserId)
        {
            try
            {
                IEnumerable<NoteModel> NoteList = this.context.Note.Where(x => x.UserId == UserId && x.Archive == false && x.Trash == false).ToList();
                if (NoteList != null)
                {
                    return NoteList;
                }
                return null;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<NoteModel> GetArchive(int UserId)
        {
            try
            {
                IEnumerable<NoteModel> NoteList = this.context.Note.Where(x => x.UserId == UserId && x.Archive == true).ToList();
                if (NoteList.Count() != 0)
                {
                    return NoteList;
                }
                return null;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<NoteModel> GetTrash(int UserId)
        {
            try
            {
                IEnumerable<NoteModel> NoteList = this.context.Note.Where(x => x.UserId == UserId && x.Trash == true).ToList();
                if (NoteList.Count() != 0)
                {
                    return NoteList;
                }
                return null;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<NoteModel> GetReminder(int UserId)
        {
            try
            {
                IEnumerable<NoteModel> NoteList = this.context.Note.Where(x => x.UserId == UserId && x.Reminder != null).ToList();
                if (NoteList.Count() != 0)
                {
                    return NoteList;
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
