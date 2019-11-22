using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDirectoryAPI.Models
{
    public class TeamDetailDto
    {
        public int TeamId { get; set; }
        public String TeamName { get; set; }
        public String LeadName { get; set; }
        public String TeamDicription { get; set; }
    }
}
