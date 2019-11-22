using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
/*
 * This Entity is used to have all the Employee Role of an Employee,
 * This Entity has one to one relationship with Employee Entity.
 */
namespace EmployeeDirectoryAPI.Entities
{
    public class EmployeeRoles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleId { get; set; }

        [Required]
        [MaxLength(25)]
        public String RoleName { get; set; }

        //public ICollection<Employee> Employees { get; set; }
    }
}
