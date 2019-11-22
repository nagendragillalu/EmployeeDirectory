using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDirectoryAPI.Models
{
    public class EmployeeDto
    {
        public int EmployeeId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime Dob { get; set; }
        public DateTime JoiningDate { get; set; }
        public String EmailId { get; set; }
        public String SPOC { get; set; }
        public String PhotoUrl { get; set; }
        public RolesDto Role { get; set; }
        public DepartmentDetailsDto Departmnent { get; set; }
        public TeamDetailDto Team { get; set; }
        public ContactDto ContactDetail { get; set; }
        public BioGraphyDto Bio { get; set; }

        public ICollection<EmployeeSkillsDto> EmployeeSkills { get; set; } = new List<EmployeeSkillsDto>();
    }
}
