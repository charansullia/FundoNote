using FundooModel;
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
        string UpdateReminder(NoteModel note);
        string UpdateColour(NoteModel note);
        string UpdatePin(NoteModel note);
        string UpdateArchive(NoteModel note);
        string UpdateTrash(NoteModel note);
    }
}
