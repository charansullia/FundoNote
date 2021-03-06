using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FundooModel
{
  public class NoteModel
    {
        [Key]
        public int NoteId { get; set; }
        public string title { get; set; }
        [ForeignKey("RegisterModel")]
        public int UserId { get; set; }
        public virtual RegisterModel user { get; set; }

        //[Required]
        public string Description { get; set; }
        public string Reminder { get; set; }

        public string Colour { get; set; }

        public string Image { get; set; }

       [DefaultValue(false)]
        public bool Pin { get; set; }

        [DefaultValue(false)]
        public bool Archive { get; set; }

        [DefaultValue(false)]
        public bool Trash { get; set; }
    }
}

