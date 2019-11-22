using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDirectoryAPI.Models
{
    public class DepartmentDetailsDto
    {
        public int DepartmentId { get; set; }
        public String DepartmentName { get; set; }
        public String DepartmentDiscription { get; set; }
        public String DepartmentHeadName { get; set; }
    }
}
