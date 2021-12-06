using FundooModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooRespository.Interface
{
   public interface INoteRepository
    {
        string AddNote(NoteModel note);
        string Update(NoteModel note);
        string UpdateDescription(NoteModel note);
        string AddReminder(NoteModel note);
        string RemoveReminder(NoteModel note);
        string UpdateColour(NoteModel note);
        string PinNote(NoteModel note);
        string UnPinNote(NoteModel note);
        string Archive(NoteModel note);
        string UnArchive(NoteModel note);
        string Trash(NoteModel note);
        string Restore(NoteModel note);
        string UploadImage(int noteId, IFormFile image);
        string DeleteForever(NoteModel note);
        IEnumerable<NoteModel> GetNotes(int UserId);
        IEnumerable<NoteModel> GetArchive(int UserId);

    }
}
