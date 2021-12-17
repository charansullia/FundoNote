﻿using FundooManager.Interface;
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
        public string TitleUpdate(NoteModel note)
        {
            try
            {
                return this.noteRepository.TitleUpdate(note);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string DescriptionUpdate(NoteModel note)
        {
            try
            {
                return this.noteRepository.DescriptionUpdate(note);
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
        public string ColourUpdate(NoteModel note)
        {
            try
            {
                return this.noteRepository.ColourUpdate(note);
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
    }
}
