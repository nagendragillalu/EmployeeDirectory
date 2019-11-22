using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDirectoryAPI.Models
{
    public class DepartmentEmployeeDetailsDto
    {
        public String DepartmentName { get; set; }
        public String DepartmentDisc { get; set; }
        public String DepartHeadName { get; set; }
        public ICollection<EmployeeDto> EmployeeList { get; set; }
    }
}
