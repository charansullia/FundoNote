using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FundooModel
{
   public class LabelModel
    {
         [Key]
         public int LabelId { get; set; }
         [ForeignKey("RegisterModel")]
         public  int UserId { get; set; }
         public virtual RegisterModel user { get; set; }
         [ForeignKey("NoteModel")]
         public int? NoteId { get; set; }
         public virtual NoteModel note { get; set; }
         public string Label { get; set; }
    }
}
