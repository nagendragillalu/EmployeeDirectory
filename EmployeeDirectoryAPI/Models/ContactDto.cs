using System;

namespace EmployeeDirectoryAPI.Models
{
    public class ContactDto
    {
        public int MobileOffice { get; set; }
        public int MobilePersonal { get; set; }
        public String SkypeId { get; set; }
        public String SlackId { get; set; }
        public String Address { get; set; }
        public String FBLink { get; set; }
        public String TwitterLink { get; set; }
        public String GitHubLink { get; set; }
        public String LinkdinLink { get; set; }

    }
}