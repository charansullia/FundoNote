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

    }
}
