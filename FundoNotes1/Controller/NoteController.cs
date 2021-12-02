using FundooManager.Interface;
using FundooModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundoNotes.Controller
{
    public class NoteController : ControllerBase
    {
        private readonly INoteManager manager;
        public NoteController(INoteManager manager)
        {
            this.manager = manager;
        }
        [HttpPost]
        [Route("api/addnote")]
        public IActionResult AddNote([FromBody] NoteModel note)
        {
            try
            {
                string message = this.manager.AddNote(note);
                if (message.Equals("Note Added Successfully"))
                {
                    return this.Ok(new { Status = true, Message = message });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = message });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, ex.Message });
            }
        }
        [HttpPut]
        [Route("api/UpdateTitle")]
        public IActionResult EditTitle([FromBody] NoteModel note)
        {
            try
            {
                string message = this.manager.Update(note);
                if (message.Equals("Title Updated Successfully"))
                {
                    return this.Ok(new { Status = true, Message = message });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = message });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, ex.Message });
            }
        }
      

    }
}
