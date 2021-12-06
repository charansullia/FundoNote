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
    }
}
