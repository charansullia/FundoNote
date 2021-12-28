using FundooModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FundooManager.Interface
{
  public interface INoteManager
    {
        Task<bool> AddNote(NoteModel note);
        Task<bool> TitleUpdate(NoteModel note);
        Task<bool> DescriptionUpdate(NoteModel note);
        Task<bool> AddReminder(NoteModel note);
        Task<bool> RemoveReminder(NoteModel note);
        Task<bool> ColourUpdate(NoteModel note);
        Task<bool> PinNote(NoteModel note);
        Task<bool> UnPinNote(NoteModel note);
        Task<bool>Archive(NoteModel note);
        Task<bool> UnArchive(NoteModel note);
        Task<bool> Trash(NoteModel note);
        Task<bool> Restore(NoteModel note);
        Task<bool> DeleteForever(NoteModel note);
        string UploadImage(int noteId, IFormFile image);
        IEnumerable<NoteModel> GetNotes(int UserId);
        IEnumerable<NoteModel> GetArchive(int UserId);
        IEnumerable<NoteModel> GetTrash(int UserId);
        IEnumerable<NoteModel> GetReminder(int UserId);

    }
}
