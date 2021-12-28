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
        public async Task<IActionResult> AddNote([FromBody] NoteModel note)
        {
            try
            {
                bool message = await this.manager.AddNote(note);
                if (message.Equals(true))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Note Added Sucessfully", Data = "Session Data" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Note Added UnSucessfully" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, ex.Message });
            }
        }
        [HttpPut]
        [Route("api/UpdateTitle")]
        public async Task<IActionResult> TitleUpdate([FromBody] NoteModel note)
        {
            try
            {
                bool message = await this.manager.TitleUpdate(note);
                if (message.Equals(true))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "TitleUpdate Successfully", Data = "Session Data" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "TitleUpateUnsuccessfully", Data = "Session Data" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, ex.Message });
            }
        }
        [HttpPut]
        [Route("api/UpdateDescription")]
        public async Task<IActionResult> DescriptionUpdate([FromBody] NoteModel note)
        {
            try
            {
                bool message = await this.manager.DescriptionUpdate(note);
                if (message.Equals(true))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Description Updated Sucessfully", Data = "Session Data" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Description Updated UnSucessfully" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, ex.Message });
            }
        }
        [HttpPut]
        [Route("api/AddReminder")]
        public async Task<IActionResult> AddReminder([FromBody] NoteModel note)
        {
            try
            {
                bool message = await this.manager.AddReminder(note);
                if (message.Equals(true))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Reminder Added Sucessfully", Data = "Session Data" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Reminder Added UnSucessfully" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, ex.Message });
            }
        }
        [HttpPut]
        [Route("api/RemoveReminder")]
        public async Task<IActionResult> RemoveReminder([FromBody] NoteModel noteModel)
        {
            try
            {
                bool message = await this.manager.RemoveReminder(noteModel);
                if (message.Equals(true))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Reminder Removed Sucessfully", Data = "Session Data" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Reminder Removed UnSucessfully" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, ex.Message });
            }
        }

        [HttpPut]
        [Route("api/UpdateColour")]
        public async Task<IActionResult> ColourUpdate([FromBody] NoteModel note)
        {
            try
            {
                bool message = await this.manager.ColourUpdate(note);
                if (message.Equals(true))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Colour Updated Sucessfully", Data = "Session Data" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Colour Updated UnSucessfully" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, ex.Message });
            }
        }
        [HttpPut]
        [Route("api/PinNote")]
        public async Task<IActionResult> PinNote([FromBody] NoteModel note)
        {
            try
            {
                bool message = await this.manager.PinNote(note);
                if (message.Equals(true))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Note Pinned Sucessfully", Data = "Session Data" });
                }
                else
                {
                    return this.Ok(new ResponseModel<string>() { Status = false, Message = "Note Pinned UnSucessfully" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, ex.Message });
            }
        }
        [HttpPut]
        [Route("api/UnPinNote")]
        public async Task<IActionResult> UnPinNote([FromBody] NoteModel note)
        {
            try
            {
                bool message = await this.manager.UnPinNote(note);
                if (message.Equals(true))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Note UnPinned Sucessfully", Data = "Session Data" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Not UnPinned UnSucessfully" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, ex.Message });
            }
        }

        [HttpPut]
        [Route("api/Archive")]
        public async Task<IActionResult> Archive([FromBody] NoteModel note)
        {
            try
            {
                bool message = await this.manager.Archive(note);
                if (message.Equals(true))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Note Archived Sucessfully", Data = "Session Data" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Note Archived UnSucessfully" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, ex.Message });
            }
        }
        [HttpPut]
        [Route("api/UnArchive")]
        public async Task<IActionResult> UnArchive([FromBody] NoteModel note)
        {
            try
            {
                bool message = await this.manager.UnArchive(note);
                if (message.Equals(true))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Note UnArchived Sucessfully", Data = "Session Data" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Note UnArchived Sucessfully" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, ex.Message });
            }
        }


        [HttpPut]
        [Route("api/Trash")]
        public async Task<IActionResult> Trash([FromBody] NoteModel note)
        {
            try
            {
                bool message = await this.manager.Trash(note);
                if (message.Equals(true))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Note Trashed Sucessfully", Data = "Session Data" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Note Trashed UnSucessfully" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, ex.Message });
            }
        }
        [HttpPut]
        [Route("api/Restore")]
        public async Task<IActionResult> Restore([FromBody] NoteModel note)
        {
            try
            {
                bool message = await this.manager.Restore(note);
                if (message.Equals(true))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Note Restored Sucessfully", Data = "Session Data" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Note Restored UnSucessfully" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, ex.Message });
            }
        }
        [HttpDelete]
        [Route("api/DeleteForever")]
        public async Task<IActionResult> Delete([FromBody] NoteModel note)
        {
            try
            {
                bool message = await this.manager.DeleteForever(note);
                if (message.Equals(true))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = "Note Deleted Sucessfully", Data = "Session Data" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Note Deleted UnSucessfully" });
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