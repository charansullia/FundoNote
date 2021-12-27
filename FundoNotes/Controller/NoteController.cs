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
  // [Authorize]
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
                if (message.Equals("Adding of Note Successfully"))
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
        public IActionResult TitleUpdate([FromBody] NoteModel note)
        {
            try
            {
                string message = this.manager.TitleUpdate(note);
                if (message.Equals("Note Title Updated Successfully"))
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
        public IActionResult DescriptionUpdate([FromBody] NoteModel note)
        {
            try
            {
                string message = this.manager.DescriptionUpdate(note);
                if (message.Equals("Note Description Sucessfully Updated"))
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
                if (message.Equals("Reminder Sucessfully Added"))
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
                if (message.Equals("Reminder Sucessfully Removed"))
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
        public IActionResult ColourUpdate([FromBody] NoteModel note)
        {
            try
            {
                string message = this.manager.ColourUpdate(note);
                if (message.Equals("Colour Sucessfully Added"))
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
                if (message.Equals("Note Successfully Pinned"))
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
                if (message.Equals("Note Sucessfully Unpinned"))
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
                if (message.Equals("Note Successfully Archived"))
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
                if (message.Equals("Note UnArchived Successfully"))
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
                if (message.Equals("Note Successfully Trashed"))
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
                if (message.Equals("Note Sucessfully Restored"))
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
                if (message.Equals("Image Uploaded Successfully"))
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
                if (message.Equals("Note Successfully Deleted"))
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
        [HttpGet]
        [Route("api/GetNotes")]
        public IActionResult GetNotes(int UserId)
        {
            try
            {
                IEnumerable<NoteModel> result = this.manager.GetNotes(UserId);
                if (result != null)
                {
                    return this.Ok(new { Status = true, data = result, message = "Note retrived successfully" });
                }
                else
                {
                    return this.BadRequest(new { Status = false, data = result, message = "Note is Empty" });
                }

            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, ex.Message });
            }
        }
        [HttpGet]
        [Route("api/GetArchive")]
        public IActionResult GetArchive(int UserId)
        {
            try
            {
                IEnumerable<NoteModel> result = this.manager.GetArchive(UserId);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Retrived Archived Notes", Data = result });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "Archived Notes not Available", Data = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, ex.Message });
            }
        }
        [HttpGet]
        [Route("api/GetTrash")]
        public IActionResult GetTrash(int UserId)
        {
            try
            {
                IEnumerable<NoteModel> result = this.manager.GetTrash(UserId);
                if (result != null)
                {
                    return this.Ok(new { Status = true, data = result, message = "Trash retrived successfully" });
                }
                else
                {
                    return this.BadRequest(new { Status = false, data = result, message = "Trash is Empty" });
                }

            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, ex.Message });
            }
        }
        [HttpGet]
        [Route("api/GetReminder")]
        public IActionResult GetReminder(int UserId)
        {
            try
            {
                IEnumerable<NoteModel> result = this.manager.GetReminder(UserId);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Retrived Reminder Notes", Data = result });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "Reminder Notes Notes not Available", Data = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, ex.Message });
            }
        }
    }
}