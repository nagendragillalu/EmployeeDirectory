using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
/*
 *This Enity holds Skills and has one to many relationship. 
 */
namespace EmployeeDirectoryAPI.Entities
{
    public class Skills
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SkillID { get; set; }

        [Required]
        [MaxLength(50)]
        public String SkillName { get; set; }

        public ICollection<EmployeeSkills> EmployeeSkills { get; set; }
    }
}
