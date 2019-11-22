using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDirectoryAPI.Models
{
    public class EventsDto
    {
        public int EventId { get; set; }
        public string Venu { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime EventFromTime { get; set; }
        public DateTime EventToTime { get; set; }
        public String EventTimeZone { get; set; }
        public String Organizer { get; set; }
        public String EventName { get; set; }
        public String EventPhotoURL { get; set; }
        public String EventDiscription { get; set; }

    }
}
