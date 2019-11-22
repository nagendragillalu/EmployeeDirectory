using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDirectoryAPI.Models
{
    public class EmployeeSkillsDto
    {
        public int SkillId { get; set; }
        public int EmployeeId { get; set; }

        public string SkillName { get; set; }
        public string SkillLevel { get; set; }

    }
}
