using FundooManager.Interface;
using FundooModel;
using FundooRespository.Interface;
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
        public string UpdateReminder(NoteModel note)
        {
            try
            {
                return this.noteRepository.UpdateReminder(note);
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
        public string UpdatePin(NoteModel note)
        {
            try
            {
                return this.noteRepository.UpdatePin(note);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
