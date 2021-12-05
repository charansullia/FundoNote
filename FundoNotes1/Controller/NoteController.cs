using FundooManager.Interface;
using FundooModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundoNotes.Controller
{
   [Authorize]
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
        public IActionResult UpdateTitle([FromBody] NoteModel note)
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
        [HttpPut]
        [Route("api/UpdateDescription")]
        public IActionResult UpdateDescription([FromBody] NoteModel note)
        {
            try
            {
                string message = this.manager.UpdateDescription(note);
                if (message.Equals("Description Updated Successfully"))
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
        [Route("api/AddReminder")]
        public IActionResult AddReminder([FromBody] NoteModel note)
        {
            try
            {
                string message = this.manager.AddReminder(note);
                if (message.Equals("Reminder Added Successfully"))
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
        [Route("api/RemoveReminder")]
        public IActionResult RemoveReminder([FromBody] NoteModel noteModel)
        {
            try
            {
                string message = this.manager.RemoveReminder(noteModel);
                if (message.Equals("Reminder Removed Successfully"))
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
        [Route("api/UpdateColour")]
        public IActionResult UpdateColour([FromBody] NoteModel note)
        {
            try
            {
                string message = this.manager.UpdateColour(note);
                if (message.Equals("Colour Updated Successfully"))
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
        [Route("api/PinNote")]
        public IActionResult PinNote([FromBody] NoteModel note)
        {
            try
            {
                string message = this.manager.PinNote(note);
                if (message.Equals("Note Pinned Successfully"))
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
        [Route("api/UnPinNote")]
        public IActionResult UnPinNote([FromBody] NoteModel note)
        {
            try
            {
                string message = this.manager.UnPinNote(note);
                if (message.Equals("Note UnPinned Successfully"))
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
        [Route("api/Archive")]
        public IActionResult UpdateArchive([FromBody] NoteModel note)
        {
            try
            {
                string message = this.manager.Archive(note);
                if (message.Equals("Note Archived"))
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
        [Route("api/UnArchive")]
        public IActionResult UnArchive([FromBody] NoteModel note)
        {
            try
            {
                string message = this.manager.UnArchive(note);
                if (message.Equals("Un Archived"))
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
        [Route("api/Trash")]
        public IActionResult UpdateTrash([FromBody] NoteModel note)
        {
            try
            {
                string message = this.manager.Trash(note);
                if (message.Equals("Note Trashed Successfully"))
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
        [Route("api/Restore")]
        public IActionResult Restore([FromBody] NoteModel note)
        {
            try
            {
                string message = this.manager.Restore(note);
                if (message.Equals("Note Restored Successfully"))
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
        [Route("api/UploadImage")]
        public IActionResult UploadImage(int noteId, IFormFile image)
        {
            try
            {
                string message = this.manager.UploadImage( noteId, image);
                if (message.Equals("ImageUploaded Successfully"))
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

        [HttpDelete]
        [Route("api/DeleteForever")]
        public IActionResult Delete([FromBody] NoteModel note)
        {
            try
            {
                string message = this.manager.DeleteForever(note);
                if (message.Equals("Note Deleted Successfully"))
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