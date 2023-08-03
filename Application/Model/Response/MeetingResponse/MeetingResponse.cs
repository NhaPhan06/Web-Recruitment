using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model.Response.MeetingResponse
{
    public class MeetingResponse
    {
        public Guid MeetId { get; set; }

        public string LinkMeet { get; set; } = null!;

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public Guid OperationId { get; set; }

        public Guid InterviewerId { get; set; }

        public Guid HrId { get; set; }
    }
}
