using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model.Request.InterviewerRequest
{
    public class RequestUpdateStatusInterviewer
    {
        public RequestUpdateStatusInterviewer()
        {
            
        }

        public RequestUpdateStatusInterviewer(string status)
        {
            Status = status;
        }

        public string Status { get; set; }
    }
}
