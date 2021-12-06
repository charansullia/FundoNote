using FundooManager.Interface;
using FundooModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundoNotes.Controller
{
    public class CollaboratoryController : ControllerBase
    {
        private readonly ICollaboratoryManager collaboratorymanager;
        public CollaboratoryController(ICollaboratoryManager collaboratorymanager)
        {
            this.collaboratorymanager = collaboratorymanager;
        }
        [HttpPost]
        [Route("api/addCollaborator")]
        public IActionResult AddCollaborator([FromBody] CollaboratoryModel collaborator)
        {
            try
            {
                string message = this.collaboratorymanager.AddCollaborator(collaborator);
                if (message.Equals("Collaborator Added Successfully"))
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
        [Route("api/deleteCollaborator")]
        public IActionResult DeleteCollaborator([FromBody] CollaboratoryModel collaborator)
        {
            try
            {
                string message = this.collaboratorymanager.DeleteCollaborator(collaborator);
                if (message.Equals("Collaborator Deleted Successfully"))
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
        [Route("api/GetCollaborator")]
        public IActionResult GetCollaborator(int NoteId)
        {
            try
            {
                IEnumerable<CollaboratoryModel> result = this.collaboratorymanager.GetCollaborator(NoteId);
                if (result != null)
                {
                    return this.Ok(new { Status = true, data = result, message = "Collaborator retrived successfully" });
                }
                else
                {
                    return this.BadRequest(new { Status = false, data = result, message = "Collaborator is Empty" });
                }

            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, ex.Message });
            }
        }

    }
}
