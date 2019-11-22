using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDirectoryAPI.Models
{
    public class GreetListDto
    {
        public int employeeId { get; set; }
        public String fName { get; set; }
        public String lName { get; set; }
        public DateTime greetDate { get; set; }
        public String eMail { get; set; }
        public String twitter { get; set; }
        public String facebook { get; set; }
        public int yearCount { get; set; }
        public String photoUrl { get; set; }
    }
}
