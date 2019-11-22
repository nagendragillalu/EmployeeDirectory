using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
/*
 * This Entity is used to have all the Employee Biography details of an Employee,
 * This Entity has one to one relationship with Employee Entity.
 */
namespace EmployeeDirectoryAPI.Entities
{
    public class EmployeeBiography
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BioId { get; set; }

        [Required]
        [MaxLength(100)]
        public String About { get; set; }

        [MaxLength(100)]
        public String Hobbies { get; set; }

        [MaxLength(100)]
        public String Interests { get; set; }

        // public Employee Employee { get; set; }
    }
}
