using FundooModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooRespository.Interface
{
   public interface INoteRepository
    {
        string AddNote(NoteModel note);
    }
}
