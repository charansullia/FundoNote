using FundooManager.Interface;
using FundooModel;
using FundooRespository.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooManager.Manager
{
  public class NoteManager:INoteManager
    {
        private readonly INoteRepository noteRepository;
        public NoteManager(INoteRepository noteRepository)
        {
            this.noteRepository = noteRepository;
        }

        public string AddNote(NoteModel note)
        {
            try
            {
                return this.noteRepository.AddNote(note);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string Update(NoteModel note)
        {
            try
            {
                return this.noteRepository.Update(note);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string UpdateDescription(NoteModel note)
        {
            try
            {
                return this.noteRepository.UpdateDescription(note);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string AddReminder(NoteModel note)
        {
            try
            {
                return this.noteRepository.AddReminder(note);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string RemoveReminder(NoteModel note)
        {
            try
            {
                return this.noteRepository.RemoveReminder(note);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string UpdateColour(NoteModel note)
        {
            try
            {
                return this.noteRepository.UpdateColour(note);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string PinNote(NoteModel note)
        {
            try
            {
                return this.noteRepository.PinNote(note);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string UnPinNote(NoteModel note)
        {
            try
            {
                return this.noteRepository.UnPinNote(note);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string Archive(NoteModel note)
        {
            try
            {
                return this.noteRepository.Archive(note);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string UnArchive(NoteModel note)
        {
            try
            {
                return this.noteRepository.UnArchive(note);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string Trash(NoteModel note)
        {
            try
            {
                return this.noteRepository.Trash(note);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string Restore(NoteModel note)
        {
            try
            {
                return this.noteRepository.Restore(note);
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
                return this.noteRepository.UploadImage( noteId, image);
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
                return this.noteRepository.DeleteForever(note);
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

    }
}
