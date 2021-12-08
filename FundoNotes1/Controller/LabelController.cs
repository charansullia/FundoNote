using FundooManager.Interface;
using FundooModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundoNotes.Controller
{
    public class LabelController : ControllerBase
    {
        private readonly ILabelManager labelmanager;
        public LabelController(ILabelManager labelmanager)
        {
            this.labelmanager = labelmanager;
        }
        [HttpPost]
        [Route("api/addLabel")]
        public IActionResult AddLabel([FromBody] LabelModel label)
        {
            try
            {
                string message = this.labelmanager.AddLabel(label);
                if (message.Equals("Label Created Successfully"))
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
        [Route("api/DeleteLabel")]
        public IActionResult DeleteLabel([FromBody]LabelModel label)
        {
            try
            {
                string message = this.labelmanager.DeleteLabel(label);
                if (message.Equals("Label Deleted Forever"))
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
        [Route("api/Editlabel")]
        public IActionResult EditLabel([FromBody] LabelModel label)
        {
            try
            {
                string message = this.labelmanager.EditLabel(label);
                if (message.Equals("Label Edited Successfully"))
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
        [Route("api/RemovelabelfromNote")]
        public IActionResult RemoveLabelFromNote(int LabelId)
        {
            try
            {
                string message = this.labelmanager.RemoveLabelFromNote(LabelId);
                if (message.Equals("Label Removed Successfully"))
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
        [Route("api/GetLabelbyNoteId")]
        public IActionResult GetLabelByNoteId(int NoteId)
        {
            try
            {
                IEnumerable<LabelModel> result = this.labelmanager.GetLabelByNoteId(NoteId);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Labels Present in Notes Retrieved Successfully", Data = result });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "Labels Not Available", Data = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, ex.Message });
            }

        }    
    }
}
