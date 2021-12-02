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
        string UpdateReminder(NoteModel note);
        string UpdateColour(NoteModel note);
    }
}
