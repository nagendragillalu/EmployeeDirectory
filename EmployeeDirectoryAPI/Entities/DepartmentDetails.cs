using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
/*
 * This Entity is used to have all the Department details of an Employee,
 * This Entity has one to one relationship with Employee Entity.
 */
namespace EmployeeDirectoryAPI.Entities
{
    public class DepartmentDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepartmentId { get; set; }

        [Required]
        [MaxLength(20)]
        public String DepartmentName { get; set; }
        [MaxLength(100)]
        public String DepartmentDiscription { get; set; }
        [MaxLength(20)]
        public String DepartmentHeadName { get; set; }

        // public ICollection<TeamDetails> Teams { get; set; }

        //public ICollection<Employee> Employees { get; set; }
    }
}
