using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model.Request.MeetRequest
{
    public class MeetingUpdateRequest
    {
        public string LinkMeet { get; set; } = null!;

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Status { get;set; }
    }
}
