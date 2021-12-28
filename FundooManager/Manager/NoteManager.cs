using FundooManager.Interface;
using FundooModel;
using FundooRespository.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FundooManager.Manager
{
  public class NoteManager:INoteManager
    {
        private readonly INoteRepository noteRepository;
        public NoteManager(INoteRepository noteRepository)
        {
            this.noteRepository = noteRepository;
        }

        public async Task<bool> AddNote(NoteModel note)
        {
            try
            {
                return await this.noteRepository.AddNote(note);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool>TitleUpdate(NoteModel note)
        {
            try
            {
                return await this.noteRepository.TitleUpdate(note);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DescriptionUpdate(NoteModel note)
        {
            try
            {
                return await this.noteRepository.DescriptionUpdate(note);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> AddReminder(NoteModel note)
        {
            try
            {
                return await this.noteRepository.AddReminder(note);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> RemoveReminder(NoteModel note)
        {
            try
            {
                return await this.noteRepository.RemoveReminder(note);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> ColourUpdate(NoteModel note)
        {
            try
            {
                return await this.noteRepository.ColourUpdate(note);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> PinNote(NoteModel note)
        {
            try
            {
                return await this.noteRepository.PinNote(note);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> UnPinNote(NoteModel note)
        {
            try
            {
                return await this.noteRepository.UnPinNote(note);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Archive(NoteModel note)
        {
            try
            {
                return await this.noteRepository.Archive(note);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> UnArchive(NoteModel note)
        {
            try
            {
                return await this.noteRepository.UnArchive(note);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public  async Task<bool> Trash(NoteModel note)
        {
            try
            {
                return await this.noteRepository.Trash(note);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> Restore(NoteModel note)
        {
            try
            {
                return await this.noteRepository.Restore(note);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteForever(NoteModel note)
        {
            try
            {
                return await this.noteRepository.DeleteForever(note);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string UploadImage(int noteId, IFormFile image)
        {
            try
            {
                return this.noteRepository.UploadImage(noteId, image);
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
                return this.noteRepository.GetNotes(UserId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<NoteModel> GetArchive(int UserId)
        {
            try
            {
                return this.noteRepository.GetArchive(UserId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<NoteModel> GetTrash(int UserId)
        {
            try
            {
                return this.noteRepository.GetTrash(UserId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<NoteModel> GetReminder(int UserId)
        {
            try
            {
                return this.noteRepository.GetReminder(UserId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
