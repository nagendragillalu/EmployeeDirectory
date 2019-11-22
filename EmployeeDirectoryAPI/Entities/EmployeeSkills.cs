using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
/*
 * This Enity has Many to One relationship with Sills entity,
 * And has Many to one to Many relationship with Employee Entity.
 */
namespace EmployeeDirectoryAPI.Entities
{
    public class EmployeeSkills
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("SkillId")]
        public int SkillId { get; set; }
        public Skills skills { get; set; }


        [MaxLength(50)]
        public string SkillLevel { get; set; }


        [ForeignKey("EmployeeId")]
        public int EmployeeId { get; set; }
        public Employee employee { get; set; }
    }
}
