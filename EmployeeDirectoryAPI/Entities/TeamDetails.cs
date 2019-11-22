using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
/*
 *This Enity holds Team Details and has one to one relationship with Employee Entity. 
 */
namespace EmployeeDirectoryAPI.Entities
{
    public class TeamDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeamID { get; set; }

        [Required]
        [MaxLength(20)]
        public String TeamName { get; set; }

        [MaxLength(20)]
        public String TeamLeadName { get; set; }

        [MaxLength(100)]
        public String TeamDiscription { get; set; }
        //public String TeamSize { get; set; }


        //public int DepartmentID { get; set; }
        //public DepartmentDetails DepartmentDetails { get; set; }

        //ForeignKey("EmployeeId")]
        //public int EmployeeId { get; set; }
        //public Employee Employees { get; set; }


    }
}
