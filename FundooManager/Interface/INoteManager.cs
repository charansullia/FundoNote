using FundooModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooManager.Interface
{
  public interface INoteManager
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
        string DeleteForever(NoteModel note);
    }
}
