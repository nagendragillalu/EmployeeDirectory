using EmployeeDirectoryAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
/*
 * This Entity is used to have all the Employee details of an Employee,
 * This Entity has one to one relationship with DepartmentDetails,ContactDetails,EmployeeBiography
 * EmployeeRole Entity And Has One to Many Relationship with EmployeeSkills Entity
 */
namespace EmployeeDirectoryAPI.Entities
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }
        [Required]
        [MaxLength(20)]
        public String FirstName { get; set; }
        [Required]
        [MaxLength(20)]
        public String LastName { get; set; }
        [Required]
        [MaxLength(10)]
        public DateTime Dob { get; set; }

        [MaxLength(300)]
        public String EmployeePhotoURL { get; set; }

        [Required]
        public DateTime JoiningDate { get; set; }

        [Required]
        [MaxLength(300)]
        public String EmailID { get; set; }

        [MaxLength(300)]
        public String SPOC { get; set; }

        [Required]
        [MaxLength(20)]
        [ForeignKey("RoleId")]
        public int RoleId { get; set; }
        public EmployeeRoles employeeRoles { get; set; }

        //public ICollection<EmployeeSkills> EmployeeSkills { get; set; } = new List<EmployeeSkills>();

        [ForeignKey("DepartmentId")]
        public DepartmentDetails DepartmentDetails { get; set; }

        [ForeignKey("TeamID")]
        public TeamDetails TeamDetails { get; set; }

        [ForeignKey("ContactId")]
        public int ContactId { get; set; }
        public ContactDetails ContactDetails { get; set; }

        [ForeignKey("BioId")]
        public int BioId { get; set; }
        public EmployeeBiography EmployeeBiography { get; set; }
    }
}
